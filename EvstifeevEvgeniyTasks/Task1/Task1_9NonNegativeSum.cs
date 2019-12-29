using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Task1_9NonNegativeSum
    {
        public static void ConsoleInterface()//An interaction interface
        {
            Random rand = new Random();//Create new instance of Random class
            int[] arrayOneDimensional = new int[10];//Create new array of integer numbers with length equals 10
            Task1_7ArrayProcessing.InitializeArray(arrayOneDimensional);//Assign all elements to random numbers
            Task1_7ArrayProcessing.Show(arrayOneDimensional);//Display all elements
            Console.WriteLine("The summ of non-negative elements equals to " +
                NonNegativeSum(arrayOneDimensional));//Display sum of all non-negative values
            arrayOneDimensional = null;
            Task1_7ArrayProcessing.InitializeArray(arrayOneDimensional);//Assign all elements to random numbers
            Task1_7ArrayProcessing.Show(arrayOneDimensional);//Display all elements
            Console.WriteLine("The summ of non-negative elements equals to " +
                NonNegativeSum(arrayOneDimensional));//Display sum of all non-negative values
        }
        /// <summary>
        /// Returns sum of all non-negative values.  If any exception occures - returns 0.
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static int NonNegativeSum(int[] array) {
            try
            {
                int sum = 0;//Reset the sum
                foreach (var a in array) //For each element of array
                    if (a >= 0) sum += a; //Update sum if element is not negative.
                                          //Note: in this case condition a > 0 also is correct,
                                          //because there is no integer number between 0 and 1. 
                                          //In general case condition a >= 0 should be implemented.
                return sum;//Return the result
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return 0;
            }
        }
    }
}
