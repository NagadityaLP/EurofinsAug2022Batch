using System;


namespace Static_Exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student("Aditya", 18);
            Student student1 = new Student("Indira", 19);
            Student student2 = new Student("Archana", 20);
            Student student3 = new Student("Ananya", 21);
            Student student4 = new Student("Master", 22);

            Console.WriteLine($"Minimum of 3 and 5 is {MathUtils.Min(3, 5)}");
            Console.WriteLine($"Maximum of 3 and 5 is {MathUtils.Max(3, 5)}");

        }
    }
    class Student
    {
        string name;
        int age;
        int idNumber;
        static int nextId;
        public Student(string name, int age)
        {
            this.name = name;
            this.age = age;
            this.idNumber = Student.nextId;
            nextId += 1;
            Console.WriteLine($"ID number of {this.name} is {this.idNumber}");
        }   
        static Student()
        {
            nextId = 1;
        }
        
    }
    class MathUtils
    {
        public static int Min(int a, int b)
        {
            return (a < b)? a : b;
        }
        public static int Max(int a, int b)
        {
            return (a > b) ? a : b;
        }
    }
}
