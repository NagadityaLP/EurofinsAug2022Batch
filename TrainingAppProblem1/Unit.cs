
using System.Collections.Generic;

namespace TrainingAppProblem1
{
    internal class Unit
    {
        private int durationHrs;
        Module module;
        List<Topic> topics;
        public Unit()
        {
            module = new Module();  
            topics = new List<Topic>();
        }
        public int DurationHrs
        {
            get { return durationHrs; }
            set { durationHrs = value; }
        }
    }
}
