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
            Task2_6Ring.Ring ring;
            ring = new Task2_6Ring.Ring(0,0,10,20);
            Console.WriteLine("Ring area equals: " + ring.Area);
            Console.WriteLine("Summary length of inner and outer circle equals: " + ring.Length);
        }
        public class Ring : Task2_1Round.Round {
            private double _innerRadius;//Inner ring radius
            private double _outerRadius;//Outer ring radius
            public new double Area{ get { return Math.PI * (_outerRadius * _outerRadius - _innerRadius * _innerRadius); } }
            public new double Length { get { return 2 * Math.PI * (_outerRadius + _innerRadius); } }
            public Ring(double x, double y, double innerRadius, double outerRadius)
                : base(x,y)
            {
                if (innerRadius <= 0)
                    throw new ArgumentException("The inner radius value must be positive.","innerRadius");
                if (outerRadius <= innerRadius)
                    throw new ArgumentException("The outer radius can not be less than the inner radius or be equal to it.","outerRadius");
                _innerRadius = innerRadius;
                _outerRadius = outerRadius;
            }
        }
    }
}
