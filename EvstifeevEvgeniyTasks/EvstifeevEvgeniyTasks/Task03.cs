using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvstifeevEvgeniyTasks
{
    class Task03
    {
        public static void DrawSquare(uint n) {//Draw a square of stars with a space in the center
            uint half = n / 2;
            for (int i = 0; i < n; i++)//Row number
            {
                for (int k = 0; k < n; k++)//Column number
                {
                    if ((n < 3) || (k != half) || (i != half))
                    {
                        if (k < n - 1) Console.Write('*');//Draw a star
                        else Console.WriteLine('*');//Draw the last star in a row
                    }
                    else Console.Write(' ');//Draw center
                }
            }
        }
    }
}
