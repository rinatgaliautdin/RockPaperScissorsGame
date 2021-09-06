using RockPaperScissorsGame.BLL.Models;
using RockPaperScissorsGame.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using static RockPaperScissorsGame.BLL.Models.Types;

namespace RockPaperScissorsGame.Tests
{
    public class GameTest
    {
        [Fact]
        public void ComputerRoundTest()
        {
            Action<string> PrintAction = p => Console.WriteLine(p);

            var game = new Game(1);
            var winner = game.Run(null, PrintAction);

            if (winner == null)
            {
                Assert.Equal(game.Players[0].ResultingFigure, game.Players[1].ResultingFigure);
            }

            if (winner != null)
            {
                bool isJudgementCorrect = false;

                var lostPlayer = game.Players.First(p => !p.Name.Equals(winner.Name));
                Assert.NotNull(lostPlayer);


                switch (winner.ResultingFigure)
                {
                    case Figure.Rock:
                        isJudgementCorrect = lostPlayer.ResultingFigure == Figure.Scissors;
                        break;
                    case Figure.Scissors:
                        isJudgementCorrect = lostPlayer.ResultingFigure == Figure.Paper;
                        break;
                    case Figure.Paper:
                        isJudgementCorrect = lostPlayer.ResultingFigure == Figure.Rock;
                        break;
                }

                Assert.True(isJudgementCorrect);
            }
        }


        [Fact]
        public void ChampionTest()
        {
            Action<string> PrintAction = p => Console.WriteLine(p);
            var winnerList = new List<string>();

            for (int i = 0; i < 15; i++)
            {
                var game = new Game(1);
                var winner = game.Run(null, PrintAction);

                if (winner != null)
                {
                    winnerList.Add(winner.Name);
                }
            }

            string winnerName = winnerList.GroupBy(p => p).Select(p => new
            {
                Name = p.Key,
                Counter = p.Count()
            }).OrderByDescending(p => p.Counter).First().Name;

            string name = Statistics.GetChampion();

            Assert.Equal(winnerName, name);
        }


        [Fact]
        public void JudgeTest()
        {
            var player1 = new HumanPlayer(null, "Player1", PlayerType.Human);
            var player2 = new HumanPlayer(null, "Player2", PlayerType.Human);

            player1.ResultingFigure = Figure.Rock;
            player2.ResultingFigure = Figure.Paper;
            string expectedWinnerName = "Player2";
            var winner = Judge.SelectWinner(player1, player2);
            Assert.Equal(winner.Name, expectedWinnerName);

            player1.ResultingFigure = Figure.Paper;
            player2.ResultingFigure = Figure.Scissors;
            expectedWinnerName = "Player2";
            winner = Judge.SelectWinner(player1, player2);
            Assert.Equal(winner.Name, expectedWinnerName);

            player1.ResultingFigure = Figure.Rock;
            player2.ResultingFigure = Figure.Scissors;
            expectedWinnerName = "Player1";
            winner = Judge.SelectWinner(player1, player2);
            Assert.Equal(winner.Name, expectedWinnerName);


            player1.ResultingFigure = Figure.Paper;
            player2.ResultingFigure = Figure.Paper;
            winner = Judge.SelectWinner(player1, player2);
            Assert.Equal(winner, null);
        }

    }//class
}
