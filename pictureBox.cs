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
            positionX = positionY = 0;
            p = new Pen(Color.Black, 1);
        }

        //TEST
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

            //TEST
            if (testing == false)
            {
                g.DrawLine(p, positionX, positionY, destinationX, destinationY);
            }
        }

        public void MoveLine(int destinationX, int destinationY)
        {
            positionX = destinationX;
            positionY = destinationY;
        }

        public void ChangePenRed()
        {
            p.Color = Color.Red;
        }

        public void ChangePenBlue()
        {
            p.Color = Color.Blue;
        }

        public void ChangePenGreen()
        {
            p.Color = Color.Green;
        }

        public void FillSquare(PaintEventArgs e, int destinationX, int destinationY)
        {
            e.Graphics.FillRectangle(b, positionX, positionY, positionX + destinationX, positionY + destinationY);
            
        }

        public void FillCircle(PaintEventArgs e, int destinationX, int destinationY)
        {
            e.Graphics.FillEllipse(b, positionX, positionY, destinationX, destinationY);
        }

        public void FillTriangle(PaintEventArgs e, int destinationX, int destinationY)
        {
            Point[] a = { new Point(10, 10), new Point(200, 100), new Point(400, 100) };
            e.Graphics.FillPolygon(b, a);
        }

        public void ClearCanvas()
        {
           g.Clear(Color.Transparent);
        }

        //FIX
        public void ResetPen(int destinationX, int destinationY)
        {
            destinationX = 0;
            destinationY = 0;
            positionX = destinationX;
            positionY = destinationY;
        }
    }
}
