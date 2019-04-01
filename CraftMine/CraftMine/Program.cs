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
            Console.WriteLine(path);

            try
            {
                string[] lines = File.ReadAllLines(path, Encoding.UTF8);
                String[][] data = new String[lines.Length][];
                for (int i=0; i<lines.Length; i++)
                {
                    data[i] = lines[i].Split();
                    foreach (string pnt in data[i])
                    {
                        Console.Write(pnt + ' ');
                    }
                    Console.WriteLine();
                }
                Console.WriteLine(path + " file received.");
                Console.WriteLine("Press Enter key to close...");
                Console.Read();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.Read();
            }
        }
    }
}
