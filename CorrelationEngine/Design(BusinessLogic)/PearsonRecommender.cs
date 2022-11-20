using System;
using System.Collections.Generic;
using System.Linq;

namespace CorrelationEngine.Design
{
    public class PearsonRecommender : IRecommender
    {
        public double GetCorrelation(List<int> baseData, List<int> otherData)
        {

            //if other data array length is less than the base data length, add 1 in required places to make other data array length equal to base data length
            if (otherData.Count < baseData.Count)
            {
                int i = baseData.Count - otherData.Count;
                int j = otherData.Count;
                while (i > 0)
                {
                    otherData.Add(1);
                    baseData[i + j - 1] += 1;
                    i--;
                }
            }

            //if other data array length is greater than base data length, then trim the extra elements in other data array
            else if (otherData.Count > baseData.Count)
            {
                int i = otherData.Count - baseData.Count;
                int j = baseData.Count;
                while (i > 0)
                {
                    otherData.RemoveAt(j);
                    i--;
                }
            }

            //At this point, length of both x and y will be equal
            int listLength = baseData.Count;
            for (int i = 0; i < listLength; i++)
            {   //if any entry is zero, add 1 to both the lists
                if (baseData[i] == 0 || otherData[i] == 0)
                {
                    baseData[i] += 1;
                    otherData[i] += 1;
                }
            }

            //creating lists for storing xy, x^2, y^2
            List<long> product = new List<long>();
            List<long> baseDataSquare = new List<long>();
            List<long> otherDataSquare = new List<long>();

            //calculating xy, x^2, y^2
            for (int i = 0; i < listLength; i++)
            {
                product.Add(baseData[i] * otherData[i]);
                baseDataSquare.Add(baseData[i] * baseData[i]);
                otherDataSquare.Add(otherData[i] * otherData[i]);
            }

            //calculating sum of each column
            long baseDataSum = baseData.Sum();
            long otherDataSum = otherData.Sum();
            long productSum = product.Sum();
            long baseDataSquareSum = baseDataSquare.Sum();
            long otherDataSquareSum = otherDataSquare.Sum();

            //Applying pearson's formula
            long num = (listLength * productSum) - (baseDataSum * otherDataSum);
            long den = ((listLength * baseDataSquareSum) - (baseDataSum * baseDataSum)) * ((listLength * otherDataSquareSum) - (otherDataSum * otherDataSum));
            double sqrtDen = Math.Sqrt(den);
            double pearsonCorrelationCoefficient = (double)num / sqrtDen;

            return pearsonCorrelationCoefficient;

        }
    }
}
