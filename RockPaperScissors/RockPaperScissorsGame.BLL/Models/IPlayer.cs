using System;
using static RockPaperScissorsGame.BLL.Models.Types;

namespace RockPaperScissorsGame.BLL.Models
{
    public interface IPlayer
    {
        string Name { get; set; }

        PlayerType PlayerType { get; set; }

        Figure ResultingFigure { get; set; }

        void Play(Func<string, string> inputFunc =null, Action<string> printAction=null);

        void Show(Action<string> printAction);
    }
}
