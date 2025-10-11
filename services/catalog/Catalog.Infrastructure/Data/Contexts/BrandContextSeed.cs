using Catalog.Core.Entities;

using MongoDB.Driver;

using System.Text.Json;

namespace Catalog.Infrastructure.Data.Contexts
{
    static class BrandContextSeed
    {
        public static async Task SeedDataAsync(IMongoCollection<ProductBrand> brandCollection)
        {
            var hasbrands = await brandCollection.Find(_ => true).AnyAsync();

            if (hasbrands)
                return;

            var filePath = Path.Combine("Data", "SeedData", "brands.json");

            if (!File.Exists(filePath))
            {
                Console.WriteLine($"SeedData of brands.json not found : {filePath}");
                return;
            }

            var brandData = File.ReadAllText(filePath);
            var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandData);

            if (brands?.Any() is true)
            {
                await brandCollection.InsertManyAsync(brands);
            }

        }
    }
}
