using System;
using System.Collections.Generic;

namespace Rossoforge.Extensions
{
    public static class IListExtensions
    {
        /// <summary>
        /// shuffle the list using Fisher–Yates method.
        /// </summary>
        public static void ShuffleInPlace<T>(this IList<T> list, Random rng = null)
        {
            rng ??= new Random();
            for (int i = list.Count - 1; i > 0; i--)
            {
                int j = rng.Next(i + 1); // inclusive 0, exclusive i+1
                (list[i], list[j]) = (list[j], list[i]);
            }
        }

        /// <summary>
        /// Retrieves an element from a one-dimensional list as if it were a 2D grid,
        /// using the specified X and Y coordinates.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        /// <param name="source">The source list representing a 2D grid in row-major order.</param>
        /// <param name="x">The X coordinate (column index).</param>
        /// <param name="y">The Y coordinate (row index).</param>
        /// <param name="width">The width of the 2D grid.</param>
        /// <param name="height">The height of the 2D grid.</param>
        /// <returns>The element located at the specified coordinates.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="source"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when the specified coordinates are outside the grid bounds.
        /// </exception>
        public static T At2D<T>(
            this IList<T> source,
            int x,
            int y,
            int width,
            int height)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (x < 0 || x >= width || y < 0 || y >= height)
            {
                throw new ArgumentOutOfRangeException(
                    $"Coordinates ({x}, {y}) are outside the bounds of the 2D grid. " +
                    $"Valid range: X [0..{width - 1}], Y [0..{height - 1}].");
            }

            int index = y * width + x;
            return source[index];
        }

        /// <summary>
        /// Retrieves an element from a one-dimensional list as if it were a 3D grid,
        /// using the specified X, Y, and Z coordinates.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        /// <param name="source">The source list representing a 3D grid in row-major order.</param>
        /// <param name="x">The X coordinate (column index).</param>
        /// <param name="y">The Y coordinate (row index).</param>
        /// <param name="z">The Z coordinate (depth index).</param>
        /// <param name="width">The width of the 3D grid.</param>
        /// <param name="height">The height of the 3D grid.</param>
        /// <param name="depth">The depth of the 3D grid.</param>
        /// <returns>The element located at the specified coordinates.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="source"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when the specified coordinates are outside the grid bounds.
        /// </exception>
        public static T At3D<T>(
            this IList<T> source,
            int x,
            int y,
            int z,
            int width,
            int height,
            int depth)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (x < 0 || x >= width ||
                y < 0 || y >= height ||
                z < 0 || z >= depth)
            {
                throw new ArgumentOutOfRangeException(
                    $"Coordinates ({x}, {y}, {z}) are outside the bounds of the 3D grid. " +
                    $"Valid range: X [0..{width - 1}], Y [0..{height - 1}], Z [0..{depth - 1}].");
            }

            int index = z * width * height + y * width + x;
            return source[index];
        }

        /// <summary>
        /// Attempts to retrieve an element from a one-dimensional list as if it were a 2D grid,
        /// using the specified X and Y coordinates.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        /// <param name="source">The source list representing a 2D grid in row-major order.</param>
        /// <param name="x">The X coordinate (column index).</param>
        /// <param name="y">The Y coordinate (row index).</param>
        /// <param name="width">The width of the 2D grid.</param>
        /// <param name="height">The height of the 2D grid.</param>
        /// <param name="value">
        /// When this method returns <c>true</c>, contains the element at the specified coordinates;
        /// otherwise, contains the default value of <typeparamref name="T"/>.
        /// </param>
        /// <returns>
        /// <c>true</c> if the element exists within bounds; otherwise, <c>false</c>.
        /// </returns>
        public static bool TryAt2D<T>(
            this IList<T> source,
            int x,
            int y,
            int width,
            int height,
            out T value)
        {
            value = default;

            if (source == null ||
                x < 0 || x >= width ||
                y < 0 || y >= height)
                return false;

            value = source[y * width + x];
            return true;
        }

        /// <summary>
        /// Attempts to retrieve an element from a one-dimensional list as if it were a 3D grid,
        /// using the specified X, Y, and Z coordinates.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        /// <param name="source">The source list representing a 3D grid in row-major order.</param>
        /// <param name="x">The X coordinate (column index).</param>
        /// <param name="y">The Y coordinate (row index).</param>
        /// <param name="z">The Z coordinate (depth index).</param>
        /// <param name="width">The width of the 3D grid.</param>
        /// <param name="height">The height of the 3D grid.</param>
        /// <param name="depth">The depth of the 3D grid.</param>
        /// <param name="value">
        /// When this method returns <c>true</c>, contains the element at the specified coordinates;
        /// otherwise, contains the default value of <typeparamref name="T"/>.
        /// </param>
        /// <returns>
        /// <c>true</c> if the element exists within bounds; otherwise, <c>false</c>.
        /// </returns>
        public static bool TryAt3D<T>(
            this IList<T> source,
            int x,
            int y,
            int z,
            int width,
            int height,
            int depth,
            out T value)
        {
            value = default;

            if (source == null ||
                x < 0 || x >= width ||
                y < 0 || y >= height ||
                z < 0 || z >= depth)
                return false;

            value = source[z * width * height + y * width + x];
            return true;
        }
    }
}