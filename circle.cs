using System.Drawing;

namespace GraphicalProgrammingLanguageApplication
{
    /// <summary>This class is used to generate a Circle with user given parameter.</summary>
    public class Circle
    {
        Graphics g;
        Pen p;
        int positionX, positionY;
        Brush b;
        bool shapeFill;

        public Circle(Graphics g)
        {
            this.g = g;
            positionX = positionY = 10;
            p = new Pen(Color.Black, 3);
            b = new SolidBrush(Color.Yellow);
        }

        /// <summary>Fill shape enabled.</summary>
        public void BrushOn()
        {
            shapeFill = true;
        }

        /// <summary>/Fill shape disabled.</summary>
        public void BrushOff()
        {
            shapeFill = false;
        }

        /// <summary>Creates the circle.</summary>
        /// <param name="radius">The radius.</param>
        public void createCircle(int radius)
        {
            if (shapeFill == true)
            {
                g.FillEllipse(b, positionX, positionY, radius * 2, radius * 2);
                g.DrawEllipse(p, positionX, positionY, radius * 2, radius * 2);
            }
            else
            {
                g.DrawEllipse(p, positionX, positionY, radius * 2, radius * 2);
            }
        }
    }
}