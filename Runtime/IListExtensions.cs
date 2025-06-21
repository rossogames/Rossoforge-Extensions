using System.Collections.Generic;
using System.Linq;

namespace RossoForge.Extensions
{
    public static class IListExtensions
    {
        /// <summary>
        /// Gets a random item from the list
        /// </summary>
        /// <typeparam name="T">list data type</typeparam>
        /// <param name="list">list to search</param>
        /// <returns></returns>
        public static T GetRandomElement<T>(this IList<T> list)
        {
            return list[UnityEngine.Random.Range(0, list.Count)];
        }
        /// <summary>
        /// Get a random item from the list then remove it
        /// </summary>
        /// <typeparam name="T">list data type</typeparam>
        /// <param name="list">list to search</param>
        /// <returns></returns>
        public static T TakeRandomElement<T>(this IList<T> list)
        {
            if (list.Count > 0)
            {
                var i = GetRandomElement(list);
                list.Remove(i);
                return i;
            }
            else
                return default(T);
        }
        /// <summary>
        /// Mix the elements inside the list
        /// </summary>
        /// <typeparam name="T">list data type</typeparam>
        /// <param name="list">List to shuffle</param>
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = UnityEngine.Random.Range(0, n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
        /// <summary>
        /// split the list in small pieces
        /// </summary>
        /// <typeparam name="T">list data type</typeparam>
        /// <param name="source">List to Chunk</param>
        /// <param name="chunkSize">max size of the list</param>
        /// <returns></returns>
        public static List<List<T>> ChunkToList<T>(this IList<T> source, int chunkSize)
        {
            return source
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / chunkSize)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }
        /// <summary>
        /// split the list in small pieces
        /// </summary>
        /// <typeparam name="T">list data type</typeparam>
        /// <param name="source">List to Chunk</param>
        /// <param name="chunkSize">max size of the list</param>
        /// <returns></returns>
        public static T[][] ChunkToArrray<T>(this IList<T> source, int chunkSize)
        {
            return source
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / chunkSize)
                .Select(x => x.Select(v => v.Value).ToArray())
                .ToArray();
        }
    }
}