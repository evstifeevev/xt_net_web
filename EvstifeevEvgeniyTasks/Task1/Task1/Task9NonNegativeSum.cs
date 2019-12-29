using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Task9NonNegativeSum
    {
        // An interaction interface.
        internal static void ConsoleInterface()
        {
            // Create new instance of Random class.
            Random rand = new Random(DateTime.Now.Millisecond);
            // Create new array of integer numbers with length equals 10.
            int[] arrayOneDimensional = new int[10];
            // Assign all elements to random numbers.
            Task7ArrayProcessing.InitializeArray(arrayOneDimensional);
            // Display all elements.
            Task7ArrayProcessing.Show(arrayOneDimensional);
            // Display sum of all non-negative values.           
            Console.WriteLine("The summ of non-negative elements equals to " +
                NonNegativeSum(arrayOneDimensional));
            arrayOneDimensional = null;
            // Assign all elements to random numbers.
            Task7ArrayProcessing.InitializeArray(arrayOneDimensional);
            // Display all elements.
            Task7ArrayProcessing.Show(arrayOneDimensional);
            // Display sum of all non-negative values.
            Console.WriteLine("The summ of non-negative elements equals to " +
                NonNegativeSum(arrayOneDimensional));
        }
        /// <summary>
        /// Returns sum of all non-negative values.  If any exception occures - returns 0.
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        internal static int NonNegativeSum(int[] array) {
            try
            {
                // Reset the sum.
                int sum = 0;
                // For each element of array.
                foreach (var a in array)
                {
                    // Note: in this case condition a > 0 also is correct,
                    // because there is no integer number between 0 and 1. 
                    // In general case condition a >= 0 should be implemented.
                    if (a >= 0)
                    {
                        // Update sum if element is not negative.
                        sum += a;
                    }
                }
                // Return the result.
                return sum;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return 0;
            }
        }
    }
}
