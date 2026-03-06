using System;
using System.Collections.Generic;
using System.Linq;
using RetroGameApp.Models;
using RetroGameApp.DTOs;
using RetroGameApp.Repositories;

public class ConsoleApp
{
    public void Run()
    {
        const string ConnectionString = "Data Source=retro_games.db";
        var repo = new GameRepository(ConnectionString);

        SeedInitialData(repo);

        bool running = true;

        while (running)
        {
            Console.WriteLine("\n--- Retro Game Collection Manager ---");
            Console.WriteLine("1. View All Games");
            Console.WriteLine("2. Search by Platform");
            Console.WriteLine("3. Add New Game");
            Console.WriteLine("4. Exit");
            Console.Write("Select an option: ");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    DisplayGames(repo.GetAll());
                    break;

                case "2":
                    Console.Write("Enter Platform (e.g., NES, Genesis, SNES): ");
                    string? platform = Console.ReadLine();
                    var search = new GameSearchDto(platform, null);
                    DisplayGames(repo.GetByFilter(search));
                    break;

                case "3":
                    AddNewGame(repo);
                    break;

                case "4":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }
    void SeedInitialData(GameRepository repository)
    {
        if (!repository.GetAll().Any())
        {
            Console.WriteLine("[System] Seeding initial collection...");
            repository.Add(new VideoGame(0, "Super Mario Bros.", "NES", 1985, "Platformer"));
            repository.Add(new VideoGame(0, "Sonic the Hedgehog", "Genesis", 1991, "Platformer"));
            repository.Add(new VideoGame(0, "Street Fighter II", "SNES", 1992, "Fighting"));
        }
    }

    void DisplayGames(IEnumerable<VideoGame> games)
    {
        Console.WriteLine("\nTITLE | PLATFORM   | YEAR | GENRE");
        Console.WriteLine(new string('-', 65));

        foreach (var g in games)
        {
            Console.WriteLine($"{g.Title,-30} | {g.Platform,-10} | {g.ReleaseYear} | {g.Genre}");
        }
    }

    void AddNewGame(GameRepository repository)
    {
        throw new NotImplementedException("Not Enough Time To Implement This Feature");
    }
}