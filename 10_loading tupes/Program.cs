using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_loading_tupes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SoftServeDB ctx = new SoftServeDB();
            #region Lazy Loading
            // Завантаження звязаних обєктів відбувається лише в момент доступу до них
            // 1 - property must be public 
            // 2 - class must be not sealed
            // 3 - property must be virtual
            // 4 - ctx.Configuration.LazyLoadingEnabled = true; (default)

            /*foreach (var w in ctx.Workers)
            {
                Console.WriteLine($"\n\n {new string('-', 50)}");
                Console.WriteLine($"-------- Worker[{w.Id}] {w.FullName}");
                Console.WriteLine($"\t Department: {w.Department.Name} {w.Salary}"); // load department
                if (w.CountryId != null)
                {
                    Console.WriteLine($"\t Country: {w.Country.Name}"); // load country

                }
                foreach (var item in w.Projects) // load Projects
                {
                    Console.WriteLine($"\t Project :: {item.Name}");
                }
            }*/
            #endregion

            #region Eager Loading
            // Завантаження звязаних обєктів відбувається відразу при виконанні основного запиту
            // Застосовується оператор JOIN

            /*var workerQuuery = ctx.Workers
                .Include(nameof(Worker.Department)) // load department
                .Include(nameof(Worker.Country)) // load country
                .Include(nameof(Worker.Projects)); // load Projects
            ctx.Configuration.LazyLoadingEnabled = false;

            foreach (var w in workerQuuery)
            {
                Console.WriteLine($"\n\n {new string('-', 50)}");
                Console.WriteLine($"-------- Worker[{w.Id}] {w.FullName}");
                Console.WriteLine($"\t Department: {w.Department.Name} {w.Salary}"); // load department
                if (w.CountryId != null)
                {
                    Console.WriteLine($"\t Country: {w.Country.Name}"); // load country

                }
                foreach (var item in w.Projects) // load Projects
                {
                    Console.WriteLine($"\t Project :: {item.Name}");
                }
            }*/
            #endregion


            #region Explicit load
            // завантаження звязаних обєктів відбувається явним викликом

            /*ctx.Entry(entity).Reference(propertyName).Load();
            ctx.Entry(entity).Collection(collectionName).Load();*/
            ctx.Configuration.LazyLoadingEnabled = false;
            Console.WriteLine("Enter worker Id");
            int workerId = int.Parse(Console.ReadLine());

            Worker worker = ctx.Workers.Find(workerId);
            if(worker == null ) {
                Console.WriteLine("Worker not found");
                return;
            }
            ctx.Entry(worker).Reference(nameof(Worker.Department)).Load();
            Console.WriteLine($"---- Worker [{worker.Id}] {worker.Name} \n Department :: {worker.Department.Name}");

            ctx.Entry(worker).Collection(nameof(Worker.Projects)).Load();
            foreach (var item in worker.Projects) // load Projects
            {
                Console.WriteLine($"\t Project :: {item.Name}");
            }
            #endregion
        }
    }
}
