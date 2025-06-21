using System;
using System.Collections.Generic;
using System.Linq;

namespace RossoForge.Extensions
{
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// split the list in small pieces
        /// </summary>
        /// <typeparam name="T">list data type</typeparam>
        /// <param name="source">List to Chunk</param>
        /// <param name="chunkSize">max size of the list</param>
        /// <returns></returns>
        public static List<List<T>> ChunkToList<T>(this IEnumerable<T> source, int chunkSize)
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
        public static T[][] ChunkToArrray<T>(this IEnumerable<T> source, int chunkSize)
        {
            return source
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / chunkSize)
                .Select(x => x.Select(v => v.Value).ToArray())
                .ToArray();
        }

        /// <summary>
        /// Executes an action for each element in the enumerable.
        /// </summary>
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var item in source)
                action(item);
        }

        /// <summary>
        /// Executes an action for each element with its index.
        /// </summary>
        public static void ForEach<T>(this IEnumerable<T> source, Action<T, int> action)
        {
            int index = 0;
            foreach (var item in source)
            {
                action(item, index);
                index++;
            }
        }

        /// <summary>
        /// Returns true if the enumerable has no elements.
        /// </summary>
        public static bool IsEmpty<T>(this IEnumerable<T> source)
        {
            return !source.Any();
        }

        /// <summary>
        /// Returns true if the enumerable has at least one element.
        /// </summary>
        public static bool IsNotEmpty<T>(this IEnumerable<T> source)
        {
            return source.Any();
        }

        /// <summary>
        /// Returns all non-null elements from a collection of reference types.
        /// </summary>
        public static IEnumerable<T> WhereNotNull<T>(this IEnumerable<T?> source) where T : class
        {
            return source.Where(x => x != null)!;
        }

        /// <summary>
        /// Returns all non-null elements from a collection of nullable value types.
        /// </summary>
        public static IEnumerable<T> WhereNotNull<T>(this IEnumerable<T?> source) where T : struct
        {
            return source.Where(x => x.HasValue).Select(x => x!.Value);
        }

        /// <summary>
        /// Returns a new enumerable with the elements in random order using Fisher–Yates shuffle.
        /// </summary>
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source, Random? rng = null)
        {
            rng ??= new Random();
            var buffer = source.ToList();
            for (int i = buffer.Count - 1; i > 0; i--)
            {
                int j = rng.Next(i + 1);
                (buffer[i], buffer[j]) = (buffer[j], buffer[i]);
            }
            return buffer;
        }

        /// <summary>
        /// Returns a random element from the enumerable.
        /// Throws if the collection is empty.
        /// </summary>
        public static T RandomElement<T>(this IEnumerable<T> source, Random? rng = null)
        {
            var list = source.ToList();
            if (list.Count == 0)
                throw new InvalidOperationException("Cannot select a random element from an empty sequence.");

            rng ??= new Random();
            return list[rng.Next(list.Count)];
        }
    }
}