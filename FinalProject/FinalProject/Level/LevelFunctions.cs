using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Level
{
    class LevelFunctions
    {
        LevelData levelData;

        public void RenderLevel(LevelData levelData)
        {
            int[,] levelArray = levelData.levelData;
            for (int i = 0; i < levelArray.GetLength(0); i++)
            {
                for (int j = 0; j < levelArray.GetLength(1); j++)
                {
                    if (levelArray[i, j] == 0)
                    {
                        Console.SetCursorPosition(j, i);
                        Console.WriteLine("#");
                    }
                    else if (levelArray[i, j] == 5) //Door render
                    {
                        Console.SetCursorPosition(j, i);
                        Console.WriteLine(" ");
                    }
                    else 
                    {
                        Console.SetCursorPosition(j, i);
                        Console.WriteLine("");
                    }
                }
            }
        }
        public int GetCellInfo(LevelData levelData, int x, int y)
        {
            int[,] levelArray = levelData.levelData;
            int cellInfo = levelArray[y, x];

            return cellInfo;
        }
        public void ChangeCellInfo(LevelData levelData, int x, int y, int number)
        {
            levelData.levelData[y, x] = number;
        }
        public int[,] ReturnLevelArray(int levelNumber)
        {
            LevelConstant levelConstant = new LevelConstant();
            int[,] levelArray = levelConstant.levelList[levelNumber];
            return levelArray;
        }
        public void SetLevel(int levelNumber)
        {
            LevelConstant levelConstant = new LevelConstant();
            LevelData levelData = new LevelData(levelConstant.levelList[levelNumber]);  
            this.levelData = levelData;
        }
        public LevelData ReturnLevel()
        {
            return levelData;
        }
        public void OpenDoors(LevelData levelData)
        {
            for (int y = 39; y < 50; y++)
            {
                for (int x = 18; x < 23; x++)
                {
                    levelData.levelData[x, y] = 5;
                }
            }
        }
        public int GetLevelLength(LevelData levelData)
        {
            int length = levelData.levelData.GetLength(1);

            return length;
        }
        public int FirstEmptyX(LevelData levelData)
        {
            int x = 0;
            int[,] levelArray = levelData.levelData;
            for (int i = 0; i < levelArray.GetLength(0); i++)
            {
                for (int j = 0; j < levelArray.GetLength(1); j++)
                {
                    if (levelArray[i, j] == 1)
                    {
                        x = j;
                        goto Done;
                    }
                }
            }
        Done:
            ;
            return x;
        }
        public int FirstEmptyY(LevelData levelData)
        {
            int x = 0;
            int[,] levelArray = levelData.levelData;
            for (int i = 0; i < levelArray.GetLength(0); i++)
            {
                for (int j = 0; j < levelArray.GetLength(1); j++)
                {
                    if (levelArray[i, j] == 1)
                    {
                        x = i;
                        goto Done;
                    }
                }
            }
        Done:
            ;
            return x;
        }
    }
}
