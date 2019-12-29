using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task04
{
    //Contains the comparison method
    public delegate int ComparisonFunction<T>(T first, T second); 
    //Contains generic sort method for array of any available type.
    class CustomSort<T>
    {
        /// <summary>
        /// Sorts an array using specified comparison function
        /// </summary>
        /// <param name="a">Array</param>
        /// <param name="compare">Comparison function</param>
        public static void MergeSort(T[] a, ComparisonFunction<T> compare)    //2nd fastest algorithm after quicksort
                                                //only with one array instead
        {
            //The core idea is to split array into pairs of elements and sort them 
            //during the merge
            a = Merged(a, compare);
        }
        public static T[] Merged(T[] a, ComparisonFunction<T> compare)
        {
            if (a.Length == 1) return a;    //Return only one element
            if (a.Length == 2)  //Return sorted array of two elements
            {
                if (compare(a[0],a[1])>0)
                {
                    T temp = a[0];
                    a[0] = a[1]; a[1] = temp;
                }
                return a;
            }
            //Split the current array into two parts
            int n = a.Length / 2;
            T[][] b = new T[2][];
            int n2 = n;
            //n - length of the first array, n2 - of the second array.
            for (int i = 0; i < 2; i++)
            {
                if (i < 1) b[i] = new T[n];
                else
                if (a.Length % 2 == 1)  //Check if the length is odd
                {
                    n2 = n + 1;
                    b[i] = new T[n2];
                }
                else
                {
                    b[i] = new T[n];
                }

                for (int j = 0; j < n2; j++)    //Write values into arrays
                {
                    b[i][j] = a[j + n * i];
                }
                // b - half of a
                b[i] = Merged(b[i], compare);
            }

            //Merge process
            //Index k corresponds to the first array and m - to the second.

            int k = 0, m = 0;
            while (k + m < n + n2)
            {
                //If at least one element of every array was not overwritten
                if ((m < n2) && (k < n))
                {
                    if (compare(b[0][k], b[1][m])<0)
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
                    //check which array must be used
                    if (k < n) { for (; k < n; k++) { a[k + n2] = b[0][k]; } k = n; }
                    else
                      if (m < n2)
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
    }
    //Contains comparison methods for delegate ComparisonFunction<T>
    class Comparison<T> 
    {

        /// <summary>
        /// Compares two numbers of type int.
        /// </summary>
        /// <returns>0 if both numbers are equal,
        /// 1 if first is bigger and -1 if it is less.</returns>
        public static int CompareInt(int first, int second) 
        {
            if (first > second) return 1;
            else if (first < second) return -1;
            return 0;
        }
        /// <summary>  
        /// Compares two numbers of type float.
        /// </summary>
        /// <returns>0 if both numbers are equal,
        /// 1 if first is bigger and -1 if it is less.</returns>
        public static int CompareFloat(float first, float second)
        {
            if (first > second) return 1;
            else if (first < second) return -1;
            return 0;
        }
        /// <summary>  
        /// Compares two string by their lengths.
        /// </summary>
        /// <returns>0 if both lengths are equal,
        /// 1 if first's length is bigger and -1 if it is less.</returns>
        public static int CompareStringByLength(string first, string second)
        {
            if (first.Length > second.Length) return 1;
            else if (first.Length < second.Length) return -1;
            return 0;
        }
    }
    public class Task0401
    {
        public static void ConsoleInterface()
        {
            //Initializing new array
            Random rand = new Random();
            float[] a = new float[100];
            Console.WriteLine("Array before sorting:");
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = rand.Next(0, 100)/100.0f;
                //Printing element
                Console.Write(a[i]+"; ");
            }
            //Sorting array
            CustomSort<float>.MergeSort(a, Comparison<float>.CompareFloat);
            //Printing the sorted array
            Console.WriteLine(Environment.NewLine+"Array after sorting:");
            foreach (var item in a) 
            {
                Console.Write(item + "; ");
            }
        }
    }
}
