using Catalog.Api.Data;
using Catalog.Api.Entites;
using MongoDB.Driver;
using System.Xml.Linq;

namespace Catalog.Api.Repository
{
    public class ProductRepository : IProductRepository
    {
        #region Constructor

        private readonly ICatalogContext context;
        public ProductRepository(ICatalogContext catalogContext)
        {
            context = catalogContext;
        }
        #endregion

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await context.Products.Find(p => true).ToListAsync();
        }

        public async Task<Product> GetProductById(string id)
        {
            return await context.Products.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByName(string name)
        {
            FilterDefinition<Product> filter =
                Builders<Product>.Filter.Eq(p => p.Name, name);

            return await context.Products.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByCatagory(string catagory)
        {
            FilterDefinition<Product> filter =
               Builders<Product>.Filter.Eq(p => p.Catagory, catagory);

            return await context.Products.Find(filter).ToListAsync();
        }

        public async Task CreateProduct(Product product)
        {
            await context.Products.InsertOneAsync(product);
        }

        public async Task<bool> DeleteProduct(string id)
        {
            FilterDefinition<Product> filter=
                Builders<Product>.Filter.Eq(p=>p.Id, id);

           var deleteResult=await context.Products.DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            var updateResult = await context.Products.ReplaceOneAsync(filter: p => p.Id == product.Id, replacement: product);
            return updateResult.IsAcknowledged
                && updateResult.ModifiedCount > 0;
        }
    }
}
