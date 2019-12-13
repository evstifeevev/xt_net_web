using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Task04
{
    class Task0403 
    {
        public static void ConsoleInterface()
        {
            //Initialization of the first array
            Random rand = new Random();
            string[] a = new string[100000];
            Console.WriteLine("Array1 before sorting:");
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = "";
                int temp = rand.Next(0, 10);
                for (int k = 0; k < temp; k++)
                {
                    a[i] += i;
                }
               if(i<100) Console.Write(a[i] + "; ");
            }
            //Initialization of the second array
            float[] a2 = new float[1000];
            Console.WriteLine(Environment.NewLine+"Array2 before sorting:");
            for (int i = 0; i < a2.Length; i++)
            {
               a2[i] = rand.Next(0, 10)/10f;
                if (i < 100) Console.Write(a[i] + "; ");
            }
            //Sorting two arrays asynchronously
            SortingUnit<string>.NewThreadSort(a, Comparison<string>.CompareStringByLength);
            SortingUnit<float>.NewThreadSort(a2, Comparison<float>.CompareFloat);
            //Printing sorted arrays
            Console.WriteLine(Environment.NewLine + "Array1 after sorting:");
            for (int i = 0; i < 100; i++)
            {
                Console.Write(a[i] + "; ");
            }
            Console.WriteLine(Environment.NewLine + "Array2 after sorting:");
            foreach (var item in a2)
            {
                Console.Write(item + "; ");
            }
        }
    }
    //Contains methods to sort array starting method in a current thread or in a new one.
    //Has event on finished sorting and subcrcibed message method.
    abstract class SortingUnit<T> : CustomSort<T>
    {
        /// <summary>
        /// Sorts array with a specified comparison function.
        /// Uses new thread.
        /// </summary>
        public static void NewThreadSort(T[] array, ComparisonFunction<T> compare)
        {
            //Creating new Thread incapsulating sorting method 
            Thread thread = new Thread(() => MergeSort(array, compare));
            //Starting method in a new thread
            thread.Start();
            //It's a shame that this approach does not have anything with another CPU core.

        }
        /// <summary>
        /// Sorts array with a specified comparison function.
        /// </summary>
        public static new void MergeSort(T[] array, ComparisonFunction<T> compare) {
            //Subscription to event
            onSortingDone += SortingDoneSubscriber;
            //Invoking sort method from the base class
            CustomSort<T>.MergeSort(array, compare);
            //Invoking all subscribed methods
            onSortingDone?.Invoke(new object(), new SortingEventArgs<T>(array));
            //Unsubscription to event
            if (onSortingDone!=null) onSortingDone -= SortingDoneSubscriber;
        }

        /// <summary>
        /// Contains array as event arg.
        /// Contains method to check if sorted array is null.
        /// </summary>
        public class SortingEventArgs<U> : EventArgs
        { 
            public U[] Array { get; }
            public SortingEventArgs(U[] array)
            {
                if (array != null) 
                { 
                    this.Array = array;
                    
                }
                else
                {
                    throw new ArgumentNullException("Sorted array can not be null.");
                }
            }
        }
        //The event invokes methods if sorting is done
        static event EventHandler<SortingEventArgs<T>> onSortingDone;
        /// <summary>
        /// Displays the message using Console 
        /// </summary>
        static void SortingDoneSubscriber(object sender, EventArgs e) 
        {
            Console.WriteLine("Sorting's been completed.");
        }
    }
}
