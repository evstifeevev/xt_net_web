using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    class Task2_1Round
    {
        public static void ConsoleInterface() {
            Task2_1Round.Round round;//Declaring an object of type Round.
            round = new Task2_1Round.Round(5,-7.0f,10.0);//Creates new round with specified center coordinates and radius
            Console.WriteLine("Round area equals: "+round.Area);//Print value of the round area
            Console.WriteLine("Circumscribed circle's length equals: " + round.Length);//Print value of the circumscribed circle's length.
            //round = new Task2_1Round.Round(20);   //Only radius is specified
            // round = new Task2_1Round.Round(0, 0,-1); //Incorrect radius input
        }
        /// <summary>
        /// Describes round with specified center coordinates, radius and have properties
        /// that allow to find length of circumscribed circle and round area.
        /// </summary>
        internal class Round {
            protected double _x, _y;//Center coordinates default value is zero
            private double _radius;//Radius of circle
            /// <summary>
            /// Returns length of circumscribed circle
            /// </summary>
            public double Length {get => 2 * Math.PI * _radius;}
            /// <summary>
            /// Returns area of the round
            /// </summary>
            public double Area {get => Math.PI * _radius * _radius;}
            /// <summary>
            /// Creates new round with specified center coordinates and radius.
            /// If no coordinates were passed they set to default value (0,0).
            /// </summary>
            /// <param name="param"></param>
            public Round(params double[] param) {
                if (param.Length > 0 && param.Length!=2) //Check if there is enough parameters
                {
                    if (param.Length == 1)//If only radius had been passed
                    {
                        if (param[0] <= 0)//If radius is incorrect
                            throw new ArgumentException($"{param[0]} is incorrect radius value. The value must be positive.", "_radius");
                        else _radius = param[0];//Assign radius to value 
                    }
                    else { 
                        _x = param[0];//Save abscissa coordinate
                        _y = param[1];//Save ordinate coordinate
                            if(param[2] <= 0)//Check if the radius value is invalid
                                throw new ArgumentException($"{param[2]} is incorrect radius value. The value must be positive.", "_radius");
                            else _radius = param[2];//Assign radius to the value
                    }
                }
                else throw new ArgumentNullException("_radius", "Null argument must not be passed.");
            }
        }
    }
}
