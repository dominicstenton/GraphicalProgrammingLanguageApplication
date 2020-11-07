using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalProgrammingLanguageApplication
{
    class circle
    {
        Graphics g;
        Pen p;
        int positionX, positionY;
        Brush b;

        public circle(Graphics g)
        {
            this.g = g;
            positionX = positionY = 10;
            p = new Pen(Color.Black, 1);
        }

        public void createCircle(int destinationX, int destinationY)
        {
            g.DrawEllipse(p, positionX, positionY, destinationX, destinationY);
        }
    }
}
