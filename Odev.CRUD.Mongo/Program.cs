using Odev.CRUD.Mongo.Repositories;
using System;
using System.Threading.Tasks;

namespace Odev.CRUD.Mongo
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            ProductRepository repository = new ProductRepository();

            /* Create Product */
            var createdProduct = await repository.CreateProductAsync(new Entities.Product
            {
                Name = "Televizyon",
                Price = 3000,
                Stock = 200
            });
            Console.WriteLine("Eklenen ürün1 :" + createdProduct.Id);
            Console.WriteLine("-------------------------");
            var createdProduct2 = await repository.CreateProductAsync(new Entities.Product
            {
                Name = "Telefon",
                Price = 1500,
                Stock = 140
            });
            Console.WriteLine("Eklenen ürün2 :" + createdProduct2.Id);
            Console.WriteLine("-------------------------");
            var createdProduct3 = await repository.CreateProductAsync(new Entities.Product
            {
                Name = "Bilgisayar",
                Price = 5880,
                Stock = 120
            });

            Console.WriteLine("Eklenen ürün3 :" + createdProduct3.Id);
            Console.WriteLine("-------------------------");

            /*Product Update */
            await repository.UpdateProductAsync(new Entities.Product
            {
                Id = "63cfcf42e428f79fe3aae380",
                Name = "Tablet",
                Price = 1700,
                Stock = 23,
            });

            Console.WriteLine("ürün update edildi");
            Console.WriteLine("-------------------------");

            /*Product Remove */
            await repository.RemoveProductAsync("63cfcf42e428f79fe3aae382");


            /*Product List */

            var list =  await repository.GetAllAsync();

            Console.WriteLine("ürün listesi....");

            foreach (var item in list)
            {
                Console.WriteLine("ürün ismi :" + item.Name);
            }

            Console.WriteLine("-------------------------");
            /*Product GetById */

            var product = await repository.GetById("63cfcf42e428f79fe3aae380");

            Console.WriteLine("gelen ürün :"+product.Name);
            Console.WriteLine("-------------------------");

            /*Product Search */
            /*adında o geçen productların getirilmesi */
            var searchedProducts = await repository.FindAsync("o");

            Console.WriteLine("Bulunan ürün listesi....");
            foreach (var item in searchedProducts)
            {
                Console.WriteLine("Ürün ismi :" + item.Name);
            }
        }
    }
}
