using Dapper;
using Microsoft.Data.Sqlite;
using System.Data;
using UrbanMobility.Api.Models;

namespace UrbanMobility.Api.Repositories;

public class VehicleRepository
{
    private readonly string _connectionString;

    public VehicleRepository(string connectionString)
    {
        _connectionString = connectionString;
        InitializeDatabase();
    }

    private IDbConnection CreateConnection() => new SqliteConnection(_connectionString);

    private void InitializeDatabase()
    {
        using var connection = new SqliteConnection(_connectionString);

        var sql = @"
            CREATE TABLE IF NOT EXISTS Vehicles (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Vin TEXT NOT NULL,
                ModelName TEXT NOT NULL,
                HourlyRate DECIMAL NOT NULL,
                Status INTEGER NOT NULL
            );

            CREATE TABLE IF NOT EXISTS ElectricVehicles (
                VehicleId INTEGER PRIMARY KEY,
                BatteryCapacityKwh REAL NOT NULL,
                CurrentChargeLevel INTEGER NOT NULL,
                FOREIGN KEY (VehicleId) REFERENCES Vehicles(Id) ON DELETE CASCADE
            );

            CREATE TABLE IF NOT EXISTS FuelVehicles (
                VehicleId INTEGER PRIMARY KEY,
                FuelTankSizeLiters REAL NOT NULL,
                Engine INTEGER NOT NULL,
                FOREIGN KEY (VehicleId) REFERENCES Vehicles(Id) ON DELETE CASCADE
            );";

        connection.Execute(sql);
    }

    public async Task<IEnumerable<Vehicle>> GetAllAsync()
    {
        using var db = CreateConnection();

        // join the base table with both possible sub-tables
        var sql = @"
            SELECT v.*, e.*, f.*
            FROM Vehicles v
            LEFT JOIN ElectricVehicles e ON v.Id = e.VehicleId
            LEFT JOIN FuelVehicles f ON v.Id = f.VehicleId";

        // Dapper returns dynamic rows, turn them into the right C# objects
        var rows = await db.QueryAsync<dynamic>(sql);
        var vehicles = new List<Vehicle>();

        foreach (var row in rows)
        {
            //TODO can't we just check on Type?
            if (row.BatteryCapacityKwh != null)
            {
                vehicles.Add(new ElectricVehicle
                {
                    Id = (int)row.Id,
                    Vin = row.Vin,
                    ModelName = row.ModelName,
                    HourlyRate = (decimal)row.HourlyRate,
                    Status = (VehicleStatus)row.Status,
                    BatteryCapacityKwh = (double)row.BatteryCapacityKwh,
                    CurrentChargeLevel = (int)row.CurrentChargeLevel
                });
            }
            else if (row.FuelTankSizeLiters != null)
            {
                vehicles.Add(new FuelVehicle
                {
                    Id = (int)row.Id,
                    Vin = row.Vin,
                    ModelName = row.ModelName,
                    HourlyRate = (decimal)row.HourlyRate,
                    Status = (VehicleStatus)row.Status,
                    FuelTankSizeLiters = (double)row.FuelTankSizeLiters,
                    Engine = (EngineType)row.Engine
                });
            }
        }
        return vehicles;
    }

    public async Task<int> CreateElectricAsync(ElectricVehicle vehicle)
    {
        using var db = CreateConnection();
        db.Open();
        using var transaction = db.BeginTransaction();

        try
        {
            // First, insert into the base table
            var vehicleSql = @"
                INSERT INTO Vehicles (Vin, ModelName, HourlyRate, Status)
                VALUES (@Vin, @ModelName, @HourlyRate, @Status);
                SELECT last_insert_rowid();";

            var id = await db.ExecuteScalarAsync<int>(vehicleSql, vehicle, transaction);

            // Second, insert into the specific table using that new ID
            var electricSql = @"
                INSERT INTO ElectricVehicles (VehicleId, BatteryCapacityKwh, CurrentChargeLevel)
                VALUES (@VehicleId, @BatteryCapacityKwh, @CurrentChargeLevel);";

            await db.ExecuteAsync(electricSql, new
            {
                VehicleId = id,
                vehicle.BatteryCapacityKwh,
                vehicle.CurrentChargeLevel
            }, transaction);

            transaction.Commit();
            return id;
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }

    public async Task<int> CreateFuelAsync(FuelVehicle vehicle)
    {
        using var db = CreateConnection();
        db.Open();
        using var transaction = db.BeginTransaction();

        try
        {
            var vehicleSql = @"
                INSERT INTO Vehicles (Vin, ModelName, HourlyRate, Status)
                VALUES (@Vin, @ModelName, @HourlyRate, @Status);
                SELECT last_insert_rowid();";

            var id = await db.ExecuteScalarAsync<int>(vehicleSql, vehicle, transaction);

            var fuelSql = @"
                INSERT INTO FuelVehicles (VehicleId, FuelTankSizeLiters, Engine)
                VALUES (@VehicleId, @FuelTankSizeLiters, @Engine);";

            await db.ExecuteAsync(fuelSql, new
            {
                VehicleId = id,
                vehicle.FuelTankSizeLiters,
                vehicle.Engine
            }, transaction);

            transaction.Commit();
            return id;
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }

    public async Task<bool> DeleteAsync(int id)
    {
        using var db = CreateConnection();
        var sql = "DELETE FROM Vehicles WHERE Id = @id";
        var rowsAffected = await db.ExecuteAsync(sql, new { id });
        return rowsAffected > 0;
    }

    public async Task<Vehicle?> GetByIdAsync(int id)
    {
        var all = await GetAllAsync();
        return all.FirstOrDefault(v => v.Id == id);
    }
}