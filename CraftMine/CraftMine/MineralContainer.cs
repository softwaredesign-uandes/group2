﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CraftMine
{
    public static class MineralContainer
    {
        private static List<BlockModel> BlockModels = new List<BlockModel>();
        private static List<MineralDeposit> MineralDeposits = new List<MineralDeposit>();
        
        private static int BlockModelID = 0;
        private static int MineralDepositID = 0;

        public static void addBlockModel(BlockModel blockModel)
        {
            BlockModels.Add(blockModel);
        }

        public static void addMineralDeposit(MineralDeposit mineralDeposit)
        {
            MineralDeposits.Add(mineralDeposit);
        }

        public static List<BlockModel> getBlockModels()
        {
            return BlockModels;
        }

        public static List<MineralDeposit> getMineralDeposits()
        {
            return MineralDeposits;
        }

        public static BlockModel getBlockModelByID(int id)
        {
            return BlockModels.First(i => i.id == id);
        }

        public static MineralDeposit getMineralDepositByID(int id)
        {
            return MineralDeposits.First(i => i.id == id);
        }

        public static int getNextBlockModelID()
        {
            int currentID = BlockModelID;
            BlockModelID++;
            return currentID;
        }

        public static int getNextMineralDepositID()
        {
            int currentID = MineralDepositID;
            MineralDepositID++;
            return currentID;
        }
    }   
}
