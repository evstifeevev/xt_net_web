using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task0.Task04
{
    internal class ConsoleUIAndBLL
    {
        internal static void Run() 
        {
            // An array size 
            int N = 0;
            // Waiting for the correct input
            while (N < 1)
            {
                // Input of array size
                Console.WriteLine("Enter the size of array (N):");
                if (Int32.TryParse(Console.ReadLine(), out int temp))
                {
                    // Test if inputed number is correct
                    if (temp < 1) Console.WriteLine("Incorrect input. The input must be a positive integer number.");
                    else
                    {
                        // The value is valid
                        N = temp;
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect number. The number must be positive integer.");
                }
            }
            // Input of size of each subarray
            Console.WriteLine("Enter the sequence of subarrays sizes. (For example: 1 2 3 4)");
            int[][] array = new int[N][];
            // List of inputed numbers
            List<string> SubArraySizesString = new List<string>();
            while (SubArraySizesString.Count < N)
            {
                // Waiting until all numbers has been inputed
                foreach (string s in Console.ReadLine().Split(' '))
                {
                    // Add words from console to the list
                    SubArraySizesString.Add(s);
                }
                for (int i = 0; i < SubArraySizesString.Count; i++)
                {
                    // Test if inputed numbers are correct
                    if (!Int32.TryParse(SubArraySizesString[i], out int temp))
                    {
                        // Remove incorrect number from the list
                        SubArraySizesString.RemoveAt(i);
                        //Since the count of elements of the list has been decreased by one
                        // the number i should also be decreased by 1 
                        i--;
                    }
                    else if (temp < 0)
                    {
                        // Inputed number is negative
                        SubArraySizesString.RemoveAt(i);
                        i--;
                    }
                }

                if (SubArraySizesString.Count < N)
                {
                    // Not enough inputed numbers
                    Console.WriteLine($"Error: input {N - SubArraySizesString.Count} more number(s)", N, SubArraySizesString.Count);
                }
                else if (SubArraySizesString.Count > N)
                {
                    // Too many inputed numbers 
                    Console.WriteLine($"Error: too many input numbers ({SubArraySizesString.Count} > {N}). " +
                    $"Every number after {N} number will be ignored", N, SubArraySizesString.Count);
                }
            }
            // Set the sizes of subarrays
            for (int i = 0; i < N; i++)
            {
                array[i] = new int[Convert.ToInt32(SubArraySizesString[i])];
            }

            // Array initialization
            Array.InitializeArray(array, -2, 2);
            // Unsorted array presentation
            Array.ShowArray(array);
            // Array sorting
            Array.MergeSort(array);
            // Sorted array presentation
            Array.ShowArray(array);
        }
    }
}
