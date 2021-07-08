using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalProgrammingLanguageApplication
{
    public class Circle
    {
        Graphics g;
        Pen p;
        int positionX, positionY;
        Brush b;
        bool shapeFill;

        public Circle(Graphics g)
        {
            this.g = g;
            positionX = positionY = 10;
            p = new Pen(Color.Black, 3);
            b = new SolidBrush(Color.Yellow);
        }

        //Fill shape enabled
        public void BrushOn()
        {
            shapeFill = true;
        }

        //Fill shape disabled
        public void BrushOff()
        {
            shapeFill = false;
        }

        //Circle being generated
        public void createCircle(int radius)
        {
            if (shapeFill == true)
            {
                g.FillEllipse(b, positionX, positionY, radius * 2, radius * 2);
                g.DrawEllipse(p, positionX, positionY, radius * 2, radius * 2);
            }

            else
            {
                g.DrawEllipse(p, positionX, positionY, radius * 2, radius * 2);
            }
        }
    }
}