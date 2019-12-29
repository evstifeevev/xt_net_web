using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Task04
{
    class Task0406
    {
        public static void ConsoleInterface()
        {
            //Initializing array
            int[] array = new int[128000];
            Initialize(array);
            //Show(array);
            Stopwatch sw = new Stopwatch();
            long[] timeIntervals = new long[50]; 
            Func<int, int, int> deleg = delegate (int first, int second)
            {
                if (first > second)
                    return 1;
                else if (first < second)
                    return -1;
                return 0;
            };
            int result = -1;
            Console.WriteLine("Using simple method.");
            for (int i = 0; i < 50; i++)
            {
                sw.Reset();
                sw.Start();
                //Simple method 
                result = ISeekYou<int>.BinarySearch(array, 100);
                sw.Stop();
                timeIntervals[i] = sw.ElapsedMilliseconds;
            }
            Console.WriteLine("Result: " + result);
            Console.WriteLine("Average elapsed time: " + timeIntervals.Average());
            Console.WriteLine("Using method with an instance of delegate.");
            for (int i = 0; i < 50; i++)
            {
                sw.Reset();
                sw.Start();
                //Instance of delegate 
                result = ISeekYou<int>.BinarySearch(array, 100, deleg);
                sw.Stop();
                timeIntervals[i] = sw.ElapsedMilliseconds;
            }
            Console.WriteLine("Result: " + result);
            Console.WriteLine("Average elapsed time: " + timeIntervals.Average());
            Console.WriteLine("Using method with an anonymous method.");

            for (int i = 0; i < 50; i++)
            {
                sw.Reset();
                sw.Start();
                //Anonymous method
                result = ISeekYou<int>.BinarySearch(array, 100, delegate (int first, int second) {
                    if (first > second)
                        return 1;
                    else if (first < second)
                        return -1;
                    return 0;
                });
            sw.Stop();
                timeIntervals[i] = sw.ElapsedMilliseconds;
            }
            Console.WriteLine("Result: " + result);
            Console.WriteLine("Average elapsed time: " + timeIntervals.Average());
            Console.WriteLine("Using method with a lambda expression.");
            for (int i = 0; i < 50; i++)
            {
                sw.Reset();
                sw.Start();
                //Lambda expression
                result = ISeekYou<int>.BinarySearch(array, 100, (first,second) => (first>second ? 1: first<second? -1 : 0));
                sw.Stop();
                timeIntervals[i] = sw.ElapsedMilliseconds;
            }
            Console.WriteLine("Result: " + result);
            Console.WriteLine("Average elapsed time: " + timeIntervals.Average());
            Console.WriteLine("Using LINQ.");
            for (int i = 0; i < 50; i++)
            {
                sw.Reset();
                sw.Start();
                //LINQ
                var result2 = from item in array
                         where item == 100
                         select item;
                sw.Stop();
                timeIntervals[i] = sw.ElapsedMilliseconds;
            }
            Console.WriteLine("Result: " + result);
            Console.WriteLine("Average elapsed time: " + timeIntervals.Average());
        }
       /// <summary>
       /// Fills one-dimensional array with random numbers in range from 0 to 10 except
       /// the middle element which will be 100.
       /// </summary>
        static void Initialize(int[] array) {
            if (array != null) 
            {
                int middle = array.Length / 2;
                Random rand = new Random();
                for (int i = 0; i < array.Length; i++) 
                {
                    array[i] = rand.Next(0, 10);
                    if (i == middle) array[i] = 1000;
                }
            }
        }
        /// <summary>
        /// Print in console all elements of one-dimensional array.
        /// </summary>
        static void Show(int[] array)
        {
            if (array != null)
            {
                Console.WriteLine(Environment.NewLine+"Array's elements:");
                for (int i = 0; i < array.Length; i++)
                {
                    Console.Write(array[i] + "; ");
                }
            }
        }
    }
    /// <summary>
    /// Contains methods to search an item in an array with Binary Search algorithm.
    /// </summary>
    class ISeekYou<T>
        where T : IComparable
    {
        /// <summary>
        /// Returns index of the first array element that is required. 
        /// </summary>
        public static int BinarySearch(T[] array, T required)
        {
            //check if array's length is more than 1
            if (array.Length == 1)
            {
                if (array[0].CompareTo(required) == 0) return 0;
            }
            else
            {//Binary search algorithm
                int start = 0, len = array.Length, end = len, j = len % 2 == 0 ? len / 2 : len / 2 + 1;
                //j - index of current  element
                //start - index of left border
                //len - index of right border
                while (required.CompareTo(array[j]) != 0) //Stop when required value has been found
                {
                    if ((j > 0 && array[j - 1].CompareTo(required) < 0 && array[j].CompareTo(required) > 0) ||
                        (j < len - 1 && array[j].CompareTo(required) < 0 && array[j + 1].CompareTo(required) > 0))
                        return -1;//Two closest to required elements in a row 
                    if (required.CompareTo(array[j]) < 0)//Which side contains the required value
                        end = j - 1;//left
                    else
                        start = j + 1; //right
                    j = (end + start) / 2;//The middle index
                    if (j > len - 1 || end < start) return -1;//No elelements left
                }
                return j;
            }

            return -1;
        }
        /// <summary>
        /// Returns index of the first array element that is required. 
        /// Takes comparison function.
        /// </summary>
        public static int BinarySearch(T[] array, T required, Func<T,T,int> condition)
        {
            //Check if delegate has a method
            if (condition == null)
                throw new ArgumentNullException("Comparison method can not be null.");
            //check if array's length is more than 1
            if (array.Length == 1)
            {//check if array's length is more than 1
                if (condition?.Invoke(array[0], required) == 0) return 0;
            }
            else
            {//Binary search algorithm
                int start = 0, len = array.Length, end = len, j = len % 2 == 0 ? len / 2 : len / 2 + 1;
                //j - index of current  element
                //start - index of left border
                //len - index of right border
                while (condition(required, array[j]) != 0) //Stop when required value has been found
                {
                    if ((j > 0 && condition(array[j - 1], required) < 0 && condition(array[j], required) > 0) ||
                        (j < len - 1 && condition(array[j], required) < 0 && condition(array[j + 1], required) > 0))
                        return -1;//Two closest to required elements in a row 
                    if (condition(required, array[j]) < 0)//Which side contains the required value
                        end = j - 1;//left
                    else
                        start = j + 1; //right
                    j = (end + start) / 2;//The middle index
                    if (j > len - 1 || end < start) return -1;//No elelements left
                }
                return j;
            }

            return -1;
        }
    }
}
