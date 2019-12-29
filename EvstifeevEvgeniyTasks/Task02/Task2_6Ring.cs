using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    class Task2_6Ring 
    {
        public static void ConsoleInterface()
        {
            //Declaring an object of type Ring with specified center coordinates, inner and outer radius 
            Task2_6Ring.Ring ring = new Task2_6Ring.Ring(0,0,10,20);
            //Printing ring's area and summary length of inner and outer circles
            Console.WriteLine("Ring area equals: " + ring.Area);
            Console.WriteLine("Summary length of inner and outer circle equals: " + ring.Length);
        }
        public class Ring : Task2_1Round.Round {
            private double _innerRadius;//Inner ring radius
            private double _outerRadius;//Outer ring radius
            /// <summary>
            /// Area of the ring
            /// </summary>
            public new double Area{ get => Math.PI * (_outerRadius * _outerRadius - _innerRadius * _innerRadius); }
            /// <summary>
            /// Summary length of inner and outer circles of the ring
            /// </summary>
            public new double Length { get => 2 * Math.PI * (_outerRadius + _innerRadius); }
            /// <summary>
            /// Creates a ring with specified center coordinates, inner and outer radius .
            /// </summary>
            /// <param name="x">Abscissa coordinate of the center</param>
            /// <param name="y">Ordinate coordinate of the center</param>
            /// <param name="innerRadius">Radius of inner circle</param>
            /// <param name="outerRadius">Radius of outer circle</param>
            public Ring(double x, double y, double innerRadius, double outerRadius)
                : base(x,y)
            {
                //Checking if inner radius is not positive
                if (innerRadius <= 0)
                    throw new ArgumentException("The inner radius value must be positive.","innerRadius");
                //Checking if outer radius is bigger than the outer one.
                if (outerRadius <= innerRadius)
                    throw new ArgumentException("The outer radius can not be less than the inner radius or be equal to it.","outerRadius");
                //Assigning inner and outer radius 
                _innerRadius = innerRadius;
                _outerRadius = outerRadius;
            }
        }
    }
}
