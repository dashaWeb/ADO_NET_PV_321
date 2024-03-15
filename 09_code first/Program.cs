using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_code_first
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SoftServeDB context = new SoftServeDB();

            // Countries
            /*context.Countries.Add(new Country() { Name = "Ukraine" });
            context.Countries.Add(new Country() { Name = "Poland" });
            context.Countries.Add(new Country() { Name = "USA" });
            context.SaveChanges();*/

            // Departments
            /*context.Departments.Add(new Department() { Name = "Management", Phone = "20-85-65" });
            context.Departments.Add(new Department() { Name = "Programming", Phone = "45-85-96" });
            context.Departments.Add(new Department() { Name = "Design", Phone = "10-10-10" });
            context.SaveChanges();*/

            /*foreach (var item in context.Countries)
            {
                Console.WriteLine(item.Name);
            }*/
            // Workers
            /*context.Workers.Add(new Worker()
            {
                Name = "Bill",
                SurName = "Gates",
                Salary = 3500,
                Birthdate = new DateTime(2000, 12, 4),
                CountryId = context.Countries.Where(c => c.Name == "USA").First().Id,
                DepartmentId = context.Departments.Where(c => c.Name == "Programming").First().Id,
            });
            context.Workers.Add(new Worker()
            {
                Name = "Tomm",
                SurName = "Page",
                Salary = 4730,
                Birthdate = new DateTime(2002, 3,24),
                CountryId = context.Countries.Where(c => c.Name == "Poland").First().Id,
                DepartmentId = context.Departments.Where(c => c.Name == "Programming").First().Id,
            });
            context.Workers.Add(new Worker()
            {
                Name = "Emma",
                SurName = "Miller",
                Salary = 4200,
                Birthdate = new DateTime(2002,11, 21),
                CountryId = context.Countries.Where(c => c.Name == "Ukraine").First().Id,
                DepartmentId = context.Departments.Where(c => c.Name == "Design").First().Id,
            });
            context.Workers.Add(new Worker()
            {
                Name = "Oleg",
                SurName = "King",
                Salary = 5000,
                Birthdate = new DateTime(2001, 12, 12),
                CountryId = context.Countries.Where(c => c.Name == "Ukraine").First().Id,
                DepartmentId = context.Departments.Where(c => c.Name == "Management").First().Id,
            });*/
            //context.SaveChanges();

            //Projects
            /*context.Projects.Add(new Project() { Name = "Tetris", LaunchDate = new DateTime(1982, 12, 20) }); 
            context.Projects.Add(new Project() { Name = "PacMan", LaunchDate = new DateTime(2000, 5, 1) }); 
            context.Projects.Add(new Project() { Name = "CS", LaunchDate = new DateTime(2005, 4, 23) }); 
            context.SaveChanges();*/

            /*Worker worker1 = context.Workers.FirstOrDefault(s => s.Name == "Bill" && s.SurName == "Gates");
            Worker worker2 = context.Workers.FirstOrDefault(s => s.Name == "Emma" && s.SurName == "Miller");
            Worker worker3 = context.Workers.FirstOrDefault(s => s.Name == "Oleg" && s.SurName == "King");

            Project pr1 = context.Projects.FirstOrDefault(s => s.Name == "Tetris");
            Project pr2 = context.Projects.FirstOrDefault(s => s.Name == "PacMan");
            Project pr3 = context.Projects.FirstOrDefault(s => s.Name == "CS");


            worker1.Projects.Add(pr1);
            worker2.Projects.Add(pr1);
            worker3.Projects.Add(pr1);
            worker2.Projects.Add(pr2);
            worker1.Projects.Add(pr2);
            worker3.Projects.Add(pr3);
            worker2.Projects.Add(pr3);
            context.SaveChanges();*/



            foreach (var worker in context.Workers)
            {
                Console.WriteLine($"\n\n {new string('-',50)}");
                Console.WriteLine($"-------- User[{worker.Id}] {worker.FullName}");
                Console.WriteLine($"\t Department: {worker.Department.Name} {worker.Salary}");
                Console.WriteLine($"\t BirthDate : {(worker.Birthdate.HasValue ? worker.Birthdate.Value.ToShortDateString() : "No Birth Date")}");
                Console.WriteLine($"\t Country   : {(worker.Country == null ? "Empty Field" : worker.Country.Name)}");

                foreach (var pr in worker.Projects)
                {
                    Console.WriteLine($"\t\t Project : {pr.Name} from {pr.LaunchDate.ToShortDateString()}");
                }
            }
        }
    }
}
