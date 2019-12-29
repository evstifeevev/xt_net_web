using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Task4XmasTree
    {
        // An interaction interface.
        internal static void ConsoleInterface()
        {
            int number = Common.ConsoleUI.ReadInt("Enter the positive number of triangles:",
                new Predicate<int>(x => x > 0));
            DrawXmasTree(number);
        }
        /// <summary>
        /// Draw X-mas tree - a sequence of isosceles triangles sorted 
        /// by their sizes in descending order.
        /// </summary>
        internal static void DrawXmasTree(int NumberOfTriangles)
        {
            // If the number is positive.
            if (NumberOfTriangles > 0)
            {
                // For every triangle.
                for (int n = 1; n <= NumberOfTriangles; n++)
                {
                    // For every line of the triangle.
                    for (int i = 1; i < n * 2; i += 2)
                    {
                        //For each symbol of the line.
                        for (int k = 1; k < NumberOfTriangles * 2; k++)
                        {
                            //If current position.
                            //is inside current triangle.
                            if (k <= NumberOfTriangles + i / 2 && k >= NumberOfTriangles - i / 2)
                            {
                                //Draw star.
                                Console.Write('*');
                            }
                            else
                            {
                                // Draw white space instead.
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
}
