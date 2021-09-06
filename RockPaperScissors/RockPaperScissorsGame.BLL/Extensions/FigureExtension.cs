using static RockPaperScissorsGame.BLL.Models.Types;

namespace RockPaperScissorsGame.BLL.Extensions
{
    public static class FigureExtension
    {
        public static Figure ConvertToStrongerFigure(this string value)
        {
            switch (value)
            {
                case "Rock":
                    return Figure.Paper;
                case "Paper":
                    return Figure.Scissors;
                case "Scissors":
                    return Figure.Rock;
                default:
                    return Figure.None;
            }
        }
    }
}
