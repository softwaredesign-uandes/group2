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
                Console.WriteLine("Loading file, this may take a moment.");
                for (int i=0; i<lines.Length; i++)
                {
                    data[i] = lines[i].Split();
                }
                Console.WriteLine(path + " file received.");
                Console.WriteLine();
                Console.WriteLine("Enter id to be checked.");
                string idText = Console.ReadLine();
                int id = 0;
                if(Int32.TryParse(idText, out id)) {
                    Console.WriteLine();
                    Console.WriteLine("Press x for <x> coordinates.");
                    Console.WriteLine("Press y for <y> coordinates.");
                    Console.WriteLine("Press z for <z> coordinates.");
                    if (path.Equals("zuck_small.block"))
                    {
                        Console.WriteLine("Press c for cost.");
                        Console.WriteLine("Press v for value.");
                        Console.WriteLine("Press r for rock_tonnes.");
                        Console.WriteLine("Press o for ore_tonnes.");
                    }
                    else if (path.Equals("marvin.blocks"))
                    {
                        Console.WriteLine("Press t for tonn.");
                        Console.WriteLine("Press a for au[ppm].");
                        Console.WriteLine("Press u for cu %.");
                        Console.WriteLine("Press p for proc_profit.");
                    }
                    string cord = Console.ReadLine();

                    Console.WriteLine();
                    Console.Write("Result: ");
                    if (cord.Equals("x"))
                    {
                        Console.Write(data[id][1]);
                    }
                    else if (cord.Equals("y"))
                    {
                        Console.Write(data[id][2]);
                    }
                    else if (cord.Equals("z"))
                    {
                        Console.Write(data[id][3]);
                    }
                    else if (cord.Equals("c") || cord.Equals("t"))
                    {
                        Console.Write(data[id][4]);
                    }
                    else if (cord.Equals("v") || cord.Equals("a"))
                    {
                        Console.Write(data[id][5]);
                    }
                    else if (cord.Equals("r") || cord.Equals("u"))
                    {
                        Console.Write(data[id][6]);
                    }
                    else if (cord.Equals("o") || cord.Equals("p"))
                    {
                        Console.Write(data[id][7]);
                    }
                    else
                    {
                        Console.WriteLine("Incorrect Input");
                    }
                    Console.Read();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.Read();
            }
        }
    }
}
