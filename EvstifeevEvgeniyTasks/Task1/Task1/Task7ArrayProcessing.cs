using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Task1
{
    internal class Task7ArrayProcessing
    {
        /// <summary>
        /// An interaction interface.
        /// </summary>
        internal static void ConsoleInterface()
        {
            // Create new array with 100 numbers.
            int[] array = new int[3];
            // Show the array.
            Show(array);
            // Initialize the array with random numbers.
            InitializeArray(array);
            Show(array);
            // Find the minimum element of the array.
            Console.WriteLine("The maximum element equals to {0}", Max(array));
            // Find the maximum element of the array
            Console.WriteLine("The minimum element equals to {0}", Min(array));
            // Create new array with size of old array.
            int[] array2 = new int[array.Length];
            InitializeArray(array2);// Initialize the array.
            Show(array2);
            QuickSort(array2);// Implement quick sort to sort array.
            Show(array2);
            array2 = new int[1];
            InitializeArray(array2);// Initialize the array.
            Show(array2);
            QuickSort(array2);// Implement quick sort to sort array.
            Show(array2);
            array2 = new int[2];
            InitializeArray(array2);// Initialize the array.
            Show(array2);
            QuickSort(array2);// Implement quick sort to sort array.
            Show(array2);
            array2 = new int[3];
            InitializeArray(array2);// Initialize the array.
            Show(array2);
            QuickSort(array2);// Implement quick sort to sort array.
            Show(array2);
            array2 = new int[11];
            InitializeArray(array2);// Initialize the array.
            Show(array2);
            QuickSort(array2);// Implement quick sort to sort array.
            Show(array2);
            array2 = new int[10];
            InitializeArray(array2);// Initialize the array.
            Show(array2);
            QuickSort(array2);// Implement quick sort to sort array.
            Show(array2);
            array2 = new int[10000];
            InitializeArray(array2);// Initialize the array.
            QuickSort(array2);// Implement quick sort to sort array.
        }
        /// <summary>
        /// Display all elements of array to the console.
        /// </summary>
        /// <param name="array"></param>
        internal static void Show(int[] array)
        {
            if (array != null)
            {
                Console.Write("Array elements: ");
                // For each element of the array.
                for (int i = 0; i < array.Length; i++)
                {
                    // Write the element.
                    Console.Write($"{array[i]} ");
                }
                // Write the white space.
                Console.WriteLine();
            }
            else
                Console.WriteLine("Error: the array is assigned to null.");
        }
        /// <summary>
        /// Returns the maximum element of array. If any exception occures - returns 0.
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        internal static int Max(int[] array)
        {
            try // If array is not empty.
            {
                // Assign maximum to the first element.
                int result = array[0];
                // For each remain element.
                for (int i = 1; i < array.Length; i++)
                {
                    // If the element's value is higher than result.
                    if (result < array[i])
                    {
                        //Update result
                        result = array[i];
                    }
                }
                // Return maximum.
                return result;
            }
            catch (Exception e)// If exception is occured.
            {
                // Display the discription of the exception.
                Console.WriteLine(e);
                // Return default value.
                return 0;
            }
        }
        /// <summary>
        /// Returns the minimum element of array.  If any exception occures - returns 0.
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        internal static int Min(int[] array)
        {
            try
            {
                // Assign minimum to the first element.
                int result = array[0];
                // For each remain element.
                for (int i = 1; i < array.Length; i++)
                {
                    // If value of element is higher than result.
                    if (result > array[i])
                    {
                        // Update result.
                        result = array[i];
                    }
                }
                // Return minimum.
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return 0;
            }
        }
        // An instance of Random class.
        private static Random rand = new Random(DateTime.Now.Millisecond);
        /// <summary>
        /// Assigns all array elements to random values.
        /// </summary>
        /// <param name="array"></param>
        internal static void InitializeArray(int[] array)
        {
            try
            {
                // Assign elements of the array to random value from -100 to 100 inclusively.
                for (int k = 0; k < array.Length; k++)
                {

                    array[k] = rand.Next(-100, 100);
                }
                // Write the message to the console.
                Console.WriteLine("Initialization's been completed");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        /// <summary>
        /// Sorts array with a bubble sort algorithm.
        /// </summary>
        /// <param name="array"></param>
        internal static void BubbleSort(int[] array)
        {
            // Run method from other class.
            ArraySort.Sort(array, 1);
        }
        /// <summary>
        /// Sorts array with a merge sort approach.
        /// </summary>
        /// <param name="array"></param>
        internal static void MergeSort(int[] array)
        {
            // Run method from other class.
            ArraySort.Sort(array, 4);
        }
        /// <summary>
        /// Sorts array with a selection sort algorithm.
        /// </summary>
        /// <param name="array"></param>
        internal static void SelectionSort(int[] array)
        {
            // Run method from other class.
            ArraySort.Sort(array, 2);
        }
        /// <summary>
        /// Sorts array with an insertion sort algorithm.
        /// </summary>
        /// <param name="array"></param>
        internal static void InsertSort(int[] array)
        {
            // Run method from other class.
            ArraySort.Sort(array, 3);
        }
        /// <summary>
        /// Sorts array with a quick sort algorithm.
        /// </summary>
        /// <param name="array"></param>
        internal static void QuickSort(int[] array)
        {
            // Run method from other class.
            ArraySort.Sort(array, 5);
        }

    }
}
