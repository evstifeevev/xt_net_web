using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    class Task2_1Round
    {
        public static void ConsoleInterface()
        {
            // Declaring an object of type Round.
            Task2_1Round.Round round;
            // Creates new round with specified center coordinates and radius.
            round = new Task2_1Round.Round(5, -7.0f, 10.0);
            // Print value of the round area.
            Console.WriteLine("Round area equals: " + round.Area);
            // Print value of the circumscribed circle's length.
            Console.WriteLine("Circumscribed circle's length equals: " + round.Length);
            // Only radius is specified.
            // round = new Task2_1Round.Round(20); 
            // Incorrect radius input.
            // round = new Task2_1Round.Round(0, 0,-1); 
        }
        /// <summary>
        /// Describes round with specified center coordinates, radius and have properties
        /// that allow to find length of circumscribed circle and round area.
        /// </summary>
        internal class Round
        {
            // Center coordinates default value is zero.
            protected double _x, _y;
            // Radius of circle.
            private readonly double _radius;
            /// <summary>
            /// Returns length of circumscribed circle.
            /// </summary>
            public double Length { get => 2 * Math.PI * _radius; }
            /// <summary>
            /// Returns area of the round.
            /// </summary>
            public double Area { get => Math.PI * _radius * _radius; }
            /// <summary>
            /// Creates new round with specified center coordinates and radius.
            /// If no coordinates were passed they set to default value (0,0).
            /// </summary>
            /// <param name="param"></param>
            public Round(params double[] param)
            {
                // Check if there is enough parameters.
                if (param.Length > 0 && param.Length != 2)
                {
                    // If only radius had been passed.
                    if (param.Length == 1)
                    {
                        // If radius is incorrect.
                        if (param[0] <= 0)
                        {
                            throw new ArgumentException($"{param[0]} is incorrect radius value. The value must be positive.", "_radius");

                        }
                        else
                        {// Assign radius to value 
                            _radius = param[0];

                        }
                    }
                    else
                    {
                        // Save abscissa coordinate.
                        _x = param[0];
                        // Save ordinate coordinate.
                        _y = param[1];
                        // Check if the radius value is invalid.
                        if (param[2] <= 0)
                        {
                            throw new ArgumentException($"{param[2]} is incorrect radius value. The value must be positive.", "_radius");
                        }
                        // Assign radius to the value.
                        _radius = param[2];
                    }
                }
                else throw new ArgumentNullException("_radius", "Null argument must not be passed.");
            }
        }
    }
}
