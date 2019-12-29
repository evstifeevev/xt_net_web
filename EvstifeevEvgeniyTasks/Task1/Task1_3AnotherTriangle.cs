using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Task1_3AnotherTriangle
    {
        public static void ConsoleInterface()//An interaction interface
        {
           Triangle();
        }
        /// <summary>
        /// Draw isosceles triangle
        /// </summary>
        public static void Triangle()
        {
            int N = -1;//Number of lines
            do
            {
                Console.WriteLine("Enter positive integer number:");
                if (Int32.TryParse(Console.ReadLine(), out N))//Read N
                    if (N > 0)//If N is positive
                        for (int i = 1; i < N*2; i += 2)//For every line
                        {
                            for (int k = 1; k < N*2; k++)  //For each symbol of the line
                                if (k <= N + i / 2 && k >= N - i / 2)  //If current position is inside the triangle
                                    Console.Write('*'); //Draw the star
                                else Console.Write(' ');//Draw the white space instead
                            Console.WriteLine();//Go to the new line
                        }
            } while (N < 1);//While N is non-ppositive
        }
    }
}
