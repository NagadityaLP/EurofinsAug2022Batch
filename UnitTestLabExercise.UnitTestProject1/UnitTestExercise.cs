using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestLabLibrary;
using System;

namespace UnitTestLabExercise.UnitTestProject1
{
    [TestClass]
    public class UnitTestExercise
    {
        [TestMethod]
        public void LoopBody_Test_WithZeroIterations()
        {
            SimpleLoopTest simpleLoopTest = new SimpleLoopTest();
            //Arrange
            int expected = 0;
            //Act
            int actual = simpleLoopTest.findSum(0);
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void LoopControlTest_WithNegative_LoopControlVariable()
        {
            SimpleLoopTest simpleLoopTest = new SimpleLoopTest();
            //Arrange
            int expected = 0;
            //Act
            int actual = simpleLoopTest.findSum(-1);
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void LoopBody_Test_WithOneIteration()
        {
            SimpleLoopTest simpleLoopTest = new SimpleLoopTest();
            //Arrange
            int expected = 5;
            //Act
            int actual = simpleLoopTest.findSum(1);
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void LoopBody_Test_WithTwoIterations()
        {
            SimpleLoopTest simpleLoopTest = new SimpleLoopTest();
            int expected = 5;
            int actual = simpleLoopTest.findSum(2);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void LoopBody_Test_WithSevenIterations()
        {
            SimpleLoopTest simpleLoopTest = new SimpleLoopTest();
            int expected = 18;
            int actual = simpleLoopTest.findSum(7);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void LoopBody_Test_WithNineIterations()
        {
            SimpleLoopTest simpleLoopTest = new SimpleLoopTest();
            int expected = 26;
            int actual = simpleLoopTest.findSum(9);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void LoopBody_Test_WithMaximumNumberOfIterations()
        {
            SimpleLoopTest simpleLoopTest = new SimpleLoopTest();
            int expected = 36;
            int actual = simpleLoopTest.findSum(10);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void LoopBody_Test_WithMoreThanMaximumNumberOfIterations()
        {
            SimpleLoopTest simpleLoopTest = new SimpleLoopTest();
            int expected = 0;
            int actual = simpleLoopTest.findSum(11);
            Assert.AreEqual(expected, actual);
        }
    }

}
