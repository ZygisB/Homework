using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkTask4.Game
{
    class PlayerController
    {
        public List<Player> players { get; set; } = new List<Player>();

        public void CreatePlayers()
        {
            for (int i = 1; i <= GameInformation.PlayerCount; i++)
            {
                Player newPlayer = new Player(0, $"Player {i}");
                AddPlayer(newPlayer);
            }
        }
        private void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void ClearPlayers()
        {
            players.Clear();
        }

        public List<Player> GetPlayersList()
        {
            return players;
        }
        public void SetMaxScores()
        {
            int maxScore = 0;
            foreach (Player player in players)
            {
                if (player.Score > maxScore)
                {
                    foreach (Player playeResetMaxScore in players)
                    {
                        playeResetMaxScore.MaxScore = false;
                    }
                    player.MaxScore = true;
                    maxScore = player.Score;
                }
                if (player.Score >= maxScore)
                {
                    player.MaxScore = true;
                    maxScore = player.Score;
                }
            }
        }
        public int CountMaxScores()
        {
            int maxScoreCount = 0;
            foreach (Player player in players)
            {
                if (player.MaxScore == true)
                {
                    maxScoreCount++;
                }
            }
            return maxScoreCount;
        }
        public void WinnerMessage()
        {
            foreach (Player player in players)
            {
                if (player.MaxScore == true)
                {
                    Console.WriteLine($"The winner is {player.Name} with a total score of {player.Score}");
                }
            }
        }
        public void DrawMessage()
        {
            int maxScore = 0;
            Console.Write("There is a draw between ");

            foreach (Player player in players)
            {
                if (player.MaxScore == true)
                {
                    Console.Write($"{player.Name} ");
                    maxScore = player.Score;
                }
            }

            Console.WriteLine($"with a total score of {maxScore}");
        }
    }
}
