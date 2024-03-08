using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_data_access.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        public int CostPrice { get; set; }
        public string Producer { get; set; }
        public int Price { get; set; }

        public override string ToString()
        {
            return $"Id:{Id,-5} Name:{Name,-15} Type:{Type,-15} Quantity:{Quantity,-5} CostPrice:{CostPrice,-5} Producer:{Producer,-10} Price:{Price,-5}";
        }
    }
}
