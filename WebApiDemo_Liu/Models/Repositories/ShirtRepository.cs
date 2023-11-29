﻿namespace WebApiDemo_Liu.Models.Repositories
{
    public static class ShirtRepository
    {
        private static List<Shirt> shirts = new List<Shirt>()
        {
            new Shirt {ShirtId=1, Brand="My Brand", Color="Red", Gender="Men", Price=19.99, Size=11 },
             new Shirt {ShirtId=2, Brand="My Brand", Color="Black", Gender="Men", Price=29.99, Size=12 },
              new Shirt {ShirtId=3, Brand="Your Brand", Color="Blue", Gender="Women", Price=39.99, Size=8 },
               new Shirt {ShirtId=4, Brand="Your Brand", Color="Yellow", Gender="Women", Price=49.99, Size=9 },
        };

        public static List<Shirt> GetShirts()
        {
            return shirts;
        }

        public static bool ShirtsExists(int id)
        {
            return shirts.Any(x=>x.ShirtId == id);
        }

        public static Shirt? GetShirtById(int id)
        {
            return shirts.FirstOrDefault(x=>x.ShirtId == id);
        }

        public static void AddShirt(Shirt shirt)
        {
            int maxId = shirts.Max(x=>x.ShirtId);
            shirt.ShirtId = maxId + 1;
            shirts.Add(shirt);
           // return shirt;
        }

        public static Shirt? GetShirtByProperties(string? brand, string? gender, string? color, int? size)
        {
            return shirts.FirstOrDefault(x =>
            !string.IsNullOrWhiteSpace(brand) && !string.IsNullOrWhiteSpace(x.Brand) && x.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase) &&
            !string.IsNullOrWhiteSpace(gender) && !string.IsNullOrWhiteSpace(x.Gender) && x.Gender.Equals(gender, StringComparison.OrdinalIgnoreCase) &&
            !string.IsNullOrWhiteSpace(color) && !string.IsNullOrWhiteSpace(x.Color) && x.Color.Equals(color, StringComparison.OrdinalIgnoreCase) &&
            x.Size.HasValue && size.HasValue && x.Size == size);
        }
    }
}
