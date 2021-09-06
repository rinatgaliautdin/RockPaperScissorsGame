using RockPaperScissorsGame.BLL.Infrastructure;
using RockPaperScissorsGame.BLL.Services;
using System;
using System.Collections.Generic;
using static RockPaperScissorsGame.BLL.Models.Types;

namespace RockPaperScissorsGame.BLL.Models
{
    /// <summary>
    /// Game
    /// </summary>
    public class Game
    {
        private int _selectedOption;

        private List<IPlayer> _players = new List<IPlayer>();

        public List<IPlayer> Players {
            get {
                return _players;
            }
        }

        /// <summary>
        /// option 0 : Human vs Computer, option 1: Computer vs Computer
        /// </summary>
        /// <param name="option"></param>
        public Game(int option)
        {
            _selectedOption = option;

            PopulatePlayers(option);
        }

        /// <summary>
        /// Note: using default names
        /// </summary>
        /// <param name="option"></param>
        private void PopulatePlayers(int option)
        {
            switch (option)
            {
                case 0:
                    _players.Add(new HumanPlayer(MemoryCache.Instance, "John", PlayerType.Human));
                    _players.Add(new ComputerPlayer(MemoryCache.Instance, "Sam", PlayerType.Computer));
                    break;
                case 1:
                    _players.Add(new ComputerPlayer(MemoryCache.Instance, "Sam", PlayerType.Computer));
                    _players.Add(new ComputerPlayer(MemoryCache.Instance, "Steve", PlayerType.Computer));
                    break;
                default:
                    break;
            }
        }


        /// <summary>
        /// Run
        /// </summary>
        /// <param name="inputFunc"></param>
        /// <param name="printAction"></param>
        /// <returns></returns>
        public IPlayer Run(Func<string, string> inputFunc = null, Action<string> printAction = null)
        {
            foreach (var player in _players)
            {
                if (player.PlayerType == PlayerType.Computer)
                {
                    player.Play();
                }
                else
                {
                    player.Play(inputFunc, printAction);
                }
                player.Show(printAction);
            }

            var winner = Judge.SelectWinner(_players[0], _players[1]);
            if (winner == null) return null;

            Statistics.AddWinner(winner.Name);

            return winner;
        }

    }//class
}
