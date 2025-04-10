using Microsoft.EntityFrameworkCore;
using StorageApi.Models;
using StorageApi.Properties.EFCore;

namespace StorageApi.Properties
{
    public static class DbInitializer
    {
        public static async Task Initialize(AppDbContext context)
        {
            if (await context.StorageItems.AnyAsync())
                return;

            var categories = new[] { "Электроника", "Инструменты", "Офис", "Материалы" };
            var units = new[] { "шт", "кг", "м", "л" };

            var random = new Random();
            var items = new List<StorageItem>();

            for (int i = 1; i <= 50; i++)
            {
                items.Add(new StorageItem
                {
                    Name = $"Товар {i}",
                    ArticleNumber = $"ART-{1000 + i}",
                    Price = (decimal)(random.NextDouble() * 1000),
                    Quantity = random.Next(0, 500),
                    Unit = units[random.Next(units.Length)],
                    Category = categories[random.Next(categories.Length)],
                    MinimumStockLevel = random.Next(5, 20),
                    MaximumStockLevel = random.Next(100, 500)
                });
            }

            await context.StorageItems.AddRangeAsync(items);
            await context.SaveChangesAsync();
        }
    }
}
