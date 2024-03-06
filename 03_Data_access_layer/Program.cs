﻿using _03_Data_access_layer;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

internal class Program
{

    public class SportShopDB
    {
        //[C]reate
        //[R]ead
        //[U]pdate
        //[D]elete

        SqlConnection connection;
        public SportShopDB(string conString)
        {
            connection = new SqlConnection(conString);
            connection.Open();
            Console.WriteLine("Connected");
        }
        private void setCommandParams(ref SqlCommand command, Product product)
        {
            command.Parameters.Add("@name", System.Data.SqlDbType.NVarChar).Value = product.Name;
            command.Parameters.Add("@type", System.Data.SqlDbType.NVarChar).Value = product.Type;
            command.Parameters.Add("@quantity", System.Data.SqlDbType.Int).Value = product.Quantity;
            command.Parameters.Add("@cost_price", System.Data.SqlDbType.Int).Value = product.CostPrice;
            command.Parameters.Add("@producer", System.Data.SqlDbType.NVarChar).Value = product.Producer;
            command.Parameters.Add("@price", System.Data.SqlDbType.Int).Value = product.Price;
        }
        public void Create(Product product)
        {
            string cmdText = @"insert into Products 
                            values(@name,@type,@quantity,@cost_price,@producer,@price)";
            SqlCommand command = new SqlCommand(cmdText, connection);
            setCommandParams(ref command, product);
            command.ExecuteNonQuery();
        }
        private List<Product> getProductQuery(SqlCommand command)
        {
            List<Product> products = new List<Product>();
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                products.Add(new Product()
                {
                    Id = (int)reader[0], // reader["Id"];
                    Name = (string)reader[1],
                    Type = (string)reader[2],
                    Quantity = (int)reader[3],
                    CostPrice = (int)reader[4],
                    Producer = (string)reader[5],
                    Price = (int)reader[6],
                });
            }
            reader.Close();
            return products;
        }
        public Product getOneProduct(int id)
        {
            string cmdText = "select* from Products where Id = @id";
            SqlCommand command = new SqlCommand(cmdText, connection);
            command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
            return getProductQuery(command).FirstOrDefault();
        }
        public List<Product> GetAllProducts()
        {
            string cmdText = "select* from Products";
            SqlCommand command = new SqlCommand(cmdText, connection);
            return getProductQuery(command);

        }
        public void Update(Product product)
        {
            string cmdText = @"update Products
                           set
                                Name = @name,
                                TypeProduct = @type,
                                Quantity = @quantity,
                                CostPrice = @cost_price,
                                Producer = @producer,
                                Price = @price
                            where Id = @id";
            SqlCommand command = new SqlCommand(cmdText, connection);
            setCommandParams(ref command, product);
            command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = product.Id;

            command.ExecuteNonQuery();
        }
        public void Delete(int id)
        {
            string cmdText = @"delete from Products
                           where Id = @id";
            SqlCommand command = new SqlCommand(cmdText, connection);
            command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
            command.ExecuteNonQuery();
        }

    }

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