using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_Dapper
{
    public class CarRepositoryDapper : ICarRepository
    {
        string connectionString;
        public CarRepositoryDapper(string connStr)
        {
            this.connectionString = connStr;
        }
        public Car Create(Car car)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "insert into Cars(Make,Model,ModelYear) values(@Make,@Model,@ModelYear); select cast(SCOPE_IDENTITY() as int)";
                int carId = db.Query<int>(sqlQuery,car).FirstOrDefault();
                car.Id = carId;
                return car;
            }
            
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Execute("delete from Cars where Id=@id",new {id});
            }
        }

        public Car Get(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                //return db.Query<Car>("select* from Cars where Id = @id", new {id}).FirstOrDefault();
                return db.QueryFirstOrDefault<Car>("select* from Cars where Id = @id", new {id});
            }
        }

        public List<Car> GetCars()
        {
            using(IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Car>("select* from Cars").ToList();
            }
        }

        public void Update(Car car)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Execute("update Cars set Make = @Make, Model = @Model, ModelYear = @ModelYear where Id = @Id",car);
            }
        }
    }
}
