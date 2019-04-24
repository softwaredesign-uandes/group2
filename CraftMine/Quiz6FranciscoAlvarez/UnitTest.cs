
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quiz6FranciscoAlvarez;

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
            char delimiter = ',';
            Mathemagic magic = new Mathemagic();

            //act
            int final = magic.Add(delimiter, numbers);

            //assert
            Assert.AreEqual(sum, final);
        }
    }
}
