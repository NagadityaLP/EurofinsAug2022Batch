using AI_DataLoader;
using System.Collections.Generic;
using System.Linq;
using System;

namespace AI_DataAggregator
{
    public class RatingsAggrigator : IRatingsAggrigator
    {
        public Dictionary<string, List<int>> Aggrigate(BookDetails bookDetails, Preference preference)
        {
            Dictionary<string, List<int>> ratingsForABook = new Dictionary<string, List<int>>();
            var users = bookDetails.UsersDict.Values.ToList();
            string expectedState = preference.State.ToLower().Trim();
            int expectedAge = preference.Age;
            int userAge, userBookRating;
            string userState;

            foreach (User user in users)
            {
                userState = user.State.ToLower().Trim();
                if (int.TryParse(user.Age, out userAge) && userState.Contains(expectedState) && checkAgeGroup(userAge).Equals(checkAgeGroup(expectedAge)))
                {
                    foreach (BookUserRating bookRating in user.bookUserRatings)
                    {
                            if (!ratingsForABook.ContainsKey(bookRating.ISBN))
                                ratingsForABook[bookRating.ISBN] = new List<int>();

                            if (int.TryParse(bookRating.Rating, out userBookRating))
                                ratingsForABook[bookRating.ISBN].Add(userBookRating);
                    }
                }
            }

            return ratingsForABook;
        }
        private static string checkAgeGroup(int age)
        {
            if (Enumerable.Range(1, 17).Contains(age))
                return "Teen Age";
            else if (Enumerable.Range(17, 31).Contains(age))
                return "Young Age";
            else if (Enumerable.Range(31, 51).Contains(age))
                return "Mid Age";
            else if (Enumerable.Range(51, 61).Contains(age))
                return "Old Age";  
            else
                return "Senior Citizens";
        }
    }
}
