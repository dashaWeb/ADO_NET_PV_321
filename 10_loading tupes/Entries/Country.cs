using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _10_loading_tupes
{
    public class Country
    {
        public Country()
        {
            Workers = new HashSet<Worker>();
        }

        // Id, ID, id, CountryId
        public int Id { get; set; }
        [MaxLength(50)] // nvarchar(50)
        public string Name { get; set; }

        // Navigation properties
        public virtual ICollection<Worker> Workers { get; set; }
    }
}