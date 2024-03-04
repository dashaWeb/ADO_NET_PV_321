using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_connected_mode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Connection String - містить всю інформацію для підключення до сервера 
            // SQL Server
            // -- Windows Authentication -- 
            // "Data Source=server_name;Initial Catalog=db_name;Integrated Security=True"
            // -- Server Authentication -- 
            // "Data Source=server_name;Initial Catalog=db_name;Integrated Security=False;User ID=login;Password=password"
            string conn = "Data Source=(localdb)\\ProjectModels; Initial Catalog=SportShop_PV_321;Integrated Security=True;Connect Timeout=2";
            // default Connect Timeout=30
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            Console.WriteLine("Connected");
            // ExecuteNonQuery - викoнує команду, яка не повертає результату (insert delete, update), але метод повертає кількість рядків, які були задіяні в команді
            /*string cmdText = @"insert into Products 
                                values('Зошит','Школа',100, 15, 'Україна', 30)";

            SqlCommand command = new SqlCommand(cmdText, connection);

            int row = command.ExecuteNonQuery();
            
            Console.WriteLine($"{row} use");*/

            // ExecuteScalar - виконує команду, яка повертає одне значення
            /* string cmdText = "select AVG(Price) from Products";
             SqlCommand command = new SqlCommand(cmdText,connection);
             int res = (int)command.ExecuteScalar();
             Console.WriteLine($"Result :: {res}");*/


            //ExecuteReader - виконує команду select та повертає результат у вигляді DbDataReader
            string cmdText = "select* from Products";
            Console.OutputEncoding= Encoding.UTF8;
            Console.InputEncoding= Encoding.UTF8;
            SqlCommand command = new SqlCommand(cmdText,connection);
            SqlDataReader reader = command.ExecuteReader();
            for (int i = 0; i < reader.FieldCount; i++) // FieldCount -  кількість стовпців
            {
                Console.Write($"{reader.GetName(i),16}");
            }
            Console.WriteLine();
            Console.WriteLine(new string('-',120));
            while(reader.Read()) {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write($"{reader[i],16}");
                }
                Console.WriteLine();
            }

            connection.Close();
        }
    }
}
