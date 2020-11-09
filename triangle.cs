using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalProgrammingLanguageApplication
{
    class Triangle
    {
        Graphics g;
        Pen p;
        Brush b;
        bool shapeFill;

        public Triangle(Graphics g)
        {
            this.g = g;
            p = new Pen(Color.Black, 1);
            b = new SolidBrush(Color.Tomato);
        }

        public void BrushOn()
        {
            shapeFill = true;
        }

        public void BrushOff()
        {
            shapeFill = false;
        }

        public void CreateTriangle()
        {
            Point[] a = { new Point(50, 10), new Point(100, 50), new Point(200, 50) };

            if (shapeFill == true)
            {
                g.FillPolygon(b, a);
                g.DrawPolygon(p, a);
            }

            else
            {
                g.DrawPolygon(p, a);
            }
        }
    }
}
