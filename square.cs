using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalProgrammingLanguageApplication
{
    class square
    {
        Graphics g;
        Pen p;
        int positionX, positionY;

        public square(Graphics g)
        {
            this.g = g;
            positionX = positionY = 0;
            p = new Pen(Color.Black, 1);
        }
    
        public void createSquare(int destinationX, int destinationY)
        {
            g.DrawRectangle(p, positionX, positionY, positionX + destinationX, positionY + destinationY);
        }
    }
}
