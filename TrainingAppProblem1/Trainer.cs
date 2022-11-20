using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingAppProblem1
{
    internal class Trainer
    {
        public string TrainerName { get; set; }
        public List<Trainee> trainees;
        public List<Training> trainings;
        public Organization organization;
        public Trainer()
        {
            trainees = new List<Trainee>();
            trainings = new List<Training>();
            /*organization = new Organization(org.Name);*/
        }
        public string getOrganization(Organization org)
        {
            return org.Name;
        }
    }
}
