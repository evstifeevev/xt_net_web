using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvstifeevEvgeniyTasks
{
    class Task04
    {
        private static Random Rand = new Random();
        public static void InitializeArray(int[][] a)//Initialization of the array with a random numbers
        {
            for (int i = 0; i < a.Length; i++)
                for (int k = 0; k < a[i].Length; k++)
                {
                    a[i][k] = Rand.Next(0, 100);
                }
            Console.WriteLine("Initialization's completed");
        }
        public static void ShowArray(int[][] a) {//Displays a jagged array
            Console.Write('{');
            for (int i = 0; i < a.Length; i++) {
                Console.Write('{');
                for (int k = 0; k < a[i].Length; k++) {
                    Console.Write(a[i][k].ToString() + ',');
                }
                Console.Write("},");
            }
            Console.WriteLine('}');
        }
        public static void BubbleSort(int[][] a)
        {
            foreach (int[] temp in a)
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
            Console.WriteLine("Bubble sort has been done.");
        }
        private static void Import(int[] OneDimensionalArray, int[][] JaggedArray) {
            int Index = 0;
            for (int i = 0; i < JaggedArray.Length; i++)
                for (int k = 0; k < JaggedArray[i].Length; k++)
                {
                    OneDimensionalArray[Index] = JaggedArray[i][k];
                    Index++;
                }
        }
        private static void Export(int[] OneDimensionalArray, int[][] JaggedArray)
        {
            int Index = 0;
            for (int i = 0; i < JaggedArray.Length; i++)
                for (int k = 0; k < JaggedArray[i].Length; k++)
                {
                    JaggedArray[i][k]= OneDimensionalArray[Index];
                    Index++;
                }
        }
        private static void SortFromArraySort(int n, int[][] a) {
            foreach (int[] temp in a)
                if (temp.Length > 0) { 
                    //Calculate a size of a new one-dimensional array (GeneralArray) based on jagged array (a)
                    int Size = 0;
                    for (int i = 0; i < a.Length; i++) Size += a[i].Length;
                    int[] GeneralArray = new int[Size];
                    Import(GeneralArray, a);// Import data to GeneralArray
                    ArraySort.Sort(GeneralArray, n); //Use one of the methods provided in the class ArraySort.cs
                    Export(GeneralArray, a); //Export data from GeneralArray
                }
        }
        public static void MergeSort(int[][] a)
        {
            SortFromArraySort(4, a);
        }
        public static void SelectionSort(int[][] a)
        {
            SortFromArraySort(2, a);
        }
        public static void InsertSort(int[][] a)
        {
            SortFromArraySort(3, a);
        }
        public static void QuickSort(int[][] a)
        {
            SortFromArraySort(5, a);
        }
    }
}
