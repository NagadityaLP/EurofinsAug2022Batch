using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace PearsonRecommenderUnitTest
{
    [TestClass]
    public class PearsonRecommenderTest
    {
        [TestMethod]

        public void GetCorrelationValue_With_BothTheArray_LengthsEqual()
        {
            //A- 
            CorrelationEngine.Design.PearsonRecommender pr = new CorrelationEngine.Design.PearsonRecommender();
     
            int[] baseArr = new int[] { 20, 24, 17 };
            int[] otherArr = new int[] { 30, 20, 27 };


            //A - Actual
            double actual = pr.GetCorrelation(baseArr,otherArr);
            //A - Assert
            Assert.AreEqual(-0.7399, Math.Round(actual,4));
        }

        [TestMethod]
        public void GetCorrelationValue_With_OtherArrayLength_GreaterThan_BaseArrayLength()
        {
            //A- 
            CorrelationEngine.Design.PearsonRecommender pr = new CorrelationEngine.Design.PearsonRecommender();
     
            int[] baseArr = new int[] { 20, 24, 17 };
            int[] otherArr = new int[] { 30, 20, 27, 57, 70 };
            //A - Actual
            double actual = pr.GetCorrelation(baseArr,otherArr);
            //A - Assert
            Assert.AreEqual(Math.Round(actual, 4) , - 0.7399);
        }

        [TestMethod]
        public void GetCorrelationValue_With_OtherArrayLength_LesserThan_BaseArrayLength()
        {
            //A- 
            CorrelationEngine.Design.PearsonRecommender pr = new CorrelationEngine.Design.PearsonRecommender();

            int[] baseArr = new int[] { 20, 24, 17, 57, 70 };
            int[] otherArr = new int[] { 30, 20, 27 };
            //A - Actual
            double actual = pr.GetCorrelation(baseArr, otherArr);
            //A - Assert
            Assert.AreEqual(Math.Round(actual, 4), -0.9633);
        }

        [TestMethod]
        public void GetCorrelationValue_With_Zeros_In_Between()
        {
            //A- 
            CorrelationEngine.Design.PearsonRecommender pr = new CorrelationEngine.Design.PearsonRecommender();

            int[] baseArr = new int[] { 20, 24, 0, 57, 70 };
            int[] otherArr = new int[] { 30, 20, 27, 0, 8 };
            //A - Actual
            double actual = pr.GetCorrelation(baseArr, otherArr);
            //A - Assert
            Assert.AreEqual(Math.Round(actual, 4), -0.8931);
        }
    }
}
