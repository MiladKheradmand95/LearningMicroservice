using Catalog.Api.Entites;
using MongoDB.Driver;

namespace Catalog.Api.Data
{
    public class CatalogContext : ICatalogContext
    {
        public IMongoCollection<Product> Products { get; }
        public CatalogContext(IConfiguration  configuration)
        {
            var client =new MongoClient(configuration.GetValue<string>("DataBaseSetting:ConnectionSrting"));
            var dataBase = client.GetDatabase(configuration.GetValue<string>("DataBaseSetting:DataBaseName"));
            Products = dataBase.GetCollection<Product>(configuration.GetValue<string>("DataBaseSetting:CollactionName"));
            CatalogContextSeed.SeedData(Products);
        }
        
    }
}
