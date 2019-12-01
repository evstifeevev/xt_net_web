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
            Round round = new Round(0,0,1);
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
            public static void FigureShow<T>(T figure)
            where T : Task2_1Round.Round
            { 
            }
        }
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
        class Figure 
        {
            protected Point[] points;
            public virtual void Show() {
                Console.WriteLine("Type of figure: " + this.GetType());
                Console.Write("Points: ");
                for (int i = 0; i < points.Length; i++)
                    Console.Write(points[i]);
            }
            //protected string TypeOfFigure(Figure figure)
            //    => "Type of figure: " + (figure).GetType();
        }
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
        }
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
            }
        }
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
        }
        class Round : Circle
        {
            private readonly new double _radius;
            public double Area { get => Math.PI * _radius; }
            protected Round() { }
            public Round(double x, double y, double radius) : base(x, y, radius) {
                _radius = radius;
            }
        }
        class Ring : Round
        {
            private readonly double _innerRadius;//Inner ring radius
            private readonly double _outerRadius;//Outer ring radius
            public new double Area { get { return Math.PI * (_outerRadius * _outerRadius - _innerRadius * _innerRadius); } }
            public new double Length { get { return 2 * Math.PI * (_outerRadius + _innerRadius); } }
            public Ring(double x, double y, double innerRadius, double outerRadius)
            {
                points = new Point[] { new Point(x, y) };
                if (innerRadius <= 0)
                    throw new ArgumentException("The inner radius value must be positive.", "innerRadius");
                if (outerRadius <= innerRadius)
                    throw new ArgumentException("The outer radius can not be less than the inner radius or be equal to it.", "outerRadius");
                _innerRadius = innerRadius;
                _outerRadius = outerRadius;
            }
        }
    }
}
