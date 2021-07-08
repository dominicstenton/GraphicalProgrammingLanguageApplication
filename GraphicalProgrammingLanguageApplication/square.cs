using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalProgrammingLanguageApplication
{
    public class Square
    {
        Graphics g;
        Pen p;
        int positionX, positionY;
        Brush b;
        bool shapeFill;

        public Square(Graphics g)
        {
            this.g = g;
            positionX = positionY = 10;
            p = new Pen(Color.Black, 3);
            b = new SolidBrush(Color.LightBlue);
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

        //Square being generated
        public void createSquare(int width, int length)
        {
            if (shapeFill == true)
            {
                g.FillRectangle(b, positionX, positionY, width, length);
                g.DrawRectangle(p, positionX, positionY, width, length);
            }

            else
            {
                g.DrawRectangle(p, positionX, positionY, width, length);
            }
        }
    }
}