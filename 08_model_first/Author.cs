//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _08_model_first
{
    using System;
    using System.Collections.Generic;
    
    public partial class Author
    {
        public Author()
        {
            this.Book = new HashSet<Book>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public System.DateTime Birthdate { get; set; }
    
        public virtual ICollection<Book> Book { get; set; }
    }
}