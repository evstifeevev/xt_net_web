using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    class Task2_7Vector_Graphics_Editor
    {
        public static void ConsoleInterface() {
            // Declaring an object of type Ring with specified center coordinates, inner and outer radius.
            Round round = new Round(0,0,10);
            // Printing all information about figure.
            round.Show();
        }
        class Vector_Graphics_Editor
        {
            public enum FigureType {
                None = 0,
                Line = 1,
                Circle = 2,
                Round = 3,
                Ring = 4,
                REctangle = 5
            }
        }
        /// <summary>
        /// Describes point.
        /// </summary>
        public class Point
        {
            public readonly double _x, _y;
            public Point(double x, double y) {
                _x = x;
                _y = y;
            }
            public override string ToString()
            => "(" + _x.ToString() + " " + _y.ToString() + ") ";
        }
        /// <summary>
        /// Describes abstract figure.
        /// </summary>
        abstract class Figure 
        {
            protected Point[] points;
            public virtual void Show() {
                Console.WriteLine("Type of figure: " + this.GetType());
                Console.Write("Points: ");
                for (int i = 0; i < points.Length; i++)
                    Console.Write(points[i]);
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Describes line as a figure.
        /// </summary>
        class Line : Figure
        {
            public double Length { get => Math.Sqrt((this.points[0]._x-points[1]._x)* (this.points[0]._x - points[1]._x)+
                (this.points[0]._y - points[1]._y) * (this.points[0]._y - points[1]._y) ); }
            public Line() { }
            public Line(double x1, double x2, double y1, double y2) {
                this.points = new Point[]{new Point(x1, y1),new Point(x2,y2)};
            }
            public Line(Point point1, Point point2)
            {
                this.points = new Point[] {point1, point2};
            }
            public override void Show()
            {
                base.Show();
                Console.Write("Points: ");
                for (int i = 0; i < points.Length; i++)
                    Console.Write(points[i]);
                Console.WriteLine();
                Console.WriteLine("Length: ", Length);
            }
        }
        /// <summary>
        /// Describes ractangle as a figure.
        /// </summary>
        class Rectangle : Figure
        {
            readonly Line[] lines = new Line[4];
            public double Width { get =>  lines[0].Length; }
            public double Height { get => lines[1].Length; }
            public Rectangle(double x, double y, double horizontalSize, double verticalSize) {
                this.points = new Point[] { new Point(x, y), new Point(x+ horizontalSize, y),
                     new Point(x+ horizontalSize, y+ verticalSize),new Point(x, y+ verticalSize) };
                for(int i=0;i<4;i++)
                lines[i] = new Line(points[i],points[(i+1)%4]);
            }
            public override void Show()
            {
                base.Show();
                Console.Write("Lines: ");
                for (int i = 0; i < lines.Length; i++) 
                {
                    Console.Write($"line №{i+1}: ");
                    lines[i].Show();
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Describes circle as a figure.
        /// </summary>
        class Circle : Figure 
        {
            public double Length { get => 2 * Math.PI * _radius; }
            protected double _radius;
            protected Circle() { }
            public Circle(double x, double y, double radius) {
                if (radius <= 0)
                    throw new ArgumentException("The value of radius must be positive.", "radius");
                _radius = radius;
                points = new Point[]{ new Point(x, y)};
            }
            public override void Show()
            {
                base.Show();
                Console.WriteLine(nameof(_radius)+" "+_radius);
            }
        }
        /// <summary>
        /// Describes round as a figure.
        /// </summary>
        class Round : Circle
        {
            /// <summary>
            /// Returns round area.
            /// </summary>
            public double Area { get => Math.PI * _radius; }
            /// <summary>
            /// Constructor for derived classes.
            /// </summary>
            protected Round() { }
            /// <summary>
            /// Creates a round with specified center coordinates and radius.
            /// </summary>
            /// <param name="x">Abscissa coordinate of the center.</param>
            /// <param name="y">Ordinate coordinate of the center.</param>
            /// <param name="radius">Radius of the round.</param>
            public Round(double x, double y, double radius) : base(x, y, radius) {
            }
        }
        /// <summary>
        /// Describes ring as a figure.
        /// </summary>
        class Ring : Circle
        {
            // Inner ring radius.
            private readonly double _innerRadius;
            // Outer ring radius.
            private readonly double _outerRadius;
            /// <summary>
            /// Returns ring area.
            /// </summary>
            public double Area { get { return Math.PI * (_outerRadius * _outerRadius - _innerRadius * _innerRadius); } }
            /// <summary>
            /// Returns summary length of inner and outer circles of the ring.
            /// </summary>
            public new double Length { get { return 2 * Math.PI * (_outerRadius + _innerRadius); } }
            /// <summary>
            /// Creates a ring with specified center coordinates, inner and outer radius.
            /// </summary>
            /// <param name="x">Abscissa coordinate of the center.</param>
            /// <param name="y">Ordinate coordinate of the center.</param>
            /// <param name="innerRadius">Radius of inner circle.</param>
            /// <param name="outerRadius">Radius of outer circle.</param>
            public Ring(double x, double y, double innerRadius, double outerRadius)
            {
                // Checking if inner radius is not positive.
                if (innerRadius <= 0)
                    throw new ArgumentException("The inner radius value must be positive.", "innerRadius");
                // Checking if outer radius is bigger than the outer one.
                if (outerRadius <= innerRadius)
                    throw new ArgumentException("The outer radius can not be less than the inner radius or be equal to it.", "outerRadius");
                // Assigning center point, inner and outer radius.
                points = new Point[] { new Point(x, y) };
                _innerRadius = innerRadius;
                _outerRadius = outerRadius;
            }
            public override void Show()
            {
                base.Show();
                Console.WriteLine(nameof(_innerRadius) + " " + _innerRadius);
                Console.WriteLine(nameof(_outerRadius) + " " + _outerRadius);
            }
        }
    }
}
