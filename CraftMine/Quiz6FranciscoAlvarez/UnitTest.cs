
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Quiz6FranciscoAlvarez
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void testAdd()
        {
            //arange
            string numbers = "1,2,3";
            int sum = 6;

            //act
            int final = Add(numbers);

            //assert
            Assert.AreEqual(sum, final);

        }
    }
}
