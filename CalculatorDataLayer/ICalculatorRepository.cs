using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorDataLayer
{
    public interface ICalculatorRepository
    {
        bool Save(string input);
    }
}
