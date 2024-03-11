using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_DB_first
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SportShopContext context = new SportShopContext();

            // select (read)
            //var query = context.Products.Select(p => p);
            var query = context.Products.Where(p => p.Price > 300).OrderByDescending(p=>p.Price);
            Console.OutputEncoding = Encoding.UTF8;
            foreach (var item in query)
            {
                Console.WriteLine($"Product :: {item.Name,10} {item.Price,10}$ {item.Producer}");
            }

            // create

            /*context.Products.Add(new Product()
            {
                Name = "Lime",
                TypeProduct = "fruit",
                CostPrice = 15,
                Price = 30,
                Quantity = 20,
                Producer = "Mexico"
            });
            context.SaveChanges();*/

            // update
            /*int id = 4;
            //Product product = context.Products.FirstOrDefault(p => p.Id == id);
            Product product = context.Products.Find(id);
            *//*product.Price = (int)(product.Price * 1.1);
            context.SaveChanges();*//*

            //delete
            product = context.Products.Find(7);
            context.Products.Remove(product);
            context.SaveChanges();*/

            foreach (var item in context.Salles.Include(nameof(Salle.Product)).Where(s=>s.Product != null))
            {
                Console.WriteLine($"Sale {item.Price,10} {item.Quantity,5} {item.Product.Name} {item.Client.FullName} {item.Employee.FullName}");
            }
        }

    }
}
