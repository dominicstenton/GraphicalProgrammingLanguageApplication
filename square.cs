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
            p = new Pen(Color.Black, 1);
            b = new SolidBrush(Color.LightBlue);
        }

        public void BrushOn()
        {
            shapeFill = true;
        }

        public void BrushOff()
        {
            shapeFill = false;
        }

        public void createSquare(int destinationX, int destinationY)
        {

            if (shapeFill == true)
            {
                g.FillRectangle(b, positionX, positionY, positionX + destinationX, positionY + destinationY);
                g.DrawRectangle(p, positionX, positionY, positionX + destinationX, positionY + destinationY);
              //  Console.WriteLine("A filled Square has been drawn!");
            }

            else
            {
                g.DrawRectangle(p, positionX, positionY, positionX + destinationX, positionY + destinationY);
               // Console.WriteLine("A Square has been drawn!");
            }
        }
    }
}
