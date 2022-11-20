using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingAppProblem1
{
    internal class Organization
    {
        private string name;
        public List<Trainer> trainers { get; set; } 
        
        public Organization()
        {
            trainers = new List<Trainer>();
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
