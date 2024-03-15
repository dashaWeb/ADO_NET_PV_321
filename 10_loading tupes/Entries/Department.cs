using System.Collections.Generic;

namespace _10_loading_tupes
{
    public class Department
    {
        public Department()
        {
            Workers = new HashSet<Worker>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        // Navigation properties
        public virtual ICollection<Worker> Workers { get; set; }
    }
}