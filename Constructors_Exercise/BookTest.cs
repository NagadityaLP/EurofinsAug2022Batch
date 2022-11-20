using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructors_Exercise
{
    internal class BookTest
    {
        static void Main(string[] args)
        {
            Book book = new Book("Positive Thinking in Youth", "Fernandis", true);
            Book book1 = new Book("Positive Thinking in Youth", "Fernandis");
            Book book2 = new Book("Positive Thinking in Youth");
            Book book4 = new Book();
        }
    }
    class Book
    {
        string title;
        string author;
        bool available;

        public Book(string title, string author, bool available)
        {
            this.title = title;
            this.author = author;
            this.available = available;
            if(available)
                Console.WriteLine($"Title of the book is {title}, it's author is {author} and is available");
            else
                Console.WriteLine($"Title of the book is {title}, it's author is {author} and is not available");
            Console.WriteLine("First Constructor called.");
        }
        public Book(string title, string author) : this(title, author, false)
        {
            /*this.title = title;
            this.author = author;
            this.available = true;
            Console.WriteLine($"Title of the book is {title}, it's author is {author} and is available");
            Console.WriteLine("Second Constructor called.");*/
        }
        public Book(string title) : this(title, "anonymous", true)    
        {
            /*this.title = title;
            this.author = "anonymous";
            this.available = true;
            Console.WriteLine($"Title of the book is {title}, it's author is {author} and is available");
            Console.WriteLine("Third Constructor called.");*/
        }
        public Book() : this("untitled", "anonymous", false)
        {
            /*this.title = "untitled";
            this.author = "anonymous";
            this.available = true;
            Console.WriteLine($"Title of the book is {title}, it's author is {author} and is available");
            Console.WriteLine("Fourth Constructor i.e. the default constructor is called.");*/
        }
    }
}
