using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CraftMine
{
    class FileManager
    {
        List<BlockModel> olderBlockModels = new List<BlockModel>();
        BlockModel blockModel;
            
        public void mainMenu()
        {
            Console.WriteLine("Hello and Welcome to CraftMine, a Notch above for your Map Crafting");
            Console.WriteLine("Please type the name of the .block file to Read (for example: marvin)");
            string path = Console.ReadLine();

            try
            {
                createBlockModel(path);
                showCommandMenu();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.Read();
            }
        }


        public void createBlockModel(string path)
        {
            List<Block> blocksFromFile = new List<Block>();
            Console.WriteLine("Loading file, this may take a moment.");
            int id;
            int x;
            int y;
            int z;
			int columnNumber = 0;
			bool firstLine = true;
			Dictionary<int, string> names = new Dictionary<int, string>();
			foreach (string line in File.ReadLines(path, Encoding.UTF8))
            {
                Dictionary<string, double> stats = new Dictionary<string, double>();
                string[] value = line.Split(' ');
				if (firstLine)
				{
					columnNumber = value.Length;
					firstLine = false;
					for(int i = 4; i<columnNumber; i++)
					{
						Console.WriteLine("Please give a name to column number " + i.ToString);
						string name = Console.ReadLine();
						names[i] = name;
					}
				}
                id = Convert.ToInt32(value[0]);
                x = Convert.ToInt32(value[1]);
                y = Convert.ToInt32(value[2]);
                z = Convert.ToInt32(value[3]);
				for (int i = 4; i<columnNumber; i++)
				{
					stats[names[i]] = Convert.ToDouble(value[i]);
				}
                blocksFromFile.Add(new Block(id, x, y, z, stats));
            }
            blockModel = new BlockModel(blocksFromFile, names);
        }

        public List<Block> Reblock(List<Block> blocks, int Rx, int Ry, int Rz)
        {
            olderBlockModels.Add(new BlockModel(blocks));
            List<Block> reBlockModel = new List<Block>();
            Dictionary<string, double> newGrades = new Dictionary<string, double>();
            Dictionary<string, double> newStats = new Dictionary<string, double>();
            int id = 1;
            double newWeight = 0;
            if (zuck)
            {
                double totalCost = 0;
                double totalValue = 0;
                double totalRock = 0;
                double totalOre = 0;
                foreach (Block block in blocks)
                {
                    if (block.x <= Rx && block.y <= Ry && block.z <= Rz)
                    {
                        newWeight += block.weight;
                        totalCost += block.stats["cost"];
                        totalValue += block.stats["value"];
                        totalRock += block.stats["rock_tonnes"];
                        totalOre += block.stats["ore_tonnes"];
                    }
                    else
                    {
                        reBlockModel.Add(new Block(id, block.x, block.y, block.z, block.weight, block.grades, block.stats));
                        id++;
                    }
                }
                newGrades["ore_grade"] = totalOre / newWeight;
                newStats["cost"] = totalCost;
                newStats["value"] = totalValue;
                newStats["rock_tonnes"] = totalRock;
                newStats["ore_tonnes"] = totalOre;
            }
            else
            {
                double totalAu = 0;
                double totalCu = 0;
                double totalProfit = 0;
                foreach (Block block in blocks)
                {
                    if (block.x <= Rx && block.y <= Ry && block.z <= Rz)
                    {
                        newWeight += block.weight;
                        totalAu += block.stats["au [ppm]"];
                        totalCu += block.stats["cu %"];
                        totalProfit += block.stats["proc_profit"];
                    }
                    else
                    {
                        reBlockModel.Add(new Block(id, block.x, block.y, block.z, block.weight, block.grades, block.stats));
                        id++;
                    }
                }
                newGrades["au [ppm]"] = totalAu;
                newGrades["cu %"] = totalCu;
                newStats["proc_profit"] = totalProfit;
            }
            

            reBlockModel.Add(new Block(0, Rx, Ry, Rz, newWeight, newGrades, newStats));

            return reBlockModel;
        }

        public void showCommandMenu()
        {
            while (true)
            {
                Console.WriteLine("Please select your next command:");
                Console.WriteLine("Press 1 to check stats with the ID \nPress 2 to check General Statistics \nPress 3 to Reblock \nPress 4 to Exit");
                string selection = Console.ReadLine();
                int intSelection;
                try
                {
                    Int32.TryParse(selection, out intSelection);
                    if (intSelection == 1)
                    {
                        blockModel.checkIdStat(zuck);
                    }
                    else if (intSelection == 2)
                    {
                        blockModel.checkGeneralStatistics(zuck);
                    }
                    else if (intSelection == 3)
                    {
                        Console.WriteLine("Please Select X");
                        int Rx;
                        Int32.TryParse(Console.ReadLine(), out Rx);
                        Console.WriteLine("Please Select Y");
                        int Ry;
                        Int32.TryParse(Console.ReadLine(), out Ry);
                        Console.WriteLine("Please Select Z");
                        int Rz;
                        Int32.TryParse(Console.ReadLine(), out Rz);
                        blockModel.setBlocksList(Reblock(blockModel.blocks, Rx, Ry, Rz));
                    }
                    else
                    {
                        break;
                    }

                }
                catch (Exception e)
                {

                }
            }
        }






    }
}
