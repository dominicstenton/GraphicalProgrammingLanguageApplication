﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicalProgrammingLanguageApplication
{
    class pictureBox
    {
        Graphics g;
        Pen p;
        Brush b;
        int positionX, positionY;

        public pictureBox(Graphics g)
        {
            this.g = g;
            positionX = positionY = 10;
            p = new Pen(Color.Black, 1);
            b = new SolidBrush(Color.Yellow);
        }

        //Line being draw to the pictureBox
        public void drawLine(int destinationX, int destinationY)
        {
            g.DrawLine(p, positionX, positionY, destinationX, destinationY);
            positionX = destinationX;
            positionY = destinationY;
        }

        public void moveLine(int destinationX, int destinationY)
        {
            positionX = destinationX;
            positionY = destinationY;
        }

        public void changePenRed()
        {
            p.Color = Color.Red;
        }

        public void changePenBlue()
        {
            p.Color = Color.Blue;
        }






        public void FillSquare(PaintEventArgs e, int destinationX, int destinationY)
        {
            e.Graphics.FillRectangle(b, positionX, positionY, positionX + destinationX, positionY + destinationY);
            
        }








        public void clearCanvas()
        {
          //  g.Clear(Color.Black);

        }
    }
}
