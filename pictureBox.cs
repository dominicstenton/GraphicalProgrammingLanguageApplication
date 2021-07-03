using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicalProgrammingLanguageApplication
{
   public class PictureBox
    {
        Graphics g;
        Pen p;
        Brush b;
        int positionX;
        int positionY;
        bool testing;

        public PictureBox(Graphics g)
        {
            this.g = g;
            p = new Pen(Color.Black, 3);
        }

        //Test included for class Picture Box
        public PictureBox()
            {
            testing = true;
            }

        //Line being draw to the PictureBox
        public void drawLine(int destinationX, int destinationY)
        {
            g.DrawLine(p, positionX, positionY, destinationX, destinationY);
            positionX = destinationX;
            positionY = destinationY;

            //Testing if statement 
            if (testing == false)
            {
                g.DrawLine(p, positionX, positionY, destinationX, destinationY);
            }
        }

        //MoveTo command being given parameters
        public void MoveLine(int destinationX, int destinationY)
        {
            positionX = destinationX;
            positionY = destinationY;
        }

        //Penred command
        public void ChangePenRed()
        {
            p.Color = Color.Red;
        }

        //Penblue command
        public void ChangePenBlue()
        {
            p.Color = Color.Blue;
        }

        //Pengreen command
        public void ChangePenGreen()
        {
            p.Color = Color.Green;
        }

        //Filling the square command being assigned with the appropriate parameters
        public void FillSquare(PaintEventArgs e, int destinationX, int destinationY)
        {
            e.Graphics.FillRectangle(b, positionX, positionY, positionX + destinationX, positionY + destinationY);
        }

        //Filling the circle command being assigned with the appropriate parameters
        public void FillCircle(PaintEventArgs e, int destinationX, int destinationY)
        {
            e.Graphics.FillEllipse(b, positionX, positionY, destinationX, destinationY);
        }

        //Filling the triangle command being assigned with the appropriate parameters
        public void FillTriangle(PaintEventArgs e, int destinationX, int destinationY)
        {
            Point[] a = { new Point(10, 10), new Point(200, 100), new Point(400, 100) };
            e.Graphics.FillPolygon(b, a);
        }

        //Clear canvas command
        public void ClearCanvas()
        {
           g.Clear(Color.Transparent);
        }

        //Reset pen position command
        public void ResetPen(int destinationX, int destinationY)
        {
            destinationX = 0;
            destinationY = 0;
            positionX = destinationX;
            positionY = destinationY;
        }
    }
}
