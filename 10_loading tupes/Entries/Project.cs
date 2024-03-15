using System;
using System.Collections.Generic;

namespace _10_loading_tupes
{
    public class Project
    {
        public Project()
        {
            Workers = new HashSet<Worker>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime LaunchDate { get; set; }

        // Navigation properties
        public virtual ICollection<Worker> Workers { get; set; }
    }
}