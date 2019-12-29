using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task0
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 0;//An array size 
            while(N<1) {//Waiting for the correct input
                Console.WriteLine("Enter the size of array (N):");//Input of array size
                if (Int32.TryParse(Console.ReadLine(), out int temp)) {//Test if inputed number is correct
                    if (temp < 1) Console.WriteLine("Incorrect input. The input must be a positive integer number.");
                    else
                    { N = temp; break; }/*The value is valid*/ }
                else
                    Console.WriteLine("Incorrect number. The number must be positive integer.");
                }
            Console.WriteLine("Enter the sequence of subarrays sizes. (For example: 1 2 3 4)");//Input of size of each subarray
            int[][] Array = new int[N][];
            List<string> SubArraySizesString=new List<string>();//List of inputed numbers
            while (SubArraySizesString.Count<N) {//Waiting until all numbers has been inputed
                foreach (string s in Console.ReadLine().Split(' ')) SubArraySizesString.Add(s);//Add words from console to the list
               for (int i=0;i< SubArraySizesString.Count; i++) {//Test if inputed numbers are correct
                    if (!Int32.TryParse(SubArraySizesString[i], out int temp))
                    {
                        SubArraySizesString.RemoveAt(i);//Remove incorrect number from the list
                        i--;//Since the count of elements of the list has been decreased by one the number i should also be decreased by 1 
                    }
                    else if (temp < 0) {//Inputed number is negative
                        SubArraySizesString.RemoveAt(i);
                        i--;
                    }
                }
                if (SubArraySizesString.Count < N)//Not enough inputed numbers 
                    Console.WriteLine($"Error: input {N- SubArraySizesString.Count} more number(s)", N, SubArraySizesString.Count);
                else if (SubArraySizesString.Count > N) //Too many inputed numbers 
                    Console.WriteLine($"Error: too many input numbers ({SubArraySizesString.Count} > {N}). " +
                    $"Every number after {N} number will be ignored", N, SubArraySizesString.Count);
            }
            //Set the sizes of subarrays
            for (int i = 0; i < N; i++) {
                Array[i] = new int[Convert.ToInt32(SubArraySizesString[i])];
            }

            Task0_4Array.InitializeArray(Array);//Inizialization of the array
            Task0_4Array.ShowArray(Array);//Demonstration of the array
            Task0_4Array.MergeSort(Array);//Sorting the array
            Task0_4Array.ShowArray(Array);
        }

    }
}
