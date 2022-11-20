using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TrainingAppProblem1
{
    internal class Course
    {
        List<Training> trainings { get; set; } 
        List<Module> modules { get; set; } 
        public Course()
        {
            trainings = new List<Training>();
            modules = new List<Module>();
        }
        public List<Module> getModules()
        {
            return modules;
        }
        
    }
}
