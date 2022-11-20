using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyOrders_02
{
    internal class Factory
    {
        public static Dictionary<string, string> map;
        Company company;
        static Factory()
        {
            map = new Dictionary<string, string>();    
        }
        public static void Addkey(string country, string taxSystem)
        {
            map.Add(country, taxSystem);   
        }
        public static ITaxCalculator GetLocation(string location)
        {
            if (map[location] == "GST") { 
                return new GSTCalc();
            }
            else { 
                return new VatCalc();
            }
        }
        public static double CalculatePayableAmount(double amount, string location)
        {
            ITaxCalculator tax =  GetLocation(location);
            return amount + tax.TaxCalculate(amount);
        }
        
    }
}
