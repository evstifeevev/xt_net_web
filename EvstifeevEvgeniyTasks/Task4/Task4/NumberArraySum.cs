using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task04
{
    class Task0404
    {
        public static void ConsoleInterface()
        {
            //Initializing array
            Random rand = new Random();
            int[] a = new int[10];
            Console.WriteLine("Array's elements:");
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = rand.Next(0, 10);
                Console.Write(a[i] + "; ");
            }
            //Printing the sum of all array's elements
            Console.WriteLine(Environment.NewLine + "Sum of elements is "+a.NumberArraySum());
        }
    }
    /// <summary>
    /// Contains my personal extension methods.
    /// </summary>
    public static class MyExtensionsMethods
    {
        /// <summary>
        /// Returns sum of all array's elements.
        /// </summary>
        public static int NumberArraySum(this int[] array) 
        {
            int sum = 0;
            foreach (int item in array) 
            {
                sum += item;
            }
            return sum;
        }
    }
}
