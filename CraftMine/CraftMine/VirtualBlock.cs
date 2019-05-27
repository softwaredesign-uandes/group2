using System;
using System.Collections.Generic;
using System.Text;

namespace CraftMine
{
	class VirtualBlock:Block
	{

		public List<Block> blocks;

		public VirtualBlock(int id, int x, int y, int z, Dictionary<string, double> stats, List<Block> blocks):base(id, x, y, z, stats)
		{
			this.blocks = blocks;
			this.id = id; this.x = x; this.y = y; this.z = z;
			this.stats = stats;
		}
	}
}
