using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Task1_4X_masTree
    {
        public static void ConsoleInterface()//An interaction interface
        {
            DrawXmasTree();
        }
        /// <summary>
        /// Draw X-mas tree - a sequence of isosceles triangles sorted  
        /// by their sizes in descending order
        /// </summary>
        public static void DrawXmasTree()
        {
            int N, NumberOfTriangles = -1;//Number of lines and number of triangles
            do
            {
                Console.WriteLine("Enter the positive number of triangles:");
                if (Int32.TryParse(Console.ReadLine(), out NumberOfTriangles))//Read number of triangles
                    if (NumberOfTriangles > 0)//If the number is positive
                        for(N=1;N<=NumberOfTriangles;N++)//For every triangle
                        for (int i = 1; i < N * 2; i += 2)//For every line of the triangle
                        {
                            for (int k = 1; k < NumberOfTriangles * 2; k++)//For each symbol of the line
                                if (k <= NumberOfTriangles + i / 2 && k >= NumberOfTriangles - i / 2)//If current position
                                        //is inside current triangle
                                    Console.Write('*');//Draw star
                                else Console.Write(' ');//Draw white space instead
                            Console.WriteLine();//Go to the new line
                        }
            } while (NumberOfTriangles < 1);//Until number of triangles is positive
        }
    }
}
