using System;
using System.Collections.Generic;
using System.Text;

namespace CraftMine
{
    public class MineralDeposit
    {
        public int id;
        public string name;
        public List<BlockModel> blockModels = new List<BlockModel>();

        public MineralDeposit(string name)
        {
            this.id = MineralContainer.getNextMineralDepositID();
            this.name = name;
            MineralContainer.addMineralDeposit(this);
        }
    }
}
