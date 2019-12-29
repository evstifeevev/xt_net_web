using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class ArraySort
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
        public static void Sort(int[] a, int type) //Execute sort method
        {
            switch (type)
            {
                case 1: SortBubble(a); break;
                case 2: SelectionSort(a); break;
                case 3: SortInsert(a); break;
                case 4: SortMerge(a); break;
                default: Quick(a); break;
            }
        }
        public static void Show(int[] a)   //Show the whole array
        {
            for (int i = 0; i < a.Length; i++) { Console.Write($"{a[i]} "); }
            Console.WriteLine();
        }
        public static void Count(int[] a)  //Show array length
        {
            Console.WriteLine($"Count of elements equals {a.Length}");
        }
        public static string Check(int[] a)    //Check if array is already sorted
        {
            for (int i = 0; i < a.Length - 1; i++)
            {
                if (a[i] > a[i + 1]) return "Array is not sorted.";
            }
            return "Array is sorted.";
        }
        public static void Randomize(int[] a)  //Fill the array with random numbers
        {
            Random r = new Random();
            for (int i = 0; i < a.Length; i++) a[i] = r.Next(0, 100);
            Console.WriteLine("Randomizing has been done.");
        }
        private static void SortBubble(int[] a)
        {   //The simplest sorting algorithm
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
            //Every big number is coming up as a bubble
            Console.WriteLine("Bubble sort has been done.");
        }
        private static void SelectionSort(int[] a)
        { //Second simplest algorithm 
            //It finds the minimum and places it at the beginning and so on
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

        private static void SortInsert(int[] a)    //Third simplest algorithm  
        {

            int num = 0, j, temp;
            num = 0;  //Mark the first element
            while (num < a.Length - 1)
            {
                num++;
                j = num;
                //Compare elements and swap them to construct sorted array at the left side
                //from a[num]
                while ((j > 0) && (a[j] < a[j - 1]))
                {
                    temp = a[j]; a[j] = a[j - 1]; a[j - 1] = temp; j--;
                }


            }
            Console.WriteLine("Insertion sort has been done.");
        }

        private static void SortMerge(int[] a)    //2nd fastest algorithm after quicksort
                                                  //This algorithm works faster than my implementation of quicksort algorithm.
                                                  //The reason is that quicksort must not use a lot of arrays and should work
                                                  //only with one array instead
        {
            //The core idea is to split array into pairs of elements and sort them 
            //during the merge
            a = Merged(a);
            Console.WriteLine("Merge sort has been done.");
        }
        static int[] Merged(int[] a)
        {
            if (a.Length == 1) return a;    //Return only one element
            if (a.Length == 2)  //Return sorted array of two elements
            {
                if (a[0] > a[1])
                {
                    int temp = a[0];
                    a[0] = a[1]; a[1] = temp;
                }
                return a;
            }
            //Split the current array into two parts
            int n = a.Length / 2;
            int[][] b = new int[2][];
            int n2 = n;
            //n - length of the first array, n2 - of the second array.
            for (int i = 0; i < 2; i++)
            {
                if (i < 1) b[i] = new int[n];
                else
                if (a.Length % 2 == 1)  //Check if the length is odd
                {
                    n2 = n + 1;
                    b[i] = new int[n2];
                }
                else
                {
                    b[i] = new int[n];
                }

                for (int j = 0; j < n2; j++)    //Write values into arrays
                {
                    b[i][j] = a[j + n * i];
                }
                // b - half of a
                b[i] = Merged(b[i]);
            }

            //Merge process
            //Index k corresponds to the first array and m - to the second.

            int k = 0, m = 0;
            while (k + m < n + n2)
            {
                //If at least one element of every array was not overwritten
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
        //First attempt 
        //static void QuickSort(int[] a)    //The fastest algorithm
        //{
        //    a = Quick(a);
        //    Console.WriteLine("Quicksort has been done.");
        //}
        //static int[] result;
        //static int[] Quick(int[] a)
        //{
        //    result = new int[a.Length];
        //    if (a.Length == 1) return a;
        //    int temp;
        //    int num = a.Length - 1, left = 0, right = num - 1;
        //    //num - reference value, left and right - moving markers
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
        //    //Return result
        //    return a;
        //}
        //Second attempt (the first one was too slow but had no StackOverflow exception)
        /*  void QuickSort(int[] a) {
             if (a.Length > 1) {
                 int temp, num = a.Length - 1, left = 0, right = num - 1;
                 try { quicksort(a, left, right, num); }
                 catch (Exception){ Console.WriteLine("QuickSort exception"); };
                 Console.WriteLine("QuickSort has been done.");// Show(a);
             }
         }
          void quicksort(int[] a,int left,int right,int num) {


             int temp, oldleft=left, oldright=right, oldnum=num;
             if (left > num) return;  
             while (left < num)
             {
                 while (left < num && a[left] < a[num]) left++;  //Firstly left marker moves until it's element 
                 //is higher than reference element or it is higher than reference number
                 if (left != num)    
                 {
                     while (left != right && a[right] >= a[num]) right--;
                     temp = a[left]; a[left] = a[right]; a[right] = temp;
                 }
                 if (left == right) break;
             }
             temp = a[left]; a[left] = a[num]; a[num] = temp;
             try
             {

                 if (left-1>0 && oldleft < left - 1) quicksort( a, oldleft, left - 2, left - 1);
                 if (oldnum > 0 && oldnum > left + 1) quicksort( a, left + 1, oldnum - 1, oldnum);

             }
             catch (Exception) { Console.WriteLine("QuickSort's subroutine exception"); }
         }*/
        //The last quicksort implementation (24.11.19)
        /// <summary>
        /// Sorts int array with a quicksort algorithm.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="p"></param>
        /// <param name="r"></param>
        static void QuickSort(int[] a, int p, int r) {
            if (p < r)
            {
                //bool different = true;
                //int q = 20;
                //int temp = a[0];
                //for (int j = 0; j < a.Length; j++) //Check if all elements are the same
                //{
                //    if (a[j] == temp && a.Length - 1 == j) { 
                //        q = (p + r) / 2;
                //        different = false;
                //    }
                //}
                //if (different) {
                //    //int x = a[r];
                //    //int i = p - 1;
                //    //for (int j = p; j < r - 1; j++)
                //    //    if (a[j] <= x)
                //    //    {
                //    //        i++;
                //    //        temp = a[i];
                //    //        a[i] = a[j];
                //    //        a[j] = temp;
                //    //    }
                //    //temp = a[i + 1];
                //    //a[i + 1] = a[r];
                //    //a[r] = temp;
                //    //q = i + 1;

                //    if (a.Length == 1) q = 0;
                //    int num = a.Length - 1, left = 0, right = num - 1;
                //    //num - reference value, left and right - moving markers
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
                //    q = left;
                //}
                ////int q = Partition(ref a, p, r);//q-th element counts as sorted
                //QuickSort(ref a, p, q - 1);
                //QuickSort(ref a, q + 1, r);
                int q = Partition(a, p, r);
                QuickSort( a, p, q - 1);
                QuickSort(a, q + 1, r);
            } 
        }
        static void Quick( int[] a) {
            QuickSort( a,0,a.Length-1);
            Console.WriteLine("Quick sort has been completed.");
        }
        static int Partition(int[] a, int p, int r) {
            //int temp = a[0];
            //for (int j = 0; j < a.Length; j++) //Check if all elements are the same
            //{
            //    if (a[j] == temp && a.Length - 1 == j)
            //        return (p + r) / 2;
            //}
            //int x = a[r];
            //int i = p - 1;
            //for (int j = p; j < r - 1; j++)
            //    if (a[j] <= x)
            //    {
            //        i++;
            //        temp = a[i];
            //        a[i] = a[j];
            //        a[j] = temp;
            //    }
            //temp = a[i + 1];
            //a[i + 1] = a[r];
            //a[r] = temp;
            //return i + 1;
            int temp;
            int i = p;
            for (int j = p; j <= r; j++)
                if (a[j] < a[r]) {
                    temp = a[i];
                    a[i] = a[j];
                    a[j] = temp;
                    j++;
                }
            temp = a[i];
            a[i] = a[r];
            a[r] = temp;
            return i;
            //if (a.Length == 1) return 0;     
            //int num = a.Length - 1, left = 0, right = num - 1;
            ////num - reference value, left and right - moving markers
            //while (left < num)
            //{
            //    while (left < num && a[left] < a[num]) left++;
            //    if (left != num)
            //    {
            //        while (left != right && a[right] >= a[num]) right--;
            //        temp = a[left]; a[left] = a[right]; a[right] = temp;
            //    }
            //    if (left == right) break;  //equal markers define sorted element of the array
            //}
            //temp = a[left]; a[left] = a[num]; a[num] = temp;//After replacement the element a[left] will be sorted 
            //return left;
        }
    }

}
