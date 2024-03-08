using System.Configuration;
using System.Diagnostics;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

internal partial class Program
{

    private static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        SportShopDB db = new SportShopDB(ConfigurationManager.ConnectionStrings["connSportShop"].ConnectionString);

        /*List<Product> product = db.GetAllProducts();
        
        foreach (var item in product)
        {
            Console.WriteLine(item);
        }*/
        db.GetAllProducts().ForEach(item => { Console.WriteLine(item); });
        /*Product product = new Product()
        {
            Name = "Ball",
            Type = "sport",
            Quantity = 15,
            CostPrice = 150,
            Price = 500,
            Producer = "China"
        };
        db.Create(product);*/
        /*Product product = db.getOneProduct(1);
        Console.WriteLine("\n" + product);
        product.Price -= 50;
        product.Quantity -= 5;
        Console.WriteLine("\n" + product);
        db.Update(product);*/
        db.Delete(9);
    }
}