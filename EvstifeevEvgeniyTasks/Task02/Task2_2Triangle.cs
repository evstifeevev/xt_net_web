using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    class Task2_2Triangle
    {
        public static void ConsoleInterface()
        {
            //Declaring an object of type Triangle with specified parameters
            Task2_2Triangle.Triangle triangle = new Task2_2Triangle.Triangle(0,0,3,-1,7,0);
            //Printing every side of the triangle
            for (int i = 0; i < 3; i++) 
                Console.Write($"side №{i + 1} = "+triangle.Sides[i]+"; ");
            //Printing triangle area
            Console.WriteLine(Environment.NewLine+"Triangle area equals: " + triangle.Area);
            //Printing triangle perimeter
            Console.WriteLine("Triangle perimeter equals: " + triangle.Perimeter);

        }
        /// <summary>
        /// Describes triangle with specified coordinates of the apices and have such properties as 
        /// perimeter and area.
        /// </summary>
        internal class Triangle
        {
            /// <summary>
            /// Apices coordinates 
            /// </summary>
            private readonly double[] _apicesCoordinates = new double[6];
            /// <summary>
            /// Sides of the triangle
            /// </summary>
            public double[] Sides;
            /// <summary>
            /// Return distance between two points described by their coordinates
            /// </summary>
            private double GetDistance(double x1, double y1, double x2, double y2) 
                => Math.Sqrt((x1-x2) * (x1-x2)+(y1-y2)*(y1-y2));
            public double Perimeter {
                get => Sides.Sum(); }
            public double HalfPerimeter
            {
                get => 0.5f*Perimeter; 
            }
            public double Area
            {
                get
                {
                    return Math.Sqrt(HalfPerimeter*(HalfPerimeter-Sides[0])* (HalfPerimeter - Sides[1])* (HalfPerimeter - Sides[2]));
                }
            }
            /// <summary>
            /// Creates new triangle with specified apices coordinates.
            /// </summary>
            /// <param name="param"></param>
            public Triangle(params double[] param)
            {
                //Checking if there is enough parameters
                if (param != null && param.Length > 5)
                {
                    //Checking if two apices coordinates reference to the same point
                    if ((param[0] == param[2] && param[1] == param[3])
                        || (param[0] == param[4] && param[1] == param[5])
                        || (param[4] == param[2] && param[5] == param[3]))
                        throw new ArgumentException("Incorrect input. Two apices coordinates reference to the same point.", "_apicesCoordinates");
                    //Checking if all points references to the same line
                    for (int i = 0; i < 2; i++)
                        if (_apicesCoordinates[i] == _apicesCoordinates[i + 2] && _apicesCoordinates[i + 4] == _apicesCoordinates[i])
                            throw new ArgumentException("Incorrect input. All points are on the same line.", "_apicesCoordinates");
                    for (int i = 0; i < 6; i++) _apicesCoordinates[i] = param[i];
                    Sides = new double[3] { GetDistance(_apicesCoordinates[0], _apicesCoordinates[1], _apicesCoordinates[2], _apicesCoordinates[3]),
                        GetDistance(_apicesCoordinates[2], _apicesCoordinates[3], _apicesCoordinates[4], _apicesCoordinates[5]),
                        GetDistance(_apicesCoordinates[4], _apicesCoordinates[5], _apicesCoordinates[0], _apicesCoordinates[1]) };
                }
                else throw new ArgumentException("Six parameters must be passed.");
            }
        }
    }
}
