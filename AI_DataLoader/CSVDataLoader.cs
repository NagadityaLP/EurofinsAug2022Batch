using System;
using System.Collections.Generic;
using System.IO;

//Use multithreading concept in this program

namespace AI_DataLoader
{
    public class CSVDataLoader : IDataLoader
    {
        public BookDetails Load()
        {
            BookDetails bookDetails = new BookDetails();
            var line = "";

            StreamReader reader;

            reader = new StreamReader("C:\\Users\\Admin\\Documents\\Pratian_Training\\.NET Framework\\C#_Start_Project_12_9_22\\EurofinsAug2022Batch\\AI_DataLoader\\Data\\BX-Books.csv");
            //Skip reading first line as it will be the header
            reader.ReadLine();
            try
            {
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    var values = line.Split(';');
                    values[0] = values[0].Trim('"'); //Data read from the file contains double quotes on both the sides of the value
                    Book book = new Book(values[0], values[1], values[2], values[3], values[4], values[5], values[6], values[7]);
                    bookDetails.BooksDict.Add(values[0], book);
                }
            }
            finally
            {
                reader.Close();
            }

            reader = new StreamReader("C:\\Users\\Admin\\Documents\\Pratian_Training\\.NET Framework\\C#_Start_Project_12_9_22\\EurofinsAug2022Batch\\AI_DataLoader\\Data\\BX-Users.csv");
            reader.ReadLine();
            try
            {
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    var values = line.Split(';');
                    if (values.Length != 3) continue; //to skip error data

                    values[2] = (values[2] == "NULL") ? "0" : values[2].Trim('"'); //convrting to required correct format

                    //Split location into City, State and Country
                    var location = values[1].Split(',');
                    if (location.Length != 3) continue; // skip error data
                    User user = new User(values[0], location[0], location[1], location[2], values[2]);
                    
                    bookDetails.UsersDict.Add(values[0], user);
                }
            }
            finally
            {
                reader.Close();
            }

            reader = new StreamReader("C:\\Users\\Admin\\Documents\\Pratian_Training\\.NET Framework\\C#_Start_Project_12_9_22\\EurofinsAug2022Batch\\AI_DataLoader\\Data\\BX-Book-Ratings.csv");
            reader.ReadLine();
            try
            {
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    var values = line.Split(';');
                    if(values.Length != 3) continue;
                    values[1] = values[1].Trim('"');
                    values[2] = values[2].Trim('"');

                    BookUserRating rating = new BookUserRating(values[0], values[1], values[2]);
                    bookDetails.UserRatings.Add(rating);

                    if (bookDetails.BooksDict.ContainsKey(values[1]))
                        bookDetails.BooksDict[values[1]].bookUserRatings.Add(rating);

                    if (bookDetails.UsersDict.ContainsKey(values[0]))
                        bookDetails.UsersDict[values[0]].bookUserRatings.Add(rating);
                }
            }
            finally
            {
                reader.Close();
            }

            return bookDetails;
        }
    }
}
