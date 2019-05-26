using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using System.Threading.Tasks;

namespace CraftMine
{
    class BlockModel
    {
        public List<Block> blocks;
		public Dictionary<int, string> names;


		public BlockModel(List<Block> blocks, Dictionary<int, string> names)
        {
            this.blocks = blocks;
			this.names = names;
        }

        public void setBlocksList (List<Block> blocks) {
            this.blocks = blocks;
        }

        public void checkIdStat()
        {
            Block blockToBeChecked;
            int id;
            Console.WriteLine();
            Console.WriteLine("Enter id to be checked.");
            string idText = Console.ReadLine();
            Console.WriteLine();

            if (Int32.TryParse(idText, out id))
            {

                IEnumerable<Block> blockQuery = from block in blocks
                                                where block.id == id
                                                select block;
                blockToBeChecked = blockQuery.First();



                int columnNumber;
                Console.WriteLine("Enter number of value to be checked.");
				Console.WriteLine("1.- X Coordinate");
				Console.WriteLine("2.- Y Coordinate");
				Console.WriteLine("3.- Z Coordinate");
				int namesKey = 4;
				foreach string name in names{
					Console.WriteLine(namesKey.ToString + ".- " + name);
				}
				string input = Console.ReadLine();
                if (Int32.TryParse(input, out columnNumber))
                {
                    Console.WriteLine("The value is: ");
					if (input == 1) { Console.WriteLine(blockToBeChecked.x.ToString); }
					else if (input == 2) { Console.WriteLine(blockToBeChecked.y.ToString); }
					else if (input == 3) { Console.WriteLine(blockToBeChecked.z.ToString); }
					else
					{
						try
						{
							Console.WriteLine(blockToBeChecked.stats[names[input]].ToString)
						}
						catch (Exception e)
						{
							Console.WriteLine(e.ToString());
							Console.Read();
						}
					}
				}
            }
            Console.ReadLine();
        }

        public void checkGeneralStatistics(bool zuck)
        {
            int selection = 0;
            Console.WriteLine();
            Console.WriteLine("Please Select your next Command \nPress 1 for total Number of Blocks");
            Console.WriteLine("Press 2 for Total weight of the Mineral Deposit \nPress 3 for total weight of ALL mineral Deposit");
            Console.WriteLine("Press 4 for Air Percentage");
            string idText = Console.ReadLine();
            Console.WriteLine();
            if (Int32.TryParse(idText, out selection))
            {
                if (selection == 1)
                {
                    Console.WriteLine("There are " + blocks.Count() + " number of blocks");
                }
                else if (selection == 2)
                {
                    double totalWeight = 0;
                    if (zuck)
                    {
                        Console.WriteLine("Press 1 for Ore Weight \nPress 2 for Rock Weight");
                        if (Int32.TryParse(idText, out selection))
                        {
                            if (selection == 1)
                            {
                                foreach (Block block in blocks)
                                {
                                    totalWeight += block.stats["ore_tonnes"];
                                }
                            }
                            else
                            {
                                foreach (Block block in blocks)
                                {
                                    totalWeight += block.stats["rock_tonnes"];
                                }
                            }
                            
                        }
                        Console.Write("Total Weight: " + totalWeight);
                    }
                    else
                    {
                        foreach (Block block in blocks)
                        {
                            totalWeight += block.weight;
                        }
                        Console.Write("Total Weight: " + totalWeight);
                    }
                    
                }
                else if (selection == 3)
                {
                    double totalWeight = 0;
                    foreach (Block block in blocks)
                    {
                        totalWeight += block.weight;
                    }
                    Console.Write("Total Weight: " + totalWeight);
                }
                else if (selection == 4)
                {
                    double airPercentageBlocks = 0;
                    double value = 0;
                    foreach (Block block in blocks)
                    {
                        if (block.weight == 0) airPercentageBlocks++;
                    }
                    value = airPercentageBlocks / blocks.Count();
                    Console.Write("Air Percentage: " + value + " %");
                }
                else
                {
                    Console.WriteLine("Wrong Input");
                }
            }

            Console.ReadLine();
        }

    }
}
