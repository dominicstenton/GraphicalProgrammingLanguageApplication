using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalProgrammingLanguageApplication
{
    class triangle
    {
        Graphics g;
        Pen p;
        int positionX, positionY;

        public triangle(Graphics g)
        {
            this.g = g;
            positionX = positionY = 0;
            p = new Pen(Color.Black, 1);
        }

        public void createTriangle(int destinationX, int destinationY)
        {
            //Point[] a = { new Point(10, 10), new Point(200, 100), new Point(400, 100) };
            Point[] a = { new Point(destinationX, destinationY), new Point(destinationX, destinationY), new Point(destinationX, destinationY) };
            g.DrawPolygon(p, a);
        }
    }
}
