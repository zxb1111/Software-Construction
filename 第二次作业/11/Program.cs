using System;
using System.Collections.Generic;

namespace ShapeDemo
{
    // 抽象类
    abstract class Shape
    {
        // 计算面积
        public abstract double GetArea();

        // 判断是否合法
        public abstract bool IsValid();
    }

    // 长方形
    class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public override bool IsValid()
        {
            return Width > 0 && Height > 0;
        }

        public override double GetArea()
        {
            return IsValid() ? Width * Height : 0;
        }
    }

    // 正方形
    class Square : Shape
    {
        public double Side { get; set; }

        public Square(double side)
        {
            Side = side;
        }

        public override bool IsValid()
        {
            return Side > 0;
        }

        public override double GetArea()
        {
            return IsValid() ? Side * Side : 0;
        }
    }

    // 圆形
    class Circle : Shape
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public override bool IsValid()
        {
            return Radius > 0;
        }

        public override double GetArea()
        {
            return IsValid() ? Math.PI * Radius * Radius : 0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            List<Shape> shapes = new List<Shape>();

            // 随机创建10个形状
            for (int i = 0; i < 10; i++)
            {
                int type = rand.Next(3); // 0,1,2

                switch (type)
                {
                    case 0:
                        shapes.Add(new Rectangle(rand.Next(-5, 10), rand.Next(-5, 10)));
                        break;
                    case 1:
                        shapes.Add(new Square(rand.Next(-5, 10)));
                        break;
                    case 2:
                        shapes.Add(new Circle(rand.Next(-5, 10)));
                        break;
                }
            }

            double totalArea = 0;

            foreach (var shape in shapes)
            {
                double area = shape.GetArea();
                totalArea += area;

                Console.WriteLine($"{shape.GetType().Name} 面积: {area}");
            }

            Console.WriteLine($"总面积: {totalArea}");
        }
    }
}
