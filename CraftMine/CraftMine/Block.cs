using System;
using System.Collections.Generic;
using System.Text;

namespace CraftMine
{
    public class Block
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
        public Block(int xMax, int yMax, int zMax, int x, int y, int z, Dictionary<string, double> stats)
        {
            this.id = IDCalculator(xMax, yMax, zMax, x, y, z);
            this.x = x; this.y = y; this.z = z;
            this.stats = stats;
        }

        public int IDCalculator(int xMax, int yMax, int zMax, int x, int y, int z)
        {
            return (z * xMax * yMax) + (y * xMax) + x;
        }

        public int getID()
        {
            return id;
        }
    }
}
