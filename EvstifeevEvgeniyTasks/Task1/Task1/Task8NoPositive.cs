using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Task8NoPositive
    {
        // Create new instance of Random class.
        private static Random rand = new Random(DateTime.Now.Millisecond);
        // An interaction interface.
        internal static void ConsoleInterface()
        {
            // Create new 3 dimensional array.
            int[,,] array3D = new int[4, 5, 10];
            Initialize(array3D);
            Console.WriteLine("Not modified three dimensional array:");
            // Show not modified array.
            ShowSmall(array3D);
            // Assign all positive elements to 0.
            ReplacePositiveThreeDimensional(array3D);
            Console.WriteLine(Environment.NewLine + "Modified three dimensional array:");
            // Show modified array.
            ShowSmall(array3D);
        }
        /// <summary>
        /// Show all elements of 3D array (better for arrays with small 2nd and 3rd dimension length).
        /// </summary>
        /// <param name="array"></param>
        internal static void ShowSmall(int[,,] array)
        {
            if (array != null)
            {
                Console.Write('{');
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    Console.Write('[');
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        Console.Write('(');
                        for (int k = 0; k < array.GetLength(2); k++)
                            Console.Write(array[i, j, k] + ",");
                        if (j == array.GetLength(1) - 1)
                            Console.Write("),");
                        else Console.WriteLine("),");
                    }
                    if (i == array.GetLength(0) - 1)
                        Console.Write("],");
                    else Console.WriteLine("]," + Environment.NewLine);
                }
                Console.WriteLine('}' + Environment.NewLine);
            }
            Console.WriteLine("Error: the array is assigned to null.");
        }
        /// <summary>
        /// Display all elements of 3D array to a compact view.
        /// </summary>
        /// <param name="array"></param>
        internal static void Show(int[,,] array)
        {
            Console.Write('{');
            for (int i = 0; i < array.GetLength(0); i++)
            {
                Console.Write('[');
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write('(');
                    for (int k = 0; k < array.GetLength(2); k++)
                    {
                        Console.Write(array[i, j, k] + ",");
                    }
                    Console.Write("),");
                }
                Console.Write("],");
            }
            Console.Write("},");
        }
        internal static void Initialize(int[,,] array)
        {
            // For each index of first dimension.
            for (int i = 0; i < array.GetLength(0); i++)
            {
                // For each index of second dimension.
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    // For each index of third dimension.
                    for (int k = 0; k < array.GetLength(2); k++)
                    {
                        // Assign to random value in range from -100 to 100.
                        array[i, j, k] = rand.Next(-100, 100);
                    }
                }
            }
            Console.WriteLine("Initialization has been completed.");
        }
        internal static void ReplacePositiveThreeDimensional(int[,,] array)
        {
            // For each index of the first dimension.
            for (int i = 0; i < array.GetLength(0); i++) 
            {
                // For each index of the second dimension.
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    // For each index of the third dimension.
                    for (int k = 0; k < array.GetLength(2); k++)
                    {
                        if (array[i, j, k] > 0)
                        {
                            // Assign positive element to 0.
                            array[i, j, k] = 0;
                        }
                    }
                }
            }
            Console.WriteLine("Modification has been completed.");
        }
    }
}
