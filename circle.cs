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
        bool shapeFill;

        public circle(Graphics g)
        {
            this.g = g;
            positionX = positionY = 10;
            p = new Pen(Color.Black, 1);
            b = new SolidBrush(Color.Yellow);
        }

        public void brushOn()
        {
            shapeFill = true;
        }

        public void brushOff()
        {
            shapeFill = false;
        }

        public void createCircle(int radius)
        {
            if (shapeFill == true)
            {
                g.FillEllipse(b, positionX, positionY, radius *2, radius *2);
                g.DrawEllipse(p, positionX, positionY, radius *2, radius *2);
                Console.WriteLine("A filled circle has been drawn");
            }

            else
            {
                g.DrawEllipse(p, positionX, positionY, radius * 2, radius * 2);
            }
            
        }
    }
}