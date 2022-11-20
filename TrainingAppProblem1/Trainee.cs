using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingAppProblem1
{
    internal class Trainee
    {
        public string TraineeName { get; set; }
        Trainer t;
        List<Training> trainings { get; set; }
        public Trainee()
        {
            t = new Trainer();
            trainings = new List<Training>();
        }
    }
}
