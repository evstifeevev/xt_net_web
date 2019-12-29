using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task04
{
    class CustomSortDemo
    {
        public static void ConsoleInterface()
        {
            //Initializing array
            Random rand = new Random();
            string[] a = new string[100];
            Console.WriteLine("Array before sorting:");
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = "";
                int temp = rand.Next(0, 10);
                for (int k = 0; k < temp; k++) 
                {
                    a[i] += i;
                }
                //Printing element
                Console.Write(a[i] + "; ");
            }
            //Sorting array by comparing strings by their lengths
            CustomSort<string>.MergeSort(a, Comparison<string>.CompareStringByLength);
            //Printing the sorted array
            Console.WriteLine(Environment.NewLine + "Array after sorting:");
            foreach (var item in a)
            {
                Console.Write(item + "; ");
            }
        }
    }
}
