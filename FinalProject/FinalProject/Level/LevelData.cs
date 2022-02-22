using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Level
{
    class LevelData
    {
        /* Cell Info Coding:
         * Walls - 0
         * Walkable Area - 1
         * Hero - 2
         * Item - 3
         * Enemy - 4
         * Doors - 5
         */
        public int[,] levelData { get; set; }
        public LevelData(int[,] levelData)
        {
            this.levelData = levelData;
        }
    }
}
