
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace CraftMineTest
{
    [TestClass]
    public class UnitTest1
    {



        [TestMethod]
        public void lenghtMethod()
        {
            //arrange
            string path = "zuck_small.blocks";
            dataManager dataManager = new dataManager(path);
            int totalLenght = 9400;

            //act
            int lenght = dataManager.checkLenght(dataManager.data);

            //assert
            Assert.AreEqual(totalLenght, lenght);
        }


        [TestMethod]
        public void totalWeight()
        {
            //arrange
            string path = "zuck_small.blocks";
            dataManager dataManager = new dataManager(path);
            double expectedWeight = 576129709.306195;

            //act
            double weight = dataManager.checkTotalWeight(dataManager.data, 5);

            //assert
            Assert.AreEqual(expectedWeight, weight);
        }

        [TestMethod]
        public void statCheckWithID()
        {
            //arrange
            string path = "zuck_small.blocks";
            dataManager dataManager = new dataManager(path);
            double expectedValue = 148258.148;

            //act
            double value = dataManager.checkIdStat(dataManager.data, 1, 5);

            //assert
            Assert.AreEqual(expectedValue, value);
        }
    }
}
