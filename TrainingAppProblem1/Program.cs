using System;
using System.Collections.Generic;

namespace TrainingAppProblem1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Organization organization = new Organization() { Name = "Eurofins"} ;
            Trainer trainer = new Trainer() { TrainerName = "Venkat"};
            organization.trainers.Add(trainer);
            Training training = new Training() { TrainingName = "Pratian Technologies"};
            Trainee trainee = new Trainee() { TraineeName = "Aditya"};
            Console.WriteLine($"Trainer's organization name : {trainer.getOrganization(organization)}");
            Console.WriteLine($"Trainer name : {trainer.TrainerName}");
            Console.WriteLine($"Training organization name : {training.TrainingName}");
            Console.WriteLine($"Trainee's name : {trainee.TraineeName}");
            trainer.trainees.Add(trainee);
            trainer.trainings.Add(training);
            training.trainees.Add(trainee);

        }
    }
    /*class Organization
    {
        private string name;
        public List<Trainer> trainers { get; set; } = new List<Trainer>();
        public string Name 
        { 
            get { return name; } 
            set { name = value; } 
        }
    }
    class Trainer 
    {
        public List<Trainee> trainees = new List<Trainee>();
        public List<Training> trainings = new List<Training>();
        Organization organization = new Organization();
        public string getOrganization()
        {
            return organization.Name;
        }
    }
    class Training
    {
        Trainer trainer = new Trainer();
        List<Trainee> trainees { get; set; } = new List<Trainee>();

        Course course = new Course();
        public int getNumOfTrainees()
        {
            return trainer.trainees.Count;
        }
        public string getTrainingOrganizationName()
        {
            return trainer.getOrganization();
        }
        public int getTrainingDurationInHrs()
        {
            return course.CourseDurationHrs();
        }
    }
    class Trainee
    {
        Trainer t = new Trainer();
        List<Training> trainings { get; set; } = new List<Training>();
    }
    class Course
    {
        List<Training> trainings { get; set; } = new List<Training>();
        List<Module> modules { get; set; } = new List<Module>();
        public List<Module> getModules()
        {
           return modules;
        }
        public int CourseDurationHrs()
        {
            int courseDuration = 0;
            foreach (Module modules in modules)
                courseDuration += modules.ModuleDurationHrs();
            return courseDuration;
        }
    }
    class Module 
    {
        Course course = new Course();
        List<Unit> units = new List<Unit>();
        public List<Unit> getUnits()
        {
            return units;
        }
        public int ModuleDurationHrs()
        {
            int moduleDuration = 0;
            foreach (Unit unit in units)
                moduleDuration += unit.DurationHrs;
            return moduleDuration;
        }
    }
    class Unit 
    {
        private int durationHrs;
        Module module = new Module();
        List<Topic> topics = new List<Topic>();
        public int DurationHrs
        {
            get { return durationHrs; }
            set { durationHrs = value; }
        }
    }
    class Topic
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }*/
}
