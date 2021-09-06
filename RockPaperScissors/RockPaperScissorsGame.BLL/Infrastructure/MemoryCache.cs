using RockPaperScissorsGame.BLL.Models;
using System.Collections.Generic;
using System.Linq;

namespace RockPaperScissorsGame.BLL.Infrastructure
{
    /// <summary>
    /// MemoryCache
    /// </summary>
    public sealed class MemoryCache
    {
        MemoryCache()
        {
        }

        private static readonly object memLocker = new object ();

        private static MemoryCache instance = null;


        private List<Hit> _cache = new List<Hit>();


        /// <summary>
        /// MemoryCache
        /// </summary>
        public static MemoryCache Instance
        {
            get
            {
                lock (memLocker)
                {
                    if (instance == null)
                    {
                        instance = new MemoryCache();
                    }
                    return instance;
                }
            }
        }


        /// <summary>
        /// Add
        /// </summary>
        /// <param name="name"></param>
        /// <param name="figureValue"></param>
        public void Add(string name, string figureValue)
        {
            _cache.Add(new Hit {
                 Name = name,
                 FigureName = figureValue
            });
        }


        /// <summary>
        /// Get all the figures by player name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<string> GetValuesByKey(string name)
        {
            var result = _cache.Where(p => p.Name.Equals(name)).Select(p=>p.FigureName).ToList();

            return result;
        }


        /// <summary>
        /// GetAllFigures
        /// </summary>
        /// <returns></returns>
        public List<Hit> GetAllFigures()
        {
            var result = _cache.ToList();

            return result;
        }


        /// <summary>
        /// GetAnotherPlayerName
        /// </summary>
        /// <param name="myName"></param>
        /// <returns></returns>
        public string GetAnotherPlayerName(string myName)
        {
            string anotherName = _cache.Count > 0 ? _cache.FirstOrDefault(p => !p.Name.Equals(myName)).Name : string.Empty;

            return anotherName;
        }


        /// <summary>
        /// Count
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return _cache.Count;
        }

    }//class
}
