using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// Represents a class that contains methods to sort array in descending order.
    /// </summary>
    public class ArraySort
    {
        public static void Help()
        {
            Console.WriteLine("Type one of the folowwing command:\nhelp - get this manual;\n" +
                "show - show array;\nlength - change length of array. In new line type desired " +
                "length;\nrandomize: set random array;\ncheck - check if array is already " +
                "sorted.\nType one of the following numbers to implement one of the related " +
                "sorting algorithms:\n1 - Bubble sort, \n2 - Selection sort, \n3 - Insertion sort," +
                " \n4 - Merge sort, \nany other - Quicksort.");
        }
        /// <summary>
        /// Executes sort method specified by code.
        /// </summary>
        /// <param name="a">A 32-bit integer array</param>
        /// <param name="type">A code that defines the sorting algorithm. 1 - Bubble sort,
        /// 2 - Selection sort, 3 - Insertion sort, 4 - Merge sort, others - Quicksort</param>
        public static void Sort(int[] a, int type)
        {
            switch (type)
            {
                case 1: SortBubble(a); break;
                case 2: SelectionSort(a); break;
                case 3: SortInsert(a); break;
                case 4: SortMerge(a); break;
                default: QuickSort(a); break;
            }
        }
        /// <summary>
        /// Shows the whole array.
        /// </summary>
        /// <param name="a">A 32-bit integer array.</param>
        public static void Show(int[] a)
        {
            for (int i = 0; i < a.Length; i++) { Console.Write($"{a[i]} "); }
            Console.WriteLine();
        }
        /// <summary>
        /// Shows array length.
        /// </summary>
        /// <param name="a">A 32-bit integer array.</param>
        public static void Count(int[] a)
        {
            Console.WriteLine($"Count of elements equals {a.Length}");
        }
        /// <summary>
        /// Check if array is already sorted.
        /// </summary>
        /// <param name="a">A 32-bit integer array.</param>
        /// <returns></returns>
        public static string Check(int[] a)
        {
            for (int i = 0; i < a.Length - 1; i++)
            {
                if (a[i] > a[i + 1]) return "Array is not sorted.";
            }
            return "Array is sorted.";
        }
        /// <summary>
        /// Fills the array with random numbers from 0 to 100.
        /// </summary>
        /// <param name="a">A 32-bit integer array.</param>
        public static void Randomize(int[] a)
        {
            Random r = new Random();
            for (int i = 0; i < a.Length; i++) a[i] = r.Next(0, 100);
            Console.WriteLine("Randomizing has been done.");
        }
        /// <summary>
        /// Sorts array with a bubble sort algorithm.
        /// </summary>
        /// <param name="a">A 32-bit integer array.</param>
        private static void SortBubble(int[] a)
        {
            int temp;
            for (int i = 0; i < a.Length - 1; i++)
            {
                for (int j = i + 1; j < a.Length; j++) if (a[i] > a[j])
                    {
                        temp = a[i];
                        a[i] = a[j];
                        a[j] = temp;
                    }
            }
            // Every big number is coming up as a bubble.
            Console.WriteLine("Bubble sort has been done.");
        }
        /// <summary>
        /// Sorts array with a selection sort algorithm.
        /// </summary>
        /// <param name="a">A 32-bit integer array.</param>
        private static void SelectionSort(int[] a)
        {
            // This algorithm finds the minimum and places it at the beginning and so on.
            int min = a[0], num = 0;
            for (int j = 0; j < a.Length - 1; j++)
            {
                min = a[j]; num = j;
                for (int i = j + 1; i < a.Length; i++)
                {
                    if (min > a[i])
                    {
                        min = a[i];
                        num = i;
                    }
                }
                if (num != j)
                {
                    a[j] = a[j] + a[num];
                    a[num] = a[j] - a[num];
                    a[j] = a[j] - a[num];
                }
            }
            Console.WriteLine("Selection sort has been done.");
        }
        /// <summary>
        /// Sorts array with an insertion sort algorithm.
        /// </summary>
        /// <param name="a">A 32-bit integer array.</param>
        private static void SortInsert(int[] a)
        {
            int num = 0, j, temp;
            // Mark the first element.
            num = 0;
            while (num < a.Length - 1)
            {
                num++;
                j = num;
                // Compare elements and swap them to construct sorted array at the left side
                // from a[num].
                while ((j > 0) && (a[j] < a[j - 1]))
                {
                    temp = a[j]; a[j] = a[j - 1]; a[j - 1] = temp; j--;
                }
            }
            Console.WriteLine("Insertion sort has been done.");
        }
        /// <summary>
        /// Sorts array with a merge sort algorithm.
        /// </summary>
        /// <param name="a">A 32-bit integer array.</param>
        private static void SortMerge(int[] a)
        {
            // This is the second fastest algorithm after quicksort.
            // The algorithm works faster than my implementation of quicksort algorithm.
            // The reason is that quicksort must not use a lot of arrays and should work
            // only with one array instead.
            // The core idea is to split array into pairs of elements and sort them 
            // during the merge.
            a = Merged(a);
            Console.WriteLine("Merge sort has been done.");
        }
        private static int[] Merged(int[] a)
        {
            // Return only one element.
            if (a.Length == 1) return a;
            // Return sorted array of two elements.
            if (a.Length == 2)
            {
                if (a[0] > a[1])
                {
                    int temp = a[0];
                    a[0] = a[1]; a[1] = temp;
                }
                return a;
            }

            // Split the current array into two parts.
            // n - length of the first array, n2 - of the second array.
            int n = a.Length / 2;
            int n2 = n;
            int[][] b = new int[2][];

            for (int i = 0; i < 2; i++)
            {
                if (i < 1) b[i] = new int[n];
                else
                // Check if the length is odd.
                if (a.Length % 2 == 1)
                {
                    n2 = n + 1;
                    b[i] = new int[n2];
                }
                else
                {
                    b[i] = new int[n];
                }
                // Write values into arrays.
                for (int j = 0; j < n2; j++)
                {
                    b[i][j] = a[j + n * i];
                }
                // b - half of a
                b[i] = Merged(b[i]);
            }

            // Merge process
            // Index k corresponds to the first array and m - to the second.
            int k = 0, m = 0;
            while (k + m < n + n2)
            {
                // If at least one element of every array was not overwritten.
                if ((m < n2) && (k < n))
                {
                    if (b[0][k] < b[1][m])
                    {
                        a[k + m] = b[0][k];
                        k++;
                    }
                    else
                    {
                        a[k + m] = b[1][m];
                        m++;
                    }
                }
                else
                {
                    // Check which array must be used.
                    if (k < n) { for (; k < n; k++) { a[k + n2] = b[0][k]; } k = n; }
                    else if (m < n2)
                    {
                        if (n2 == 1)
                        {
                            a[n + n2 - 1] = b[1][m]; ;
                        }
                        else
                            for (; m < n2; m++) { a[n + m] = b[1][m]; }
                        m++;
                    }


                }

            }
            return a;
        }
        /// <summary>
        /// Sorts array with a quicksort algorithm
        /// </summary>
        /// <param name="a">A 32-bit integer array.</param>
        private static void QuickSort(int[] a)
        {
            a = Quick(a, 0, a.Length-1);
            Console.WriteLine("Quicksort has been done.");
        }
        
        //private static int[] Quick(int[] a)
        //{
        //    if (a.Length == 1) return a;
        //    int temp;
        //    // num - reference value, left and right - moving markers
        //    int num = a.Length - 1, left = 0, right = num - 1;

        //    while (left < num)
        //    {
        //        while (left < num && a[left] < a[num]) left++;
        //        if (left != num)
        //        {
        //            while (left != right && a[right] >= a[num]) right--;
        //            temp = a[left]; a[left] = a[right]; a[right] = temp;
        //        }
        //        if (left == right) break;  //equal markers define sorted element of the array
        //    }
        //    temp = a[left]; a[left] = a[num]; a[num] = temp;//After replacement the element a[left] will be sorted
        //    //Split the array into two parts (generally unequal) and quicksort the parts
        //    int[][] b = new int[2][];
        //    b[0] = new int[left]; for (int i = 0; i < left; i++) b[0][i] = a[i];
        //    b[1] = new int[a.Length - 1 - left]; for (int i = a.Length - 1; i > left; i--) b[1][i - 1 - left] = a[i];
        //    if (b[0].Length != 0) b[0] = Quick(b[0]); if (b[1].Length != 0) b[1] = Quick(b[1]);
        //    //Combine two parts into one array
        //    for (int i = 0; i < a.Length; i++)
        //    {
        //        if (i < left) a[i] = b[0][i];
        //        if (i > left) a[i] = b[1][i - left - 1];
        //    }
        //    // Return result
        //    return a;
        //}

        private static int[] Quick(int[] a, int first, int last)
        {
            if (a.Length == 1) return a;
            int temp;
            // num - reference value, left and right - moving markers.
            int num = last, left = first, right = last - 1;

            while (left < num)
            {
                while (left < num && a[left] < a[num]) left++;
                if (left != num)
                {
                    while (left != right && a[right] >= a[num]) right--;
                    temp = a[left]; a[left] = a[right]; a[right] = temp;
                }
                // Equal markers define sorted element of the array.
                if (left == right) break;  
            }
            // After replacement the element a[left] will be sorted.
            temp = a[left]; a[left] = a[num]; a[num] = temp;
            // Split the array into two parts and quicksort them.
            Quick(a, 0, left);
            Quick(a, left, a.Length - 1);
            // Return result.
            return a;
        }
    }

}
