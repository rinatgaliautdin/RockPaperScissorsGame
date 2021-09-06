using System.Collections.Generic;
using System.Linq;

namespace RockPaperScissorsGame.BLL.Services
{
    /// <summary>
    /// Statistics
    /// </summary>
    public static class Statistics
    {
        public static List<string> Winners { get; set; } = new List<string>();


        /// <summary>
        /// AddWinner
        /// </summary>
        /// <param name="name"></param>
        public static void AddWinner(string name)
        {
            Winners.Add(name);
        }


        /// <summary>
        /// GetChampion
        /// </summary>
        /// <returns></returns>
        public static string GetChampion()
        {
            string name = Winners.GroupBy(p=>p).Select(p=> new {
                Name = p.Key,
                Counter = p.Count()
            }).OrderByDescending(p=>p.Counter).First().Name;

            return name;
        }

    }
}
