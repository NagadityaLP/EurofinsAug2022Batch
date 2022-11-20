using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorDataLayer
{
    public class CalculatorFileRepositor
    {
        public bool Save(string input)
        {
            StreamWriter sw = new StreamWriter("calculator.txt", true);
            sw.WriteLine(input);
            sw.Close();
            return true;
        }
    }
}
