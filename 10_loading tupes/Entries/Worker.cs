using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _10_loading_tupes
{ 
    [Table("Employees")]
    public class Worker
    {
        public Worker()
        {
            Projects = new HashSet<Project>();
        }
        [Key] // primary key
        public int Id { get; set; }
        [Required] // not null
        [Column("FirstName")]
        public string Name { get; set; }
        [Required,Column("LastName")]
        public string SurName { get; set; }
        [NotMapped] // only in entity
        public string FullName => $"{Name} {SurName}";
        public decimal Salary { get; set; }
        public DateTime? Birthdate { get; set; }

        // Foreign key
        // 0/1 ..* (zero or one to many)
        //[ForeignKey("Country")]
        public int? CountryId { get; set; }
        // 1 ... * (one to many)
        public int DepartmentId { get; set; }

        // Navigation properties
        public virtual Country Country { get; set; }
        public virtual Department Department { get; set; }

        // Relation type -> many to many
        public virtual ICollection<Project> Projects { get; set; }
    }
}