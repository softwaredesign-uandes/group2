using System;
using System.IO;
using System.Text;

namespace CraftMine
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello and Welcome to CraftMine, a Notch above for your Map Crafting");
            Console.WriteLine("Please type the name of the .block file to Read (for example: marvin.blocks");

            string firstFile = Console.ReadLine();

            using (FileStream fs = File.Open(firstFile, FileMode.Open))
            {

            }
        }
    }
}
