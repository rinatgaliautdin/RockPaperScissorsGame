using RockPaperScissorsGame.BLL.Extensions;
using RockPaperScissorsGame.BLL.Infrastructure;
using System;
using System.Linq;
using static RockPaperScissorsGame.BLL.Models.Types;

namespace RockPaperScissorsGame.BLL.Models
{
    /// <summary>
    /// ComputerPlayer
    /// </summary>
    public class ComputerPlayer : IPlayer
    {
        #region Properties & fields

        public string Name { get; set; }

        public PlayerType PlayerType { get; set; }

        public Figure ResultingFigure { get; set; }

        private MemoryCache _cache { get; set; }


        private Random _rnd;

        #endregion


        /// <summary>
        /// ComputerPlayer
        /// </summary>
        /// <param name="cache"></param>
        /// <param name="name"></param>
        /// <param name="type"></param>
        public ComputerPlayer(MemoryCache cache, string name, PlayerType type) 
        {
            _cache = cache;

            Name = name;
            PlayerType = type;
            ResultingFigure = Figure.None;

            _rnd = new Random();
        }

        #region Public methods

        /// <summary>
        /// Play
        /// </summary>
        /// <param name="inputFunc"></param>
        /// <param name="printAction"></param>
        public void Play(Func<string, string> inputFunc = null, Action<string> printAction = null)
        {
            ResultingFigure = _cache.Count() > Constants.StatisticsThreshold ? PredictBetterFigure() : GetRandomFigure();

            _cache.Add(Name, ResultingFigure.ToString());
        }


        /// <summary>
        /// Show
        /// </summary>
        /// <param name="printAction"></param>
        public void Show(Action<string> printAction)
        {
            printAction($"Computer Player {Name} is showing {ResultingFigure}");
        }

        #endregion


        #region Private methods

        /// <summary>
        /// GetRandomFigure
        /// </summary>
        /// <returns></returns>
        private Figure GetRandomFigure()
        {
            int val = _rnd.Next(3);
            return (Figure)val;
        }


        /// <summary>
        /// PredictBetterFigure
        /// </summary>
        /// <returns></returns>
        private Figure PredictBetterFigure()
        {
            string anotherName = _cache.GetAnotherPlayerName(Name);
            var statisticsResult = _cache.GetValuesByKey(anotherName);

            string potentialName = statisticsResult.GroupBy(p => p).Select(p => new
            {
                Name = p.Key,
                Counter = p.Count()
            }).OrderByDescending(p => p.Counter).First().Name;

            return potentialName.ConvertToStrongerFigure();
        }


        #endregion
    }
}
