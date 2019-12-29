using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Task1_5SumOfNumbers
    {
        public static void ConsoleInterface()//An interaction interface
        {
            Task1_5SumOfNumbers.WriteSum();
            Task1_5SumOfNumbers.WriteSumImproved();
        }
        /// <summary>
        /// Write sum of all numbers less than 1000 and multiple of number 3 or 5
        /// </summary>
        public static void WriteSum() {
            int s = 0;//The result
            int max = 1000;//The upper exclusive boundary of the verifiable numbers
            for (int i = 3; i < max; i++)//For every number that is less than max
                if (i % 5 == 0 || i % 3 == 0) { //If the number is a multiple of 3 or 5
                    s += i;//Increase the sum
                }
            Console.WriteLine($"Sum of all numbers less than {max}");
            Console.WriteLine(s);//Output the result
        }
        /// <summary>
        /// Write sum of all numbers less than 1000 and multiple of number 3 and 5.
        /// Improved algorithm that uses less amount of iterations
        /// </summary>
        public static void WriteSumImproved()
        {
            int s = 0;//The result
            int max = 1000;//The upper exclusive boundary of the verifiable numbers
            for (int i = 3, j = 5; i < max; i += 3, j += 5)//For every number that is less than max and 
                //is a multiple of 3 and 5
            { s += i;//Increase the sum
                if (j < max && j % 3 != 0) s += j;//Increase the sum if 
                //there is no collisions between i and j (15, for example)
            }
            Console.WriteLine($"Summ of all numbers less than {max}");
            Console.WriteLine(s);//Output the result
        }
    }
}
