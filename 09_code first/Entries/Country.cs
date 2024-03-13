using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _09_code_first
{
    public class Country
    {
        public Country()
        {
            Workers = new HashSet<Worker>();
        }
        public int Id { get; set; }
        [MaxLength(50)] // nvarchar(50)
        public string Name { get; set; }

        // Navigation properties
        public virtual ICollection<Worker> Workers { get; set; }
    }
}