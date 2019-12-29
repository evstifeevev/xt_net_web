using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Task3AnotherTriangle
    {
        // An interaction interface.
        internal static void ConsoleInterface()
        {
            int number = Common.ConsoleUI.ReadInt("Enter width of a triangle: ", new Predicate<int>(x => x > 0));

        }
        /// <summary>
        /// Draw isosceles triangle.
        /// </summary>
        /// <param name="n"></param>
        internal static void Triangle(int n)
        {
            if (n > 0)//If n is positive.
            {
                //Each line.
                for (int i = 1; i < n * 2; i += 2)
                {
                    //Each symbol of the line.
                    for (int k = 1; k < n * 2; k++)
                    {
                        // If current position is inside the triangle.
                        if (k <= n + i / 2 && k >= n - i / 2)
                        {
                            // Draw the star.
                            Console.Write('*');
                        }
                        else
                        {
                            // Draw the white space instead.
                            Console.Write(' ');
                        }
                        // Go to the new line.
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
