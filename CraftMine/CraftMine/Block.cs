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
        public double weight;
        public Dictionary<string, double> grades;
        public Dictionary<string, double> stats;


        public Block(int id, int x, int y, int z, double weight, Dictionary<string, double> grades, Dictionary<string, double> stats)
        {
            this.id = id; this.x = x; this.y = y; this.z = z; this.weight = weight;
            this.grades = grades;
            this.stats = stats;
        }
    }
}
