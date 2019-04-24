
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace testReblock
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestReblock()
        {
            //arrange
            FileManager fileManager = new FileManager();
            String[][] data = new String[10][];
            int counter = 0;
            int counterX = 0;
            int counterY = 0;
            int counterZ = 0;
            for (int i = 0; i < 5; i++)
            {
                data[i][0] = counter.ToString();
                counter++;
                data[i][1] = counterX.ToString();
                counterX++;
                data[i][2] = counterY.ToString();
                data[i][3] = counterZ.ToString();
                data[i][4] = "10";
                data[i][5] = "10";
                data[i][6] = "10";
                data[i][7] = "10";
                data[i][8] = "10";
                data[i][9] = "10";
                for (int j = 0; j < 5; j++)
                {
                    data[j][0] = counter.ToString();
                    counter++;
                    data[j][1] = counterX.ToString();
                    data[j][2] = counterY.ToString();
                    counterY++;
                    data[j][3] = counterZ.ToString();
                    data[j][4] = "10";
                    data[j][5] = "10";
                    data[j][6] = "10";
                    data[j][7] = "10";
                    data[j][8] = "10";
                    data[j][9] = "10";
                    for (int k = 0; k < 5; k++)
                    {
                        data[k][0] = counter.ToString();
                        counter++;
                        data[k][1] = counterY.ToString();
                        data[k][2] = counterY.ToString();
                        data[k][3] = counterZ.ToString();
                        counterZ++;
                        data[k][4] = "10";
                        data[k][5] = "10";
                        data[k][6] = "10";
                        data[k][7] = "10";
                        data[k][8] = "10";
                        data[k][9] = "10";
                    }
                }
                
            }
            String[][] oldData = new String[1][];
            oldData[0][1] = counterY.ToString();
            oldData[0][2] = counterY.ToString();
            oldData[0][3] = counterZ.ToString();
            oldData[0][4] = "10";
            oldData[0][5] = "10";
            oldData[0][6] = "10";
            oldData[0][7] = "10";
            oldData[0][8] = "10";
            oldData[0][9] = "10";
            int Rx = 5;
            int Ry = 5;
            int Rz = 5;

            //act
            string[][] newData = fileManager.reblock(data, Rx, Ry, Rz);

            //assert
            Assert.AreEqual(newData, oldData);

        }
    }
}
