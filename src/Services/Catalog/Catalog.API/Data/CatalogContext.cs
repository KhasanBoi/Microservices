using Catalog.API.Models;
using Catalog.API.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {

        public CatalogContext(IOptions<MongoDbSettings> mongodbSettings)
        {
            var mongoClient = new MongoClient(mongodbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(mongodbSettings.Value.DatabaseName);
            Products = mongoDatabase.GetCollection<Product>(mongodbSettings.Value.CollectionName);
            CatalogContextSeed.SeedData(Products);
        }

        public IMongoCollection<Product> Products { get; }
    }
}
