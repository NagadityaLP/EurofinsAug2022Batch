using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace CalculatorLibrary.UnitTestProject
{
    
    



    [TestClass]
    public class CalculatorUnitTest
    {
        Calculator target = null;
        Mock<ICalculatorRepository> mock;

       [TestInitialize]
        public void Init()
        {
            mock = new Mock<ICalculatorRepository>();
        }








        [TestMethod]
        public void Sum_WithValidInput_ShouldGiveValidResult() //Test case
        {
            // do not write
            // conditional statements
            // looping
            // try catch block

            //write simple plain statements
            //Follow AAA approach
            // A - Arrange
            int a = 10;
            int b = 10;
            int expected = 20;
            // A - Act
            int actual = Calculator.Sum(a, b);
            // A - Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Sum_WithZeroInput_ThrowsExp()
        {
            Calculator.Sum(0, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Sum_WithNegativeInput_ThrowsExp()
        {
            Calculator.Sum(-1, -1);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Sum_WithOddInput_ThrowsExp()
        {
            Calculator.Sum(3, 7);
        }
    }
}

