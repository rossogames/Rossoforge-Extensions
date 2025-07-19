using System;
using System.Collections.Generic;

namespace Rossoforge.Extensions
{
    public static class IListExtensions
    {
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