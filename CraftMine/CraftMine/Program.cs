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

                foreach (string line in lines)
                {

                    Console.WriteLine(line);
                }
                Console.Read();
            }
            catch (Exception e)
            {
                Console.WriteLine("File not Found", e.ToString());
            }
        }
    }
}
