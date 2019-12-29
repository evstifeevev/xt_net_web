using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Task5SumOfNumbers
    {
        // An interaction interface.
        internal static void ConsoleInterface()
        {
            Task5SumOfNumbers.WriteSum();
            Task5SumOfNumbers.WriteSumImproved();
        }
        /// <summary>
        /// Write sum of all numbers less than 1000 and multiple of number 3 or 5.
        /// </summary>
        internal static void WriteSum() {
            // The result.
            int s = 0;
            // The upper exclusive boundary of the verifiable numbers.
            int max = 1000;
            // For every number that is less than max.
            for (int i = 3; i < max; i++) {
                // If the number is a multiple of 3 or 5.
                if (i % 5 == 0 || i % 3 == 0) 
                {
                    // Increase the sum.
                    s += i;
                }
            }
            Console.WriteLine($"Sum of all numbers less than {max}");
            // Output the result
            Console.WriteLine(s);
        }
        /// <summary>
        /// Write sum of all numbers less than 1000 and multiple of number 3 and 5.
        /// Improved algorithm that uses less amount of iterations.
        /// </summary>
        internal static void WriteSumImproved()
        {
            // The result.
            int s = 0;
            // The upper exclusive boundary of the verifiable numbers.
            int max = 1000;
            // For every number that is less than max and 
            // is a multiple of 3 and 5.
            for (int i = 3, j = 5; i < max; i += 3, j += 5)
            {
                // Increase the sum.
                s += i;
                // Increase the sum if 
                // there is no collisions between i and j (15, for example).
                if (j < max && j % 3 != 0) s += j;
            }
            Console.WriteLine($"Summ of all numbers less than {max}");
            // Output the result.
            Console.WriteLine(s);
        }
    }
}
