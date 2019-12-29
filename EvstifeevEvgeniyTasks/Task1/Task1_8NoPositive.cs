using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Task1_8NoPositive
    {
        static Random rand = new Random();//Create new instance of Random class
        public static void ConsoleInterface()//An interaction interface
        {
            int[,,] array3D = new int[4, 5, 10];//Create new 3 dimensional array
            Initialize(array3D);
            Console.WriteLine("Not modified three dimensional array:");
            ShowSmall(array3D);//Show not modified array
            ReplacePositiveThreeDimensional(array3D);//Assign all positive elements to 0
            Console.WriteLine(Environment.NewLine + "Modified three dimensional array:");
            ShowSmall(array3D);//Show modified array
        }
        /// <summary>
        /// Show all elements of 3D array (better for arrays with small 2nd and 3rd dimension length)
        /// </summary>
        /// <param name="array"></param>
        public static void ShowSmall(int[,,] array)
        {
            if (array != null) { 
            Console.Write('{');
            for (int i = 0; i < array.GetLength(0); i++)
            {
                Console.Write('[');
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write('(');
                    for (int k = 0; k < array.GetLength(2); k++)
                            Console.Write(array[i, j, k] + ",");
                    if (j == array.GetLength(1)-1) 
                        Console.Write("),");
                    else Console.WriteLine("),");
                }
                if(i==array.GetLength(0)-1)
                    Console.Write("],");
                else Console.WriteLine("]," + Environment.NewLine);
            }
            Console.WriteLine('}'+Environment.NewLine);
            }
            Console.WriteLine("Error: the array is assigned to null.");
        }
        /// <summary>
        /// Display all elements of 3D array to a compact view.
        /// </summary>
        /// <param name="array"></param>
        public static void Show(int[,,] array) {
            Console.Write('{');
            for (int i = 0; i < array.GetLength(0); i++) {
                Console.Write('[');
                for (int j = 0; j < array.GetLength(1); j++) {
                    Console.Write('(');
                    for (int k = 0; k < array.GetLength(2); k++) {
                        Console.Write(array[i,j,k]+",");
                    }
                    Console.Write("),");
                }
                Console.Write("],");
            }
            Console.Write("},");
        }
        public static void Initialize(int[,,] array) {
            for (int i = 0; i < array.GetLength(0); i++)//For each index of first dimension
                for (int j = 0; j < array.GetLength(1); j++)//For each index of second dimension
                    for (int k = 0; k < array.GetLength(2); k++)//For each index of third dimension
                        array[i, j, k] = rand.Next(-100, 100);//Assign to random value in range from -100 to 100
            Console.WriteLine("Initialization has been completed.");
        }
        public static void ReplacePositiveThreeDimensional(int[,,] array) {
            for (int i = 0; i < array.GetLength(0); i++)//For each index of the first dimension
                for (int j = 0; j < array.GetLength(1); j++)//For each index of the second dimension
                    for (int k = 0; k < array.GetLength(2); k++)//For each index of the third dimension
                        if (array[i, j, k] > 0) array[i, j, k] = 0;//Assign positive element to 0
            Console.WriteLine("Modification has been completed.");
        }
    }
}
