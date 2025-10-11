using Catalog.Core.Entities;

using MongoDB.Driver;

using System.Text.Json;

namespace Catalog.Infrastructure.Data.Contexts
{
    static class TypeContextSeed
    {
        public static async Task SeedDataAsync(IMongoCollection<ProductType> typeCollection)
        {
            var hastypes = await typeCollection.Find(_ => true).AnyAsync();

            if (hastypes)
                return;

            var filePath = Path.Combine("Data", "SeedData", "types.json");

            if (!File.Exists(filePath))
            {
                Console.WriteLine($"SeedData of types.json not found : {filePath}");
                return;
            }

            var typeData = File.ReadAllText(filePath);
            var types = JsonSerializer.Deserialize<List<ProductType>>(typeData);

            if (types?.Any() is true)
            {
                await typeCollection.InsertManyAsync(types);
            }

        }
    }
}
