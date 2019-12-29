using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Task1_1Rectangle
    {
        /// <summary>
        /// An interaction interface
        /// </summary>
        public static void ConsoleInterface()  
        {
            float[] rectangleSide = new float[2]; //Sides of the rectangular 
            byte i = 0;//number of inputed sides
            do
            {
                byte k = 0;//Index of typed-in line
                if(i==0)
                    Console.WriteLine("Enter both sides of rectangular:");
                else Console.WriteLine("Enter second side of rectangular:");
                try
                {
                    string[] EnteredLine = Console.ReadLine().Split(' ', '\n', '\r');//Split the line to several words
                    while (EnteredLine.Length > 0 && k < EnteredLine.Length && k<2)//Put all words into array
                    {
                        rectangleSide[i] = Convert.ToSingle(EnteredLine[k]);
                        k++;
                        i++;
                    }   
                }
                catch (FormatException e) {
                    Console.WriteLine(e+". The string was empty");
                }
               // if (i < 2) Console.WriteLine("Error. Not enough inputs.");
            } while (i < 2);
            RectangleArea(rectangleSide);//Call the method with an array
            Console.WriteLine();
            //RectangleArea(rectangleSide[0],rectangleSide[1]);//Call the method with variables separately
        }
        /// <summary>
        /// Calculate area of the rectangle
        /// </summary>
        public static void RectangleArea(params float[] rectangleSides) {
            //Handle error of non-positive sides
            if (rectangleSides[0] <= 0) { Console.WriteLine("Error. Entered width is not positive."); return; }
                if (rectangleSides[1] <= 0) {Console.WriteLine("Error. Entered height is not positive."); return;}
            Console.WriteLine("The rectange area equals "+ rectangleSides[0] * rectangleSides[1]);
        }
    }
}
