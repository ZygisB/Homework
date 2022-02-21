using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkTask4.Game
{
    class GameController
    {
        PlayerController playerController = new PlayerController();

        public void PlayGame()
        {
            Console.Clear();
            playerController.ClearPlayers();
            playerController.CreatePlayers();

            Random rnd = new Random();
            int diceRoll;

            for (int i = 1; i <= GameInformation.DiceCount; i++)
            {
                Console.WriteLine("Round "+i);
                for (int z = 0; z < GameInformation.PlayerCount; z++)
                {
                    diceRoll = rnd.Next(1, 7);
                    playerController.players[z].Score = playerController.players[z].Score + diceRoll;
                    Console.WriteLine($"{playerController.players[z].Name} rolled {diceRoll}. Total score: {playerController.players[z].Score}");
                }
            }
            playerController.SetMaxScores();
            if (playerController.CountMaxScores() == 1)
            {
                playerController.WinnerMessage();
            }
            else
            {
                playerController.DrawMessage();

                do
                {
                    Console.WriteLine("Additional round");
                    for (int z = 0; z < GameInformation.PlayerCount; z++)
                    {
                        if (playerController.players[z].MaxScore == true)
                        {
                            diceRoll = rnd.Next(1, 7);
                            playerController.players[z].Score = playerController.players[z].Score + diceRoll;
                            Console.WriteLine($"{playerController.players[z].Name} rolled {diceRoll}. Total score: {playerController.players[z].Score}");
                        }
                    }
                    playerController.SetMaxScores();
                }
                while (playerController.CountMaxScores() > 1);
                playerController.WinnerMessage();
            }
        }
        public int ReturnWinner()
        {
            int winnerPlayer=0;
            for (int z = 0; z < GameInformation.PlayerCount; z++)
            {
                if (playerController.players[z].MaxScore == true)
                {
                    winnerPlayer = z + 1;
                }
            }
            return winnerPlayer;
        }
        public int ReturnWinnerScore()
        {
            int winnerScore = 0;
            for (int z = 0; z < GameInformation.PlayerCount; z++)
            {
                if (playerController.players[z].MaxScore == true)
                {
                    winnerScore = playerController.players[z].Score;
                }
            }
            return winnerScore;
        }
    }
}
