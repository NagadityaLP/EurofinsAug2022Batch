using AI_DataAggregator;
using AI_DataLoader;
using CorrelationEngine.Design;
using System.Collections.Generic;
using System.Linq;
using System;

namespace AI_Integrator
{
    public class AIRecommendationEngine
    {
        public IList<Book> Recommend(Preference preference, int limit)
        {
            IDataLoader loader = new CSVDataLoader();
            BookDetails bookDetails = loader.Load();
            IRatingsAggrigator aggrigator = new RatingsAggrigator();
            Dictionary<string, List<int>> aggregatedRatings = new Dictionary<string, List<int>>();
            aggregatedRatings = aggrigator.Aggrigate(bookDetails, preference);
            IRecommender correlator = new PearsonRecommender();

            //ratings present in the books dictionary of book list for the isbn given as preference
            List<int> preferencedISBNRatings = new List<int>();

            //all other ratings present for all other isbn's present in the aggregatedRatings Dictionary
            //returned by module 3 except the preferenced isbn
            List<int> otherISBNRatings = new List<int>();

            //List to store all the correlation coefficients obtained from pearson recommender
            //Each value represents correlation between list of preferenced book ratings with
            //each other book's ratings present in the aggregatedRatings
            //More is the value, more is the correlation and that isbn whose ratings got highest
            //correlation with preferenced book ratings is the highly recommended book
            List<double> correlationCoefficients = new List<double>();

            double correlationCoEfficient;

            //Dictionary stores correlation coefficient as the key and isbn as the value
            //correlation coefficient(key) represents to what extent its isbn(value) is correlated
            //with the preferenced book
            Dictionary<double, string> bookCorrelationValue = new Dictionary<double, string>();
            int rating;


            List<BookUserRating> preferencedBookUserRatings;
            if (bookDetails.BooksDict.ContainsKey(preference.ISBN))
            {
                preferencedBookUserRatings = bookDetails.BooksDict[preference.ISBN].bookUserRatings;
                foreach (var bookRating in preferencedBookUserRatings)
                    if (int.TryParse(bookRating.Rating, out rating)) //TryParse doesn't throw any errors
                        preferencedISBNRatings.Add(rating);
            }

            List<string> booksISBN = aggregatedRatings.Keys.ToList();
            foreach (var isbn in booksISBN)
            {
                //if isbn is same as the preferenced isbn, don't consider it as two lists
                //passed to the GetCorrelation method will be same and correlation co-efficient
                //will be 1
                if (isbn == preference.ISBN) continue;

                otherISBNRatings = aggregatedRatings[isbn];

                correlationCoEfficient = correlator.GetCorrelation(preferencedISBNRatings, otherISBNRatings);
                if(correlationCoEfficient.Equals(double.NaN))continue; //skip NaN(Not a Number values)
                correlationCoefficients.Add(correlationCoEfficient);
                bookCorrelationValue[correlationCoEfficient] = isbn;
            }

            //Books need to be recommended based on the correlation coefficients value
            //Hence, we need to get ordered correlation coefficients
            correlationCoefficients.Sort();

            Console.WriteLine("Recommended books based on your preference are : ");
            IList<Book> books = new List<Book>();
            int i = correlationCoefficients.Count - 1;

            //limit represents number of books to be recommended
            while (limit > 0)
            {
                //since ascending sort is done, highest value will be present at the end. Hence start fetching from the last
                var bookIsbn = bookCorrelationValue[correlationCoefficients[i--]];
                if (bookIsbn != null)
                    books.Add(bookDetails.BooksDict[bookIsbn]);
                limit--;
            }

            return books;
        }
    }
}
