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
        Brush b;
        bool shapeFill;

        public triangle(Graphics g)
        {
            this.g = g;
            positionX = positionY = 10;
            p = new Pen(Color.Black, 1);
            b = new SolidBrush(Color.Tomato);
        }

        public void brushOn()
        {
            shapeFill = true;
        }

        public void brushOff()
        {
            shapeFill = false;
        }

        public void createTriangle(int destinationX, int destinationY)
        {

            Point[] a = { new Point(10, 10), new Point(200, 100), new Point(400, 100) };

            if (shapeFill == true)
            {
                g.FillPolygon(b, a);
                g.DrawPolygon(p, a);
                Console.WriteLine("A filled triangle has been drawn");
            }

            else
            {
                g.DrawPolygon(p, a);
                Console.WriteLine("Here");
            }


         /*   Point[] a = new Point[5];
            a[0].X = positionX + sizeGiven;
            a[0].Y = positionY + sizeGiven;

            a[1].X = a[0].X + sizeGiven;
            a[1].Y = a[0].Y + sizeGiven;

            a[2].X = a[0].X - sizeGiven;
            a[2].Y = a[0].Y + sizeGiven;
*/

            
            //Point[] a = { new Point(destinationX, destinationY), new Point(destinationX, destinationY), new Point(destinationX, destinationY) };
            //g.DrawPolygon(p, a);


        }
    }
}
