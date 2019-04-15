using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CraftMineTest
{
    class dataManager
    {
        public string[][] data;

        public dataManager(string path)
        {
            string[] lines = File.ReadAllLines(path, Encoding.UTF8);
            String[][] data = new String[lines.Length][];
            for (int i = 0; i < lines.Length; i++)
            {
                data[i] = lines[i].Split();
            }

            this.data = data;
         }


        public double checkIdStat(String[][] data, int id, int columnNumber)
        {
            int counter = 0;
                return Convert.ToDouble(data[id][columnNumber]);
        }


        public int checkLenght(String[][] data)
        {
            return Convert.ToInt32(data.Length);
        }

        public double checkTotalWeight(String[][] data, int columnNumber)
        {
            double totalWeight = 0;
            for (int id = 0; id < data.Length; id++)
            {
                totalWeight += Convert.ToDouble(data[id][columnNumber]);
            }
            return totalWeight;
        }
    }
}
