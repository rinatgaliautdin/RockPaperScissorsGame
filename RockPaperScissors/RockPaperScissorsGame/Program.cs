using RockPaperScissorsGame.BLL.Infrastructure;
using RockPaperScissorsGame.BLL.Models;
using RockPaperScissorsGame.BLL.Services;
using System;

namespace RockPaperScissorsGame
{
    class Program
    {    
        /// <summary>
        /// Main
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {            
            Action<string> PrintAction = p => Console.WriteLine(p);
            Func<string, string> FuncInput = x => Console.ReadKey().Key.ToString();
   
            ConsoleKeyInfo key;
            Console.TreatControlCAsInput = true;
            
            do
            {
                Console.Clear();
                PrintMainMenu();
                key = Console.ReadKey();
               
                switch (key.Key.ToString())
                {
                    case "D1":
                        do
                        {
                            Console.Clear();
                            PlayGame(0, FuncInput, PrintAction);

                            Console.WriteLine("The game Human vs Computer is finished, do you want to play more (Y/N)?");
                            key = Console.ReadKey();
                        } while (key.Key != ConsoleKey.N);

                        break;
                    case "D2":
                        do
                        {
                            Console.Clear();
                            PlayGame(1, FuncInput, PrintAction);

                            Console.WriteLine("The game Computer vs Computer is finished, do you want to play more (Y/N)?");
                            key = Console.ReadKey();
                        } while (key.Key != ConsoleKey.N);
                        break;
                    case "D3":
                        Console.Clear();
                        DisplayStatistics();
                        Console.WriteLine("Press any key to return to the main menu");
                        Console.ReadKey();
                        break;
                    case "D4":
                        Console.Clear();
                        ShowChampion();
                        Console.WriteLine("Press any key to return to the main menu");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Wrong input");
                        break;
                }


            } while (key.Key != ConsoleKey.Escape);           
        }


        /// <summary>
        /// PlayGame
        /// </summary>
        /// <param name="gameOption"></param>
        /// <param name="inputFunc"></param>
        /// <param name="printAction"></param>
        private static void PlayGame(int gameOption, Func<string, string> inputFunc = null, Action<string> printAction = null)
        {
            var game = new Game(gameOption);
            var winner = game.Run(inputFunc, printAction);

            if (winner != null)
            {
                Console.WriteLine($"\nThe judge of the game selected {winner.PlayerType} player {winner.Name} as a winner");
            }
            else
            {
                Console.WriteLine("Both players showed the same figure, it's even!");
            }
        }


        /// <summary>
        /// DisplayStatistics
        /// </summary>
        private static void DisplayStatistics()
        {            
            var list = MemoryCache.Instance.GetAllFigures();

            if (list.Count > 0)
            {
                Console.WriteLine("This is the statistics of the played games:");

                foreach (var item in list)
                {
                    Console.WriteLine($"Player {item.Name} showed {item.FigureName}");
                }
            }
            else
            {
                Console.WriteLine("There is no statistics yet, you must play the game first");
            }
        }


        /// <summary>
        /// ShowChampion
        /// </summary>
        private static void ShowChampion()
        {
            if (MemoryCache.Instance.Count() > 0)
            {
                string name = Statistics.GetChampion();
                Console.WriteLine($"Champion of the played games is: {name}");
            }
            else
            {
                Console.WriteLine("There is no statistics, you must play first");
            }
        }


        /// <summary>
        /// PrintMainMenu
        /// </summary>
        private static void PrintMainMenu()
        {
            Console.WriteLine("Press 1 to Play Human vs Computer");
            Console.WriteLine("Press 2 to Play Computer vs Computer");
            Console.WriteLine("Press 3 to See the history of the showed figures");
            Console.WriteLine("Press 4 to Show champion of the played games during the app run");
            Console.WriteLine("Press the Escape (Esc) key to quit: \n");
        }


    }//class
}
