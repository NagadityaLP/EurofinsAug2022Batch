
using System.Collections.Generic;

namespace AI_DataLoader
{
    public class BookDetails
    {
        public Dictionary<string, Book> BooksDict { get; set; } = new Dictionary<string, Book>();
        public List<BookUserRating> UserRatings { get; set; }  = new List<BookUserRating>();
        public Dictionary<string, User> UsersDict { get; set; } = new Dictionary<string, User>();   
    }
}
