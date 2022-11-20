using System.Collections.Generic;
using System;
using AI_DataLoader;
using System.Diagnostics;
using AI_DataAggregator;
using AI_Integrator;

namespace AI_Test_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = Stopwatch.StartNew();
            AIRecommendationEngine ai = new AIRecommendationEngine();
            Preference preference = new Preference() { Age = 18, State = "california", ISBN = "0971880107" };
            
            IList<Book> books = ai.Recommend(preference, 5);
            
            foreach (var book in books)
            {
                Console.WriteLine($"Book Title : {book.BookTitle} and \t Book Author : {book.BookAuthor}");
            }
            
            Console.WriteLine("TOTAL TIME TOOK FOR PROGRAM EXECUTION : " + sw.ElapsedMilliseconds);
        }
    }
}
