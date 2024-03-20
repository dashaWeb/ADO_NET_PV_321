using _15_Dapper;
using System.Diagnostics;

internal class Program
{
    static Stat TestProvider(ICarRepository repos)
    {
        var result = new Stat();
        Stopwatch sw;

        // Read one
        sw = Stopwatch.StartNew();
        repos.Get(86);
        sw.Stop();
        result.ReadByIdTime = sw.ElapsedMilliseconds;

        // Read all
        sw = Stopwatch.StartNew();
        repos.GetCars();
        sw.Stop();
        result.ReadAllTime = sw.ElapsedMilliseconds;

        // Create
        sw = Stopwatch.StartNew();
        Car car = repos.Create(new Car() { 
            Make = "Lada",
            Model = "Semirka",
            ModelYear = 2001
        });
        sw.Stop();
        result.CreateTime = sw.ElapsedMilliseconds;

        // Update
        car.Model = "new model";
        sw = Stopwatch.StartNew();
        repos.Update(car);
        sw.Stop();
        result.UpdateTime = sw.ElapsedMilliseconds;

        // Delete
        sw = Stopwatch.StartNew();
        repos.Delete(car.Id);
        sw.Stop();
        result.DeleteTime = sw.ElapsedMilliseconds;

        foreach (var stat in result.GetType().GetProperties()) {

            Console.WriteLine($"{stat.Name} : {stat.GetValue(result)}ms");
        }
        return result;
    }
    private static void Main(string[] args)
    {
        var connStr = "data source = DESKTOP-83U7DVV\\SQLEXPRESS; Initial Catalog = CarSalon; Integrated security = True; Connect Timeout = 2";
        Console.WriteLine("\n--------------- Entity Framework Core ---------------");
        TestProvider(new CarRepositoryEF(connStr));
        Console.WriteLine("\n---------------------- ADO.NET ----------------------");
        TestProvider(new CarRepositoryADO_NET(connStr));
        Console.WriteLine("\n---------------------- Dapper -----------------------");
        TestProvider(new CarRepositoryDapper(connStr));
    }
}