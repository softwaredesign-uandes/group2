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

		public void setBlocksList(List<Block> blocks)
		{
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
				foreach (KeyValuePair<int, string> name in names)
				{
					Console.WriteLine(name.Key.ToString() + ".- " + name.Value);
				}
				string input = Console.ReadLine();
				if (Int32.TryParse(input, out columnNumber))
				{
					Console.WriteLine("The value is: ");
					if (columnNumber == 1) { Console.WriteLine(blockToBeChecked.x.ToString()); }
					else if (columnNumber == 2) { Console.WriteLine(blockToBeChecked.y.ToString()); }
					else if (columnNumber == 3) { Console.WriteLine(blockToBeChecked.z.ToString()); }
					else
					{
						try
						{
							Console.WriteLine(blockToBeChecked.stats[names[columnNumber]].ToString());
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

		public void checkGeneralStatistics()
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
					Console.WriteLine("Select the column that is the Mineral Deposit ");
					foreach (KeyValuePair<int, string> name in names)
					{
						Console.WriteLine(name.Key.ToString() + ".- " + name.Value);
					}
					idText = Console.ReadLine();
					if (Int32.TryParse(idText, out selection))
					{
						try
						{
							foreach (Block block in blocks)
							{
								totalWeight += block.stats[names[selection]];
							}
						}
						catch (Exception e)
						{
							Console.WriteLine(e.ToString());
							Console.Read();
						}

					}
					Console.Write("Total Weight: " + totalWeight);

				}
				else if (selection == 3)
				{
					double totalWeight = 0;
					bool columnsIteration = true;
					while (columnsIteration)
					{
						Console.WriteLine("Select the column that is the Mineral Deposit or type 1 when you selected all the Mineral Deposits ");
						foreach (KeyValuePair<int, string> name in names)
						{
							Console.WriteLine(name.Key.ToString() + ".- " + name.Value);
						}
						idText = Console.ReadLine();
						if (Int32.TryParse(idText, out selection))
						{
							if (selection == 1)
							{
								columnsIteration = false;
							}
							else
							{
								try
								{
									foreach (Block block in blocks)
									{
										totalWeight += block.stats[names[selection]];
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
					Console.Write("Total Weight: " + totalWeight);
				}
				else if (selection == 4)
				{
					double airPercentageBlocks = 0;
					double value = 0;
					Console.WriteLine("Select the column that contains the values");
					foreach (KeyValuePair<int, string> name in names)
					{
						Console.WriteLine(name.Key.ToString() + ".- " + name.Value);
					}
					idText = Console.ReadLine();
					if (Int32.TryParse(idText, out selection))
					{
						try
						{
							foreach (Block block in blocks)
							{
								if (block.stats[names[selection]] == 0) airPercentageBlocks++;
							}
						}
						catch (Exception e)
						{
							Console.WriteLine(e.ToString());
							Console.Read();
						}

					}
					value = airPercentageBlocks / blocks.Count();
					Console.Write("Air Percentage: " + value + " %");
				}
				else
				{
					Console.WriteLine("Wrong Input");
				}

				Console.ReadLine();
			}
		}
	}
}
