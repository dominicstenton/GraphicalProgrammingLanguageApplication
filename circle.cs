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
            b = new SolidBrush(Color.LightBlue);
        }

        public void brushOn()
        {
            shapeFill = true;
        }

        public void brushOff()
        {
            shapeFill = false;
        }

        public void createCircle(int destinationX, int destinationY)
        {
            if (shapeFill == true)
            {
                g.FillEllipse(b, positionX, positionY, destinationX, destinationY);
                g.DrawEllipse(p, positionX, positionY, destinationX, destinationY);
                Console.WriteLine("Here");
            }

            else
            {
                g.DrawEllipse(p, positionX, positionY, destinationX, destinationY);
            }
            
        }
    }
}