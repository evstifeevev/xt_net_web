using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task0.Task03
{
    internal class Square
    {
        // Draws a square of stars with a space in the center
        internal static void DrawSquare(uint n)
        {
            uint half = n / 2;
            // Row number
            for (int i = 0; i < n; i++)
            {
                // Column number
                for (int k = 0; k < n; k++)
                {
                    if ((n < 3) || (k != half) || (i != half))
                    {
                        // Draw a star
                        if (k < n - 1)
                        {
                            Console.Write('*');
                        }
                        else
                        { // Draw the last star in a row
                            Console.WriteLine('*');
                        }
                    }
                    else
                    {
                        // Draw center
                        Console.Write(' ');
                    }
                }
            }
        }
    }
}
