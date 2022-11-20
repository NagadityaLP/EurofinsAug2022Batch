using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingAppProblem1
{
    internal class Module
    {
        Course course;
        List<Unit> units;
        public Module()
        {
            course = new Course();
            units = new List<Unit>();
        }
        public List<Unit> getUnits()
        {
            return units;
        }
    }
}
