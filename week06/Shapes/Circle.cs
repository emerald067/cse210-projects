using System;
using System.Collections.Generic;

namespace Shape
{
    public class Circle : Shape
    {
        private double _radius;
        public Circle(double radius, string color) : base(color)
        {
            _radius = radius;
        }

        public double GetRadius()
        {
            return _radius;
        }

        public override double GetArea()
        {
            return Math.PI * _radius * _radius;
        }
    }
}