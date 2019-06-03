using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CraftMine
{
    class FileManager
    {
        BlockModel blockModel;
            
        public void MainMenu()
        {
            Console.WriteLine("Hello and Welcome to CraftMine, a Notch above for your Map Crafting");
            Console.WriteLine("Please type the name of the .block file to Read (for example: marvin)");
            string path = Console.ReadLine();

            try
            {
                CreateBlockModel(path);
                showCommandMenu();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.Read();
            }
        }


        public void CreateBlockModel(string path)
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
						Console.WriteLine("Please give a name to column number " + i.ToString());
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
            blockModel = new BlockModel(MineralContainer.getNextBlockModelID(),blocksFromFile, names);
        }

		public void CreateBlockModelFromSheet(string[] headers, List<double[]> values)
		{
			List<Block> blocksFromFile = new List<Block>();
			Console.WriteLine("Loading file, this may take a moment.");
			int id;
			int x;
			int y;
			int z;
			int columnNumber = headers.Length;
			Dictionary<int, string> names = new Dictionary<int, string>();
			int key = 0;
			foreach (string name in headers){
				if (key > 3)
				{
					names[key] = headers[key];
				}
				key++;
			}
			foreach (double[] value in values)
			{
				Dictionary<string, double> stats = new Dictionary<string, double>();
				id = Convert.ToInt32(value[0]);
				x = Convert.ToInt32(value[1]);
				y = Convert.ToInt32(value[2]);
				z = Convert.ToInt32(value[3]);
				for (int i = 4; i < columnNumber; i++)
				{
					stats[names[i]] = Convert.ToDouble(value[i]);
				}
				blocksFromFile.Add(new Block(id, x, y, z, stats));
			}
			blockModel = new BlockModel(MineralContainer.getNextBlockModelID(), blocksFromFile, names);
			showCommandMenu();
		}

		public List<Block> Reblock(List<Block> blocks, int Rx, int Ry, int Rz)
        {
            List<Block> reBlockModel = new List<Block>();
            Dictionary<int, int> operations = new Dictionary<int, int>();
            Dictionary<string, double> newStats = new Dictionary<string, double>();
            int id = 1;
			int intSelection = 0;
			foreach (KeyValuePair<int, string> name in blockModel.names)
			{
				Console.WriteLine("Seleccione 1 si esta columna se suma o 2 si esta columna se promedia " + name.Value);
				newStats[name.Value] = 0;
				string selection = Console.ReadLine();
				try
				{
					Int32.TryParse(selection, out intSelection);
					if (intSelection == 1)
					{
						operations[name.Key] = 1;
					}
					else if (intSelection == 2)
					{
						operations[name.Key] = 2;
					}
				}
				catch (Exception e)
				{
					Console.WriteLine(e.ToString());
					Console.Read();
				}
			}
			int numberOfBlocks = 0;
			foreach (Block block in blocks)
            {
                if (block.x <= Rx && block.y <= Ry && block.z <= Rz)
                {
                    foreach (KeyValuePair<int, string> name in blockModel.names)
					{
						if(operations[name.Key] == 1)
						{
							newStats[name.Value] += block.stats[name.Value];
						}
						if (operations[name.Key] == 2)
						{
							newStats[name.Value] += block.stats[name.Value];
							numberOfBlocks++;
						}
					}
                }
                else
                {
                    reBlockModel.Add(new Block(id, block.x, block.y, block.z, block.stats));
                    id++;
                }
            }
			foreach (KeyValuePair<int, string> name in blockModel.names)
			{
				if (operations[name.Key] == 2)
				{
					newStats[name.Value] = newStats[name.Value] / numberOfBlocks;
				}
			}

			reBlockModel.Add(new Block(0, Rx, Ry, Rz, newStats));

            return reBlockModel;
        }

		public List<Block> VirtualReblock(List<Block> blocks, int Rx, int Ry, int Rz)
		{
			List<Block> oldBlocks = new List<Block>();
			List<Block> reBlockModel = new List<Block>();
			Dictionary<int, int> operations = new Dictionary<int, int>();
			Dictionary<string, double> newStats = new Dictionary<string, double>();
			int id = 1;
			int intSelection = 0;
			foreach (KeyValuePair<int, string> name in blockModel.names)
			{
				Console.WriteLine("Seleccione 1 si esta columna se suma o 2 si esta columna se promedia " + name.Value);
				newStats[name.Value] = 0;
				string selection = Console.ReadLine();
				try
				{
					Int32.TryParse(selection, out intSelection);
					if (intSelection == 1)
					{
						operations[name.Key] = 1;
					}
					else if (intSelection == 2)
					{
						operations[name.Key] = 2;
					}
				}
				catch (Exception e)
				{
					Console.WriteLine(e.ToString());
					Console.Read();
				}
			}
			int numberOfBlocks = 0;
			foreach (Block block in blocks)
			{
				if (block.x <= Rx && block.y <= Ry && block.z <= Rz)
				{
					oldBlocks.Add(block);
					foreach (KeyValuePair<int, string> name in blockModel.names)
					{
						if (operations[name.Key] == 1)
						{
							newStats[name.Value] += block.stats[name.Value];
						}
						if (operations[name.Key] == 2)
						{
							newStats[name.Value] += block.stats[name.Value];
							numberOfBlocks++;
						}
					}
				}
				else
				{
					reBlockModel.Add(new Block(id, block.x, block.y, block.z, block.stats));
					id++;
				}
			}
			foreach (KeyValuePair<int, string> name in blockModel.names)
			{
				if (operations[name.Key] == 2)
				{
					newStats[name.Value] = newStats[name.Value] / numberOfBlocks;
				}
			}

			reBlockModel.Add(new VirtualBlock(0, Rx, Ry, Rz, newStats, oldBlocks));

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
                        blockModel.checkIdStat();
                    }
                    else if (intSelection == 2)
                    {
                        blockModel.checkGeneralStatistics();
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
