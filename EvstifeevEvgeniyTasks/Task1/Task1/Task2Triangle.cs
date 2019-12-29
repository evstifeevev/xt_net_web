using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Task2Triangle
    {
        // An interaction interface.
        internal static void ConsoleInterface()
        {
            int number = Common.ConsoleUI.ReadInt("Enter width of a triangle: ", new Predicate<int>(x => x > 0));
            Triangle(number);
        }
        /// <summary>
        /// Draw right triangle.
        /// </summary>
        internal static void Triangle(int n)
        {
            if (n > 0)  // If n is positive.
            {
                // For each line.
                for (int i = 0; i < n; i++)
                {
                    // For each symbol of the line.
                    for (int k = 0; k <= i; k++)
                    {
                        // If symbol index is less than the index of line.
                        if (k < i)
                        { 
                            // Draw the star.
                            Console.Write('*');
                        } 
                        else
                        {
                            // Draw the white space instead.
                            Console.WriteLine('*');

                        }
                    }
                }
            }
        }
    }
}
