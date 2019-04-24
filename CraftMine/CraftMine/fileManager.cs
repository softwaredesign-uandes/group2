using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CraftMine
{
    class FileManager
    {

        public void mainMenu()
        {
            Console.WriteLine("Hello and Welcome to CraftMine, a Notch above for your Map Crafting");
            Console.WriteLine("Please type the name of the .block file to Read (for example: marvin.blocks)");
            string path = Console.ReadLine();

            try
            {
                string[] lines = File.ReadAllLines(path, Encoding.UTF8);
                String[][] data = new String[lines.Length][];
                Console.WriteLine("Loading file, this may take a moment.");
                for (int i = 0; i < lines.Length; i++)
                {
                    data[i] = lines[i].Split();
                }
                Console.WriteLine(path + " file received.");
                Console.WriteLine();
                Console.WriteLine("Enter the column details.");
                string[] columnDetails = { "id", "x", "y", "z" };
                string detailInput = Console.ReadLine();
                string[] endDetails = detailInput.Split(' ');

                while (columnDetails.Length + endDetails.Length != data[0].Length)
                {
                    Console.WriteLine("Details do not match data column amount.");
                    Console.WriteLine("Enter the column details.");
                    detailInput = Console.ReadLine();
                    columnDetails = detailInput.Split(' ');

                }

                Array.Resize<string>(ref columnDetails, 4 + endDetails.Length);
                Array.Copy(endDetails, 0, columnDetails, 4, endDetails.Length);
                Console.WriteLine(columnDetails);

                while (true)
                {
                    Console.WriteLine("Please select your next command:");
                    Console.WriteLine("Press 1 to check stats with the ID \nPress 2 to check General Statistics \nPress 3 to Exit");
                    string selection = Console.ReadLine();
                    int intSelection;
                    try
                    {
                        Int32.TryParse(selection, out intSelection);
                        if (intSelection == 1)
                        {
                            checkIdStat(columnDetails, data);
                        }
                        else if (intSelection == 2)
                        {
                            checkGeneralStatistics(columnDetails, data);
                        }
                        else if (intSelection == 3)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Wrong Input");
                        }

                    }
                    catch (Exception e)
                    {

                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.Read();
            }
        }

        static void checkIdStat(string[] columns, string[][] data)
        {
            int id = 0;
            int counter = 0;
            Console.WriteLine();
            Console.WriteLine("Enter id to be checked.");
            string idText = Console.ReadLine();
            Console.WriteLine();
            if (Int32.TryParse(idText, out id))
            {
                foreach (string column in columns)
                {
                    Console.WriteLine("Press " + counter + " for " + column);
                    counter++;
                }
            }
            int columnNumber = 0;
            string input = Console.ReadLine();
            if (Int32.TryParse(input, out columnNumber))
            {
                Console.WriteLine();
                Console.Write("Result: ");
                Console.Write(columns[columnNumber] + " = " + data[id][columnNumber]);
            }
            Console.ReadLine();
        }

        static void checkGeneralStatistics(string[] columns, string[][] data)
        {
            int selection = 0;
            int counter = 0;
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
                    Console.WriteLine("There are " + data.Length + " number of blocks");
                }
                else if (selection == 2)
                {
                    double totalWeight = 0;
                    Console.WriteLine("Select which of this values is the Mineral Deposit you wish to count.");
                    foreach (string column in columns)
                    {
                        Console.WriteLine("Press " + counter + " for " + column);
                        counter++;
                    }
                    int columnNumber = 0;
                    string input = Console.ReadLine();
                    if (Int32.TryParse(input, out columnNumber))
                    {
                        Console.WriteLine();
                        for (int id = 0; id < data.Length; id++)
                        {
                            totalWeight += Convert.ToDouble(data[id][columnNumber]);
                        }
                    }
                    Console.Write("Total Weight: " + totalWeight);
                }
                else if (selection == 3)
                {
                    double totalWeight = 0;
                    while (true)
                    {
                        counter = 0;
                        Console.WriteLine("Select which of this values are the Mineral Deposit you wish to count.");
                        foreach (string column in columns)
                        {
                            Console.WriteLine("Press " + counter + " for " + column);
                            counter++;
                        }
                        Console.WriteLine("Press " + counter + "to get the value");
                        int columnNumber = 0;
                        string input = Console.ReadLine();
                        if (Int32.TryParse(input, out columnNumber))
                        {
                            if (columnNumber == counter)
                            {
                                break;
                            }
                            Console.WriteLine();
                            for (int id = 0; id < data.Length; id++)
                            {
                                totalWeight += Convert.ToDouble(data[id][columnNumber]);
                            }
                            Console.WriteLine("If there are more Mineral Deposits add them.");
                        }
                    }
                    Console.Write("Total Weight: " + totalWeight);
                }
                else if (selection == 4)
                {
                    double airPercentage = 0;
                    double value = 0;
                    Console.WriteLine("Select which of this values has the Air statistics");
                    foreach (string column in columns)
                    {
                        Console.WriteLine("Press " + counter + " for " + column);
                        counter++;
                    }
                    int columnNumber = 0;
                    string input = Console.ReadLine();
                    if (Int32.TryParse(input, out columnNumber))
                    {
                        Console.WriteLine();
                        for (int id = 0; id < data.Length; id++)
                        {

                            value = Convert.ToDouble(data[id][columnNumber]);
                            if (value == 0)
                            {
                                airPercentage++;
                            }
                        }
                    }
                    airPercentage = airPercentage / data.Length;
                    Console.Write("Air Percentage: " + airPercentage + " %");
                }
                else
                {
                    Console.WriteLine("Wrong Input");
                }
            }

            Console.ReadLine();
        }

        public string[][] reblock(string[][] data, int Rx, int Ry, int Rz)
        {
            string[][] put = new string[1][];
            put[0][0] = "0";
            return data;
        }



    }
}
