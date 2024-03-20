using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_Dapper
{
    public interface ICarRepository
    {
        List<Car> GetCars();
        Car Get(int id);
        Car Create(Car car);
        void Update(Car car);
        void Delete(int id);
    }
}
