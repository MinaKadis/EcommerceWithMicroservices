using Catalog.Core.Entities;

using MongoDB.Driver;

using System.Text.Json;

namespace Catalog.Infrastructure.Data.Contexts
{
    static class ProductContextSeed
    {
        public static async Task SeedDataAsync(IMongoCollection<Product> productCollection)
        {
            var hasProducts = await productCollection.Find(_ => true).AnyAsync();

            if (hasProducts)
                return;

            var filePath = Path.Combine("Data", "SeedData", "products.json");

            if (!File.Exists(filePath))
            {
                Console.WriteLine($"SeedData of products.json not found : {filePath}");
                return;
            }

            var productData = File.ReadAllText(filePath);
            var products = JsonSerializer.Deserialize<List<Product>>(productData);

            if (products?.Any() is true)
            {
                await productCollection.InsertManyAsync(products);
            }

        }
    }
}
