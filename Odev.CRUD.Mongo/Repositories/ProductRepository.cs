using MongoDB.Driver;
using Odev.CRUD.Mongo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.CRUD.Mongo.Repositories
{
    public class ProductRepository
    {
        private readonly IMongoCollection<Product> productCollection;
        public ProductRepository()
        {
            /*
            MongoDb.Driver kütüphanesinde bir collection'a(tabloya) erişebilmek için aşağıdaki adımları izlemek gerekir.

             */


            //client üzerinden connection string ile dbye bağlanır.
            var client = new MongoClient("mongodb://localhost:27017");

            //varsa ProductDb database'ine bağlanır, yoksa oluşturur.
            var database = client.GetDatabase("ProductDb");

            // varsa products collection'a bağlanır, yoksa oluşturur.
            productCollection = database.GetCollection<Product>("Products"); 
        }


        public async Task<Product> CreateProductAsync(Product product)
        {
            await productCollection.InsertOneAsync(product);
            return product;
        }

        public async Task UpdateProductAsync(Product product)
        {
            // eğer sonradan bir sutun eklenecekse, mesela category update metodu kullanılabilir.
            await productCollection.FindOneAndReplaceAsync(x => x.Id == product.Id, product);
        }

        public async Task RemoveProductAsync(string id)
        {
            await productCollection.DeleteOneAsync(x => x.Id == id);
        }

        // Product adında ilgili kelime geçen kayıtları arar
        public async Task<List<Product>> FindAsync(string searchString)
        {
            return await productCollection.Find(x => x.Name.Contains(searchString)).ToListAsync();
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await productCollection.Find(x=>true).ToListAsync();
        }

        public async Task<Product> GetById(string id)
        {
            return await productCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
