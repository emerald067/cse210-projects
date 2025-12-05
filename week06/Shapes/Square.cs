using System;
using System.Collections.Generic;

namespace Shape
{
    public class Square : Shape
    {
        private double _side;
        public Square(double side, string color) : base(color)
        {
            _side = side;
        }
        public double GetSide()
        {
            return _side;
        }
        public override double GetArea()
        {
            return _side * _side;
        }
    }
}