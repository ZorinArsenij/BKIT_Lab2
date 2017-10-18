using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace lab2
{
	class MainClass
    {
		static double InputValue(string prompt)
		{
			double a = 0;
			do
				Console.Write(prompt);
			while (!double.TryParse(Console.ReadLine(), out a));
			return a;
		}


		public static void Main(string[] args)
        {
            Console.WriteLine("Введите параметры прямоугольника");
            double width = InputValue("Введите ширину прямоугольника:");
            double height = InputValue("Введите высоту прямоугольника:");
            Rectangle rect = new Rectangle(width, height);
            rect.Print();
            Console.WriteLine("Введите параметры квадрата");
            double length = InputValue("Введите сторону квадрата:");
            Square sq = new Square(length);
            sq.Print();
            Console.WriteLine("Введите параметры окружности");
            double radius = InputValue("Введите радиус окружности:");
            Circle circ = new Circle(radius);
            circ.Print();

        }
    }

    interface IPrint 
    {
        void Print();
    }


	abstract class GeometricFigure
	{
        public abstract double Area();
    }

    class Rectangle: GeometricFigure, IPrint
    {
        private double _width;
        private double _height;

		public Rectangle(double w, double h)
		{
			width = w;
			height = h;
		}

		public double width 
        {
            get { return _width; }
            private set { _width = value; }
        }

        public double height 
        {
            get { return _height;  }
            private set { _height = value; }
        }

        public override double Area() {
            return width * height;
        }

        public override string ToString()
        {
            return string.Format("[Rectangle: width = {0}, height = {1}, area = {2}]", width, height, Area());
        }

        public void Print() 
        {
            Console.WriteLine(this);
        }
    }

    class Square: Rectangle, IPrint
    {
        public Square(double l) : base(l, l) {}

        public override string ToString()
        {
            return string.Format("[Square: length = {0}, area = {1}]", height, Area());
        }
    }

    class Circle: GeometricFigure, IPrint
    {
        private double _radius;

        public Circle (double r) {
            radius = r;
        }

        public double radius
        {
            get { return _radius; }
            private set { _radius = value; }
        }

        public override double Area() 
        {
            return Math.PI * radius * radius;
        }

        public override string ToString()
        {
            return string.Format("[Circle: radius = {0}, area = {1}]", radius, Area());
        }

		public void Print()
		{
			Console.WriteLine(this);
		}
    }
}
