using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Task1_2Triangle
    {
        public static void ConsoleInterface()//An interaction interface
        {
            Triangle();
        }
        /// <summary>
        /// Draw right triangle
        /// </summary>
        public static void Triangle() { 
            int N = -1;//Number of lines
            do {
                Console.WriteLine("Enter positive integer number:");
                if (Int32.TryParse(Console.ReadLine(), out N))//Read N
                    if (N > 0)  //If N is positive
                        for (int i = 0; i < N; i++) //For every line
                            for (int k = 0; k <= i; k++)    //For each symbol of the line
                                if (k < i)  //If symbol index is less than the index of line 
                                    Console.Write('*'); //Draw the star
                                else Console.WriteLine('*');//Draw the white space instead
            } while (N < 1);//Until N is positive
        }
    }
}
