using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Task1Rectangle
    {
        /// <summary>
        /// An interaction interface.
        /// </summary>
        internal static void ConsoleInterface()  
        {
            float[] rectangleSide = new float[2]; // Sides of the rectangle. 
            byte i = 0; // Number of inputed sides.
            do
            {
                byte k = 0;// Index of typed-in line.
                if(i==0)
                    Console.WriteLine("Enter both sides of rectangular:");
                else Console.WriteLine("Enter second side of rectangular:");
                try
                {
                    // Split the line to several words.
                    string[] EnteredLine = Console.ReadLine().Split(' ', '\n', '\r');
                    // Put all words into array.
                    while (EnteredLine.Length > 0 && k < EnteredLine.Length && k<2)
                    {
                        rectangleSide[i] = Convert.ToSingle(EnteredLine[k]);
                        k++;
                        i++;
                    }   
                }
                catch (FormatException e) {
                    Console.WriteLine(e+". The string was empty");
                }
            } while (i < 2);
            // Call the method with an array.
            RectangleArea(rectangleSide);
            Console.WriteLine();
        }
        /// <summary>
        /// Calculate area of the rectangle.
        /// </summary>
        internal static void RectangleArea(params float[] rectangleSides) {
            // Handle error of non-positive sides
            if (rectangleSides[0] <= 0) { Console.WriteLine("Error. Entered width is not positive."); return; }
                if (rectangleSides[1] <= 0) {Console.WriteLine("Error. Entered height is not positive."); return;}
            Console.WriteLine("The rectange area equals "+ rectangleSides[0] * rectangleSides[1]);
        }
    }
}
