using System;

namespace IndexerExercises
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Indexer indexer = new Indexer();
            Console.Write("Characters present in the string are : ");
            for(int i = 0; i < indexer["length"]; i++)
                Console.Write($"{indexer[i]} ");

            Console.WriteLine();

            Student student = new Student();
            double gpa = 6.5;
            for (int i = 1; i <= student["length"]; i++)
            {
                student[i] = gpa;
                gpa += 1.1;
            }
            Console.WriteLine($"gpa of first year is {student[1]}");
            Console.WriteLine($"gpa of second year is {student[2]}");
            Console.WriteLine($"gpa of third year is {student[3]}");
            Console.WriteLine($"gpa of fourth year is {student[4]}");

            Photo photo = new Photo("adi");
            Photo photo1 = new Photo("anu");
            Photo photo2 = new Photo("siri");

            Album album = new Album(3);
            album[0] = photo;
            album[1] = photo1;
            album[2] = photo2;

            Console.WriteLine(album[0].Title);
            Console.WriteLine(album[1].Title);
            Console.WriteLine(album["anu1"].Title);
            //Console.WriteLine(album[3].Title);

        }
    }
    class Indexer
    {
        private string name = "aditya";

        public char this [int i]
        {
            get { return name[i]; }
            
        }

        //Indexer overloading in order to fetch the length of the string
        public int this[string len]
        {
            get { return name.Length; }
        }
    }
    class Student
    {
        private double[] gpas = new double[4];

        public double this [int year]
        {
            get
            { 
                if(year < 1)
                {
                    Console.WriteLine("Year doesn't exist. Invalid input");
                    return -1;
                }
                return gpas[year-1]; 
            }
            set
            {
                if (year < 1)
                {
                    Console.WriteLine("Year doesn't exist. Invalid input");
                    return;
                }
                gpas[year-1] = value;
            }
        }

        //Indexer overloading in order to fetch the length of gpa array
        public int this[string len]
        {
            get { return gpas.Length; }
        }
    }
    class Photo
    {
        private string title;
        public string Title { get { return title; } }
        public Photo(string title)
        {
            this.title = title;
        }
    }
    class Album
    {
        Photo[] photos;
        public Album(int capacity)
        {
            photos = new Photo[capacity];
        }
        public Photo this[int index]
        {
            get
            {
                if(index < 0 || index >= photos.Length) 
                    throw new IndexOutOfRangeException();   
                else
                    return photos[index];
            }
            set
            {
                if (index < 0 || index >= photos.Length)
                    throw new IndexOutOfRangeException();
                else
                    photos[index] = value;
            }
        }
        public Photo this[string title]
        {
            get
            {
                foreach (Photo photo in photos)
                {
                    if (photo.Title == title)
                        return photo;
                }
                throw new Exception($"Photo with name {title} not found");
            }
        }

    }
}
