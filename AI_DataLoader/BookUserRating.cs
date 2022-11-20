
namespace AI_DataLoader
{
    public class BookUserRating
    {
        public string Rating { get; set; }
        public string ISBN { get; set; }
        public string UserID { get; set; }

        public BookUserRating(string userID, string iSBN, string rating)    
        {
            Rating = rating;
            ISBN = iSBN;
            UserID = userID;
        }
    }
}
