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
        /// <param name="source">The source collection</param>
        /// <param name="chunkSize">max size of the list</param>
        /// <returns></returns>
        public static List<List<T>> ChunkToList<T>(this IEnumerable<T> source, int chunkSize)
        {
            if (chunkSize <= 0) 
                throw new ArgumentOutOfRangeException(nameof(chunkSize), "Chunk size must be greater than zero.");

            var result = new List<List<T>>();
            var chunk = new List<T>(chunkSize);

            foreach (var item in source)
            {
                chunk.Add(item);
                if (chunk.Count == chunkSize)
                {
                    result.Add(chunk);
                    chunk = new List<T>(chunkSize);
                }
            }

            if (chunk.Count > 0)
                result.Add(chunk);

            return result;
        }

        /// <summary>
        /// split the list in small pieces
        /// </summary>
        /// <typeparam name="T">Array data type</typeparam>
        /// <param name="source">The source collection</param>
        /// <param name="chunkSize">max size of the list</param>
        /// <returns></returns>
        public static T[][] ChunkToArray<T>(this IEnumerable<T> source, int chunkSize)
        {
            if (chunkSize <= 0)
                throw new ArgumentOutOfRangeException(nameof(chunkSize), "Chunk size must be greater than zero.");

            var result = new List<T[]>();
            var buffer = new List<T>(chunkSize);

            foreach (var item in source)
            {
                buffer.Add(item);
                if (buffer.Count == chunkSize)
                {
                    result.Add(buffer.ToArray());
                    buffer.Clear();
                }
            }

            if (buffer.Count > 0)
                result.Add(buffer.ToArray());

            return result.ToArray();
        }


        /// <summary>
        /// Executes an action for each element in the enumerable.
        /// </summary>
        /// <param name="source">The source collection</param>
        /// <param name="action">The action to execute for each element.</param>
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var item in source)
                action(item);
        }

        /// <summary>
        /// Executes an action for each element with its index.
        /// </summary>
        /// <param name="source">The source collection</param>
        /// <param name="action">The action to execute for each element.</param>
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
        /// <param name="source">The source collection to choose from.</param>
        /// <returns>True if the collection is empty, otherwise false.</returns>
        public static bool IsEmpty<T>(this IEnumerable<T> source)
        {
            return !source.Any();
        }

        /// <summary>
        /// Returns true if the enumerable has at least one element.
        /// </summary>
        /// <param name="source">The source collection</param>
        /// <returns>True if the collection is not empty, otherwise false.</returns>
        public static bool IsNotEmpty<T>(this IEnumerable<T> source)
        {
            return source.Any();
        }

        /// <summary>
        /// Returns all non-null elements from a collection of reference types.
        /// </summary>
        /// <param name="source">The source collection to choose from.</param>
        /// <returns>All non-null elements from the source collection.</returns>
        public static IEnumerable<T> WhereNotNull<T>(this IEnumerable<T> source) where T : class
        {
            foreach (var item in source)
            {
                if (item != null)
                    yield return item;
            }
        }

        /// <summary>
        /// Returns all non-null elements from a collection of nullable value types.
        /// </summary>
        /// <param name="source">The source collection</param>
        /// <returns>All non-null elements from the source collection.</returns>
        public static IEnumerable<T> WhereNotNull<T>(this IEnumerable<T?> source) where T : struct
        {
            foreach (var item in source)
            {
                if (item.HasValue)
                    yield return item.Value;
            }
        }

        /// <summary>
        /// Returns a list with the elements in random order using Fisher–Yates shuffle.
        /// </summary>
        /// <param name="source">The source collection</param>
        /// <param name="rng">Optional random number generator. If null, a new instance will be created.</param>
        /// <returns>A shuffled list of elements.</returns>
        public static List<T> Shuffle<T>(this IEnumerable<T> source, Random rng = null)
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
        /// <param name="source">The source collection</param>
        /// <param name="rng">Optional random number generator. If null, a new instance will be created.</param>
        /// <returns>random element from the enumerable</returns>
        public static T RandomElement<T>(this IEnumerable<T> source, Random rng = null)
        {
            rng ??= new Random();

            if (source is IList<T> list)
            {
                if (list.Count == 0)
                    throw new InvalidOperationException("Cannot select a random element from an empty sequence.");
                return list[rng.Next(list.Count)];
            }

            // Support IReadOnlyList<T> (like ImmutableList<T>)
            if (source is IReadOnlyList<T> readOnlyList)
            {
                if (readOnlyList.Count == 0)
                    throw new InvalidOperationException("Cannot select a random element from an empty sequence.");
                return readOnlyList[rng.Next(readOnlyList.Count)];
            }

            // Fallback
            var array = source.ToArray();
            if (array.Length == 0)
                throw new InvalidOperationException("Cannot select a random element from an empty sequence.");
            return array[rng.Next(array.Length)];
        }

        /// <summary>
        /// Selects a specified number of unique elements at random from the source collection.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the collection.</typeparam>
        /// <param name="source">The source collection</param>
        /// <param name="numberToChoose">The number of elements to randomly select.</param>
        /// <param name="rng">Optional random number generator. If null, a new instance will be created.</param>
        /// <returns>An array with the randomly selected elements.</returns>
        public static List<T> Choose<T>(this IEnumerable<T> source, int numberToChoose, Random rng = null)
        {
            rng ??= new Random();

            if (numberToChoose < 0)
                throw new ArgumentOutOfRangeException(nameof(numberToChoose), "Number to choose must be non-negative.");

            var items = source.ToList();
            if (numberToChoose > items.Count)
                throw new ArgumentException("Cannot choose more elements than are present in the source collection.");

            var chosenItems = new List<T>(numberToChoose);

            for (int i = 0; i < numberToChoose; i++)
            {
                int index = rng.Next(items.Count);
                chosenItems.Add(items[index]);
                items.RemoveAt(index);
            }

            return chosenItems;
        }
    }
}