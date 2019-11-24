using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Task1_7ArrayProcessing
    {
        public static void ConsoleInterface()//An interaction interface
        {
            int[] array = new int[100];//Create new array with 100 numbers
            Show(array);//Show the array
            InitializeArray(array);//Iitialize the array
            Show(array);
            Console.WriteLine("The maximum element equals to {0}", Max(array));//Find the minimun element of the array
            Console.WriteLine("The minimum element equals to {0}", Min(array));//Find the maximum element of the array
            int[] array2 = new int[array.Length];//Create new array with size of old array
            Array.Copy(array, array2, array.Length);//Copy elements from old array to the new
            BubbleSort(array2);//Implement bubble sort to sort array
            Show(array2);
            Array.Copy(array, array2, array.Length);//reset new array
            InsertSort(array2);//Implement insertion sort to sort array
            Show(array2);
            Array.Copy(array, array2, array.Length);//reset new array
            SelectionSort(array2);//Implement selection sort to sort array
            Show(array2);
            Array.Copy(array, array2, array.Length);//reset new array
            MergeSort(array2);//Implement merge sort to sort array
            Show(array2);
            Array.Copy(array, array2, array.Length);//reset new array
            QuickSort(array2);//Implement quick sort to sort array
            Show(array2);
        }
        /// <summary>
        /// Display all elements of array to the console
        /// </summary>
        /// <param name="array"></param>
        public static void Show(int[] array)   //Show the whole array
        {
            if (array != null) { 
            Console.Write("Array elements: ");
            for (int i = 0; i < array.Length; i++)//For each element of the array
                Console.Write($"{array[i]} ");//Write the element
            Console.WriteLine();//Write the white space
            }
            Console.WriteLine("Error: the array is assigned to null.");
        }
        /// <summary>
        /// Returns the maximum element of array. If any exception occures - returns 0.
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static int Max(int[] array) {
            try //If array is not empty
            {
                int result = array[0];//Assign maximum to the first element
                for (int i = 1; i < array.Length; i++)//For each remain element
                    if (result < array[i]) //If the element's value is higher than result
                        result = array[i];//Update result
               
                return result;//Return maximum
            }
            catch (Exception e)//If exception is occured
            {
                Console.WriteLine(e);//Display the discription of the exception
                return 0;//Return default value
            }
        }
        /// <summary>
        /// Returns the minimum element of array.  If any exception occures - returns 0.
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static int Min(int[] array)
        {
            try
            {
                int result = array[0];//Assign minimum to the first element
                for (int i = 1; i < array.Length; i++)//For each remain element
                    if (result > array[i]) //If value of element is higher than result
                        result = array[i];//Update result

                return result;//Return minimum
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return 0;
            }
        }
        static Random rand = new Random();//An instance of Random class
        /// <summary>
        /// Assigns all array elements to random values
        /// </summary>
        /// <param name="array"></param>
        public static void InitializeArray(int[] array)
        {
            try
            {
                for (int k = 0; k < array.Length; k++)//For each element
                    array[k] = rand.Next(-100, 100);//Assign element to random value from -100 to 100 inclusively
                Console.WriteLine("Initialization's been completed");//Write the message to the console
            }
            catch (Exception e) {
                Console.WriteLine(e);
            }
        }
        /// <summary>
        /// Sorts array with a bubble sort algorithm
        /// </summary>
        /// <param name="array"></param>
        public static void BubbleSort(int[] array)
        {
            ArraySort.Sort(array, 1);//Run method from other class
        }
        /// <summary>
        /// Sorts array with a merge sort approach
        /// </summary>
        /// <param name="array"></param>
        public static void MergeSort(int[] array)
        {
            ArraySort.Sort(array, 4);//Run method from other class
        }
        /// <summary>
        /// Sorts array with a selection sort algorithm
        /// </summary>
        /// <param name="array"></param>
        public static void SelectionSort(int[] array)
        {
            ArraySort.Sort(array, 2);//Run method from other class
        }
        /// <summary>
        /// Sorts array with an insertion sort algorithm
        /// </summary>
        /// <param name="array"></param>
        public static void InsertSort(int[] array)
        {
            ArraySort.Sort(array, 3);//Run method from other class
        }
        /// <summary>
        /// Sorts array with a quick sort algorithm
        /// </summary>
        /// <param name="array"></param>
        public static void QuickSort(int[] array)
        {
            ArraySort.Sort(array, 5);//Run method from other class
        }

    }
}
