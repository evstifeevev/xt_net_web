using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Task10TwoDArray
    {
        // Creating new instance of a Random class to get random integer numbers  
        private static readonly Random rand = new Random(DateTime.Now.Millisecond);
        // An interaction interface       
        internal static void ConsoleInterface()
        {
            // Create new 2D array with size 3 x 5.
            int[,] array2D = new int[3, 2];
            // Assign all elements of the array to 0
            Initialize(array2D, -100, 100);
            // Display all 
            Show(array2D);
            // Display the even sum
            Console.WriteLine(Environment.NewLine + "The sum of elements with even sum of indeces: "
                + EvenSum(array2D));
        }
        /// <summary>
        /// Assigns all elements of array to random numbers in range from a to b.
        /// </summary>
        /// <param name="array"></param>
        internal static void Initialize(int[,] array2D, int a, int b)
        {
            try
            {
                for (int i = 0; i < array2D.GetLength(0); i++)
                    for (int j = 0; j < array2D.GetLength(1); j++)
                        array2D[i, j] = rand.Next(a, b);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        /// <summary>
        /// Displays 2D array to the console.
        /// </summary>
        /// <param name="array"></param>
        internal static void Show(int[,] array)
        {
            try
            {
                Console.Write('{');
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    Console.Write('[');
                    for (int k = 0; k < array.GetLength(1); k++)
                    {
                        Console.Write(array[i, k] + ",");
                    }
                    Console.WriteLine("],");
                }
                Console.Write("},");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        /// <summary>
        /// Returns the sum of all elements of 2D int array with even sum of indeces.
        /// If any exception occures returns 0.
        /// </summary>
        /// <param name="twoDimArray"></param>
        /// <returns></returns>
        internal static int EvenSum(int[,] twoDimArray)
        {
            try
            {
                // The resulting sum.
                int result = 0;
                // For each index in the first dimension.
                for (int i = 0; i < twoDimArray.GetLength(0); i++)
                {
                    // For each index in the second dimension.
                    for (int k = 0; k < twoDimArray.GetLength(1); k++)
                    {
                        // If sum of both indeces is even.
                        if ((k + i) % 2 == 0)
                        {
                            // Update sum.
                            result += twoDimArray[i, k];
                        }
                    }
                }
                // Return the sum.
                return result;
            }
            // Handle any exception.
            catch (Exception e)
            {
                // Write the discription of exception.
                Console.WriteLine(e);
                // Return default value.
                return 0;
            }
        }
    }
}
