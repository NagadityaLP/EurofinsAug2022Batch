using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingAppProblem1
{
    internal class Training
    {
        public string TrainingName { get; set; }
        Trainer trainer;
        public List<Trainee> trainees { get; set; }
        Course course;

        public Training()
        {
            trainer = new Trainer();
            trainees  = new List<Trainee>();
            course = new Course();
        }
        public int getNumOfTrainees()
        {
            return trainer.trainees.Count;
        }
        public string getTrainingOrganizationName()
        {
            return trainer.getOrganization(trainer.organization);
        }
        public int getTrainingDurationInHrs()
        {
            int durationHrs = 0;
            foreach (Module module in course.getModules())
            {
                foreach(Unit unit in module.getUnits())
                {
                    durationHrs += unit.DurationHrs;
                }
            }
            return durationHrs;
        }
    }
}
