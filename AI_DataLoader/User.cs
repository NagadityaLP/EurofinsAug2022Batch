using System.Collections.Generic;

namespace AI_DataLoader
{
    public class User
    {
        public string UserID { get; set; }
        public string Age { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public List<BookUserRating> bookUserRatings { get; set; } = new List<BookUserRating>();

        public User(string userID, string city, string state, string country, string age)
        {
            UserID = userID;
            City = city;
            State = state;
            Country = country;
            Age = age;
        }
    }
}
