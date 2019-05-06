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


        public BlockModel(List<Block> blocks)
        {
            this.blocks = blocks;
        }

        public void setBlocksList (List<Block> blocks) {
            this.blocks = blocks;
        }

        public void checkIdStat(bool zuck)
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



                if (zuck)
                {
                    int columnNumber;
                    Console.WriteLine("Enter number of value to be checked.");
                    Console.WriteLine("1.- X coordinate");
                    Console.WriteLine("2.- Y coordinate");
                    Console.WriteLine("3.- Z coordinate");
                    Console.WriteLine("4.- Cost");
                    Console.WriteLine("5.- Value");
                    Console.WriteLine("6.- Rock Weight");
                    Console.WriteLine("7.- Ore Weight");
                    Console.WriteLine("8.- Total Weight");
                    string input = Console.ReadLine();
                    if (Int32.TryParse(input, out columnNumber))
                    {
                        Console.WriteLine();
                        if (columnNumber == 1) { Console.WriteLine("X coordinate is " + blockToBeChecked.x); }
                        if (columnNumber == 2) { Console.WriteLine("Y coordinate is " + blockToBeChecked.y); }
                        if (columnNumber == 3) { Console.WriteLine("Z coordinate is " + blockToBeChecked.z); }
                        if (columnNumber == 4) { Console.WriteLine("Cost is " + blockToBeChecked.stats["cost"]); }
                        if (columnNumber == 5) { Console.WriteLine("Value is " + blockToBeChecked.stats["value"]); }
                        if (columnNumber == 6) { Console.WriteLine("Rock Weight is " + blockToBeChecked.stats["rock_tonnes"]); }
                        if (columnNumber == 7) { Console.WriteLine("Ore Weight is " + blockToBeChecked.stats["ore_tonnes"]); }
                        if (columnNumber == 8) { Console.WriteLine("Total Weight is " + blockToBeChecked.weight); }
                    }
                }
                else
                {
                    int columnNumber;
                    Console.WriteLine("Enter number of value to be checked.");
                    Console.WriteLine("1.- X coordinate");
                    Console.WriteLine("2.- Y coordinate");
                    Console.WriteLine("3.- Z coordinate");
                    Console.WriteLine("4.- Weight");
                    Console.WriteLine("5.- Au");
                    Console.WriteLine("6.- Cu");
                    Console.WriteLine("7.- Proc Profit");
                    string input = Console.ReadLine();
                    if (Int32.TryParse(input, out columnNumber))
                    {
                        Console.WriteLine();
                        if (columnNumber == 1) { Console.WriteLine("X coordinate is " + blockToBeChecked.x); }
                        if (columnNumber == 2) { Console.WriteLine("Y coordinate is " + blockToBeChecked.y); }
                        if (columnNumber == 3) { Console.WriteLine("Z coordinate is " + blockToBeChecked.z); }
                        if (columnNumber == 4) { Console.WriteLine("Weight is " + blockToBeChecked.weight); }
                        if (columnNumber == 5) { Console.WriteLine("Au is " + blockToBeChecked.grades["au [ppm]"]); }
                        if (columnNumber == 6) { Console.WriteLine("Cu is " + blockToBeChecked.grades["cu %"]); }
                        if (columnNumber == 7) { Console.WriteLine("Proc Profit is " + blockToBeChecked.stats["proc_profit"]); }
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
                        Console.WriteLine("Press 1 for Ore Weight \nPress 2 Rock");
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
