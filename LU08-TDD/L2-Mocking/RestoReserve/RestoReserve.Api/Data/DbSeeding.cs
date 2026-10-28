using RestoReserve.Core.Models;

namespace RestoReserve.Api.Data;

public static class DbSeeding
{
    public static void Seed(RestoContext context)
    {
        // Only seed if db is empty
        if (context.Restaurants.Any())
        {
            return;
        }

        // Had an AI agent find these
        // They are definitely wrong!
        context.Restaurants.AddRange(
            new Restaurant
            {
                Name = "Bubba-Q's",
                Cuisine = Cuisine.Italian,
                OpeningTime = new TimeOnly(11, 0),
                ClosingTime = new TimeOnly(20, 0)
            },
            new Restaurant
            {
                Name = "Hub Coffee",
                Cuisine = Cuisine.Italian,
                OpeningTime = new TimeOnly(7, 0),
                ClosingTime = new TimeOnly(16, 0)
            },
            new Restaurant
            {
                Name = "Java Rocket",
                Cuisine = Cuisine.Italian,
                OpeningTime = new TimeOnly(6, 0),
                ClosingTime = new TimeOnly(18, 0)
            },
            new Restaurant
            {
                Name = "La Jefa",
                Cuisine = Cuisine.Mexican,
                OpeningTime = new TimeOnly(11, 0),
                ClosingTime = new TimeOnly(21, 0)
            },
            new Restaurant
            {
                Name = "Mini Cafe",
                Cuisine = Cuisine.Italian,
                OpeningTime = new TimeOnly(6, 0),
                ClosingTime = new TimeOnly(14, 0)
            },
            new Restaurant
            {
                Name = "Owl's Nest",
                Cuisine = Cuisine.Chinese,
                OpeningTime = new TimeOnly(7, 0),
                ClosingTime = new TimeOnly(14, 0)
            },
            new Restaurant
            {
                Name = "Red's Pub",
                Cuisine = Cuisine.Chinese,
                OpeningTime = new TimeOnly(16, 0),
                ClosingTime = new TimeOnly(23, 0)
            },
            new Restaurant
            {
                Name = "Tom-Tom Tap",
                Cuisine = Cuisine.Chinese,
                OpeningTime = new TimeOnly(11, 0),
                ClosingTime = new TimeOnly(22, 0)
            },
            new Restaurant
            {
                Name = "Tortaco",
                Cuisine = Cuisine.Mexican,
                OpeningTime = new TimeOnly(11, 0),
                ClosingTime = new TimeOnly(21, 0)
            },
            new Restaurant
            {
                Name = "Whitey's",
                Cuisine = Cuisine.Chinese,
                OpeningTime = new TimeOnly(11, 0),
                ClosingTime = new TimeOnly(21, 0)
            });

        context.SaveChanges();
    }
}