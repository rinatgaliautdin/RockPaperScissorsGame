using static RockPaperScissorsGame.BLL.Models.Types;

namespace RockPaperScissorsGame.BLL.Models
{
    /// <summary>
    /// Judge
    /// </summary>
    public static class Judge
    {
        /// <summary>
        /// SelectWinner
        /// </summary>
        /// <param name="player1"></param>
        /// <param name="player2"></param>
        /// <returns></returns>
        public static IPlayer SelectWinner(IPlayer player1, IPlayer player2)
        {
            if (player1.ResultingFigure == player2.ResultingFigure) return null;

            bool isPlayer1Winner = (player1.ResultingFigure == Figure.Rock && player2.ResultingFigure == Figure.Scissors) || 
                (player1.ResultingFigure == Figure.Paper && player2.ResultingFigure == Figure.Rock) || 
                (player1.ResultingFigure == Figure.Scissors && player2.ResultingFigure == Figure.Paper);

            return isPlayer1Winner ? player1 : player2;
        }
    }
}
