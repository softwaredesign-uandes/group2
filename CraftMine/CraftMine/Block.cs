using System;
using System.Collections.Generic;
using System.Text;

namespace CraftMine
{
    class Block
    {
        public int id;
        public int x;
        public int y;
        public int z;
        public Dictionary<string, double> stats;


		public Block(int id, int x, int y, int z, Dictionary<string, double> stats)
        {
            this.id = id; this.x = x; this.y = y; this.z = z;
            this.stats = stats;
        }
    }
}
