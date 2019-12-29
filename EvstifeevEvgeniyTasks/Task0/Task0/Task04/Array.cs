using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Task0.Task04
{
    internal class Array
    {
        private static Random _rand = new Random(DateTime.Now.Millisecond);
        ///
        /// <summary>
        /// Array initialization with a random numbers in range from min to max
        /// </summary>
        /// <param name="a">A 32-bit integer jagged array that is needed to be initialized</param>
        /// <param name="min">The inclusive lower bound of the random number returned.</param>
        /// <param name="max">The inclusive upper bound of the random number returned.</param>
        internal static void InitializeArray(int[][] a, int min, int max)
        {
            for (int i = 0; i < a.Length; i++)
                for (int k = 0; k < a[i].Length; k++)
                {
                    a[i][k] = _rand.Next(min, max + 1);
                }
            Console.WriteLine("Initialization's completed");
        }

        /// <summary>
        /// Displays jagged array
        /// </summary>
        /// <param name="a">A 32-bit integer jagged array</param>
        internal static void ShowArray(int[][] a)
        {
            Console.Write('{');
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write('{');
                for (int k = 0; k < a[i].Length; k++)
                {
                    Console.Write(a[i][k].ToString() + ',');
                }
                Console.Write("},");
            }
            Console.WriteLine('}');
        }

        /// <summary>
        /// Sorts array with a common bubble sort algorithm
        /// </summary>
        /// <param name="a"></param>
        internal static void BubbleSort(int[][] a)
        {
            foreach (int[] temp in a)
            {
                if (temp.Length > 0)
                {
                    int buf, m_start;
                    for (int i = 0; i < a.Length; i++)
                    {
                        for (int k = 0; k < a[i].Length; k++)
                        {
                            for (int j = i; j < a.Length; j++)
                            {
                                m_start = (j != i) ? 0 : k;
                                for (int m = m_start; m < a[j].Length; m++)
                                {
                                    if (a[i][k] > a[j][m])
                                    { //Swap two elements
                                        buf = a[i][k];
                                        a[i][k] = a[j][m];
                                        a[j][m] = buf;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine("Bubble sort has been done.");
        }
        internal static void MergeSort(int[][] a)
        {
            SortFromArraySort(4, a);
        }
        internal static void SelectionSort(int[][] a)
        {
            SortFromArraySort(2, a);
        }
        internal static void InsertSort(int[][] a)
        {
            SortFromArraySort(3, a);
        }
        internal static void QuickSort(int[][] a)
        {
            SortFromArraySort(5, a);
        }
        private static void Import(int[] OneDimensionalArray, int[][] JaggedArray)
        {
            int Index = 0;
            for (int i = 0; i < JaggedArray.Length; i++)
            {
                for (int k = 0; k < JaggedArray[i].Length; k++)
                {
                    OneDimensionalArray[Index] = JaggedArray[i][k];
                    Index++;
                }
            }
        }
        private static void Export(int[] OneDimensionalArray, int[][] JaggedArray)
        {
            int Index = 0;
            for (int i = 0; i < JaggedArray.Length; i++)
            {
                for (int k = 0; k < JaggedArray[i].Length; k++)
                {
                    JaggedArray[i][k] = OneDimensionalArray[Index];
                    Index++;
                }
            }
        }
        private static void SortFromArraySort(int n, int[][] a)
        {
            foreach (int[] temp in a)
            {
                if (temp.Length > 0)
                {
                    // Calculate a size of a new one-dimensional array 
                    // (GeneralArray) based on jagged array (a)
                    int Size = 0;
                    for (int i = 0; i < a.Length; i++) Size += a[i].Length;
                    int[] GeneralArray = new int[Size];
                    // Import data to GeneralArray
                    Import(GeneralArray, a);
                    // Use one of the methods provided in the class ArraySort.cs
                    ArraySort.Sort(GeneralArray, n);
                    // Export data from GeneralArray
                    Export(GeneralArray, a); 
                }
            }
        }

    }
}
