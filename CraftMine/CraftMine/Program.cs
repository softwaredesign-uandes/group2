using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CraftMine
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello and Welcome to CraftMine, a Notch above for your Map Crafting");
            Console.WriteLine("Please type the name of the .block file to Read (for example: marvin.blocks)");
            string path = Console.ReadLine();

            try
            {
                string[] lines = File.ReadAllLines(path, Encoding.UTF8);
                String[][] data = new String[lines.Length][];
                Console.WriteLine("Loading file, this may take a moment.");
                for (int i=0; i<lines.Length; i++)
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
                Console.WriteLine(columnDetails[]);

                checkIdStat(columnDetails, data);
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
            Console.Read();
        }
    }
}
