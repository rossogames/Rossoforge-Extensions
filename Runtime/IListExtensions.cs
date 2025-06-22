using System;
using System.Collections.Generic;

namespace RossoForge.Extensions
{
    public static class IListExtensions
    {
        /*
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
        */

        /// <summary>
        /// shuffle the list using Fisher–Yates method.
        /// </summary>
        public static void ShuffleInPlace<T>(this IList<T> list, Random? rng = null)
        {
            rng ??= new Random();
            for (int i = list.Count - 1; i > 0; i--)
            {
                int j = rng.Next(i + 1); // inclusive 0, exclusive i+1
                (list[i], list[j]) = (list[j], list[i]);
            }
        }
    }
}