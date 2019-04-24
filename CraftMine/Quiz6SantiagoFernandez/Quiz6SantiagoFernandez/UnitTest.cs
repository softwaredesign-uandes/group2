
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Quiz6SantiagoFernandez
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SumTest()
        {
            //arrange
            string listOfNumbers = "1,3,2,-1";
            string delimeter = ",";
            int expectedAnswer = 6;

            TestSum testSum = new TestSum();

            //act
            int answer = testSum.sum();

            //assert
            Assert.AreEqual(expectedAnswer, answer);
        }
    }
}
