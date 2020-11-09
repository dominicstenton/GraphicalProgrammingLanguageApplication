using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalProgrammingLanguageApplication
{
    class Circle
    {
        Graphics g;
        Pen p;
        int positionX, positionY;
        Brush b;
        bool shapeFill;

        public Circle(Graphics g)
        {
            this.g = g;
            positionX = positionY = 0;
            p = new Pen(Color.Black, 1);
            b = new SolidBrush(Color.Yellow);
        }

        public void BrushOn()
        {
            shapeFill = true;
        }

        public void BrushOff()
        {
            shapeFill = false;
        }

        public void createCircle(int radius)
        {
            if (shapeFill == true)
            {
                g.FillEllipse(b, positionX, positionY, radius *2, radius *2);
                g.DrawEllipse(p, positionX, positionY, radius *2, radius *2);
            }

            else
            {
                g.DrawEllipse(p, positionX, positionY, radius * 2, radius * 2);
            }
        }
    }
}