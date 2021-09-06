using RockPaperScissorsGame.BLL.Helpers;
using RockPaperScissorsGame.BLL.Infrastructure;
using System;
using static RockPaperScissorsGame.BLL.Models.Types;

namespace RockPaperScissorsGame.BLL.Models
{
    /// <summary>
    /// HumanPlayer
    /// </summary>
    public class HumanPlayer : IPlayer
    {
        #region Properties & fields

        public string Name { get; set; }

        public PlayerType PlayerType { get; set; }

        public Figure ResultingFigure { get; set; }

        private MemoryCache _cache { get; set; }

        #endregion

        /// <summary>
        /// HumanPlayer
        /// </summary>
        /// <param name="cache"></param>
        /// <param name="name"></param>
        /// <param name="type"></param>
        public HumanPlayer(MemoryCache cache, string name, PlayerType type) 
        {
           _cache = cache;

           Name = name;
           PlayerType = type;
           ResultingFigure = Figure.None;
        }


        #region Public methods
    
        /// <summary>
        /// Play
        /// </summary>
        /// <param name="inputFunc"></param>
        /// <param name="printAction"></param>
        public void Play(Func<string, string> inputFunc = null, Action<string> printAction=null)
        {            
            bool isValid = false;
            string inputStr = string.Empty;

            while (!isValid)
            {
                printAction("Please enter your choice: r/s/p");
                inputStr = inputFunc("");
                printAction("\n");
                if (InputValidator.IsInputValid(inputStr))
                {
                    isValid = true;
                }
            }

            switch (inputStr.ToLower()) 
            {
                case "r":
                    ResultingFigure = Figure.Rock;
                    break;
                case "s":
                    ResultingFigure = Figure.Scissors;
                    break;
                case "p":
                    ResultingFigure = Figure.Paper;
                    break;
                default:
                    ResultingFigure = Figure.None;
                    break;
            }

            _cache.Add(Name, ResultingFigure.ToString());
        }

        /// <summary>
        /// Show
        /// </summary>
        /// <param name="printAction"></param>
        public void Show(Action<string> printAction)
        {
            printAction($"Human Player {Name} is showing {ResultingFigure}");
        }

        #endregion
    }
}
