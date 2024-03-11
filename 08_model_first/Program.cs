using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_model_first
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LibraryModeContainer context = new LibraryModeContainer();

            /*context.Authors.Add(new Author()
            {
                Name = "King",
                Birthdate = new DateTime(1960, 11, 12)
            });
            context.SaveChanges();*/

           /* context.Books.Add(new Book()
            {
                Title = "It",
                AuthorId = 1,
            });
            context.SaveChanges();*/

            foreach (var book in context.Books.Include(nameof(Book.Author)).Where(p=>p.Author != null)) {

                Console.WriteLine($"{book.Title} {book.Author.Name}");
            }
        }
    }
}
