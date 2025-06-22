using System;
using System.Collections.Generic;

namespace RossoForge.Extensions
{
    public static class ArrayExtensions
    {
        /// <summary>
        /// Select n elements at random from the indicated array
        /// </summary>
        /// <typeparam name="T">array data type</typeparam>
        /// <param name="choses">Array with values to select</param>
        /// <param name="numberToChoose">Number of expected results</param>
        /// <returns></returns>
        public static T[] Choose<T>(this T[] choses, int numberToChoose)
        {
            System.Random rnd = new System.Random();
            var items = new List<T>();
            items.AddRange(choses);

            List<T> chosenItems = new List<T>();
            for (int i = 1; i <= numberToChoose; i++)
            {
                int index = rnd.Next(items.Count);
                chosenItems.Add(items[index]);
                items.RemoveAt(index);
            }

            return chosenItems.ToArray();
        }
        /// <summary>
        /// It traverses the array and executes the action indicated by each element
        /// </summary>
        /// <typeparam name="T">array data type</typeparam>
        /// <param name="source">array to traverse</param>
        /// <param name="action">Action to execute in each iteration</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void ForEach<T>(this T[] source, Action<T> action)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (action == null) throw new ArgumentNullException("action");

            foreach (T item in source)
                action(item);
        }
    }
}