namespace UrbanMobility.Api.Models;

// These don't have to be in the same file.
// I just like having less files in the project.

public enum VehicleStatus
{
    Available = 1,
    InUse = 2,
    Maintenance = 3,
    Retired = 4
}

public enum EngineType
{
    Gasoline = 1,
    Diesel = 2,
    Hybrid = 3
}