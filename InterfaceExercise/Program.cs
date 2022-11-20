using System;

namespace InterfaceExercise
{
    internal class InterfaceTest
    {
        static void Main(string[] args)
        {
            Employee[] employees = new Employee[8];
            employees[0] = new Programmer("Raju", 25000, 2.5);
            employees[1] = new Programmer("Abhinav", 35000, 2.7);
            employees[2] = new Manager("Rishikesh", 55000, "Prerana");
            employees[3] = new Intern("Rajesh", 28000, 4);
            employees[4] = new Programmer("Sanju", 30000, 4);
            employees[5] = new Manager("Preeti", 62000, "Ranjitha");
            employees[6] = new Programmer("Siri", 43000, 4);
            employees[7] = new Intern("Anu", 36000, 6);

            foreach (Employee employee in employees)
            {
                employee.Print();
                if(employee is IPromoteable)
                {
                    if(employee is Programmer)
                    {
                        Programmer p = (Programmer)employee;
                        p.Promote();
                    }
                    else
                    {
                        IPromoteable e = (Manager)employee;
                        e.Promote();
                        IGoodStudent g = (Manager)employee;
                        g.Promote();
                    }
                }
            }
        }
    }
    abstract class Employee
    {
        protected string name;
        protected double salary;
        protected Employee(string name, double salary)
        {
            this.name = name;
            this.salary = salary;
        }
        public virtual void Print()
        {
            Console.WriteLine($"Employee name : {name}");
            Console.WriteLine($"{name}'s salary : {salary}");
        }
    }
    class Programmer : Employee, IPromoteable
    {
        protected double averageOT;
        public Programmer(string name, double salary, double averageOT)
            : base(name, salary)    
        {
            this.averageOT = averageOT;
        }
        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Average Overtime : {averageOT}");
        }
        public void Promote()
        {
            salary *= 1.1;
            Console.WriteLine($"Programmer got promoted and his new salary is Rs. {salary}\n");
        }
    }
    class Manager : Employee, IPromoteable, IGoodStudent
    {
        protected string secretaryName;
        public Manager(string name, double salary, string secretaryName)
             : base(name, salary)
        {
            this.secretaryName = secretaryName;
        }
        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Manager's secretary name is {secretaryName}");
        }
        void IPromoteable.Promote()
        {
            salary *= 1.5;
            Console.WriteLine($"Manager got promoted and his new salary is Rs. {salary}");
        }
        void IGoodStudent.Promote()
        {
            Console.WriteLine("Hello manager. Congratulations. You are a good student\n");
        }
    }
    class Intern : Employee
    {
        protected int lengthOfInternship;
        public Intern(string name, double salary, int lengthOfInternship)
            : base(name, salary)
        {
            this.lengthOfInternship = lengthOfInternship;
        }
        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Number of months of internship : {lengthOfInternship} \n");
        }
    }
    interface IPromoteable
    {
        void Promote();
    }
    interface IGoodStudent
    {
        void Promote();
    }
}
