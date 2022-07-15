using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafariParkApp.Misc
{
    public abstract class Shape
    {
        public abstract int CalculateArea();
        public override string ToString()
        {
            return "This is a shape";
        }
    }

    public class Rectangle : Shape
    {
        private int _length;
        private int _width;

        public Rectangle(int length, int width)
        {
            _length = length;
            _width = width;

        }

        public override string ToString()
        {
            return "This is a rectangle";
        }

        public override int CalculateArea()
        {
            return _length * _width;
        }
    }
}
