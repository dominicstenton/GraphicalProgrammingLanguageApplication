using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalProgrammingLanguageApplication
{
   public class square
    {
        Graphics g;
        Pen p;
        int positionX, positionY;
        Brush b;
        bool shapeFill;

        public square(Graphics g)
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

        public void createSquare(int destinationX, int destinationY)
        {

            if (shapeFill == true)
            {
                g.FillRectangle(b, positionX, positionY, positionX + destinationX, positionY + destinationY);
                g.DrawRectangle(p, positionX, positionY, positionX + destinationX, positionY + destinationY);
            }

            else
            {
                g.DrawRectangle(p, positionX, positionY, positionX + destinationX, positionY + destinationY);
            }
           

        }
    }
}
