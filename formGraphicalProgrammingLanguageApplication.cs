using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * An application used to simulate a programming language for educational purposes.
 * Written by Dominic Stenton
 * https://github.com/dominicstenton
 * Leeds Beckett University
 */

namespace GraphicalProgrammingLanguageApplication
{
    public partial class formGraphicalProgrammingLanguageApplication : Form
    {
        //Size of the form
        static int sizeX = 480;
        static int sizeY = 640;
        Bitmap outputBitmap = new Bitmap(sizeX, sizeY);
        pictureBox pictureBoxCanvas;
        square drawSquare;
        circle drawCircle;
        triangle drawTriangle;

        public formGraphicalProgrammingLanguageApplication()
        {
            InitializeComponent();
            pictureBoxCanvas = new pictureBox(Graphics.FromImage(outputBitmap));
            drawSquare = new square(Graphics.FromImage(outputBitmap));
            drawCircle = new circle(Graphics.FromImage(outputBitmap));
            drawTriangle = new triangle(Graphics.FromImage(outputBitmap));
        }

       //File menu button being clicked (tool strip menu item)
        private void file_Click(object sender, EventArgs e)
        {

        }

        //New menu item
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        //Open menu item
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        //Save as... menu item
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        //Exit menu item
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Help button being clicked (tool strip menu item)
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("An application used to simulate a programming language for educational purposes.");
        }

        //Rich command line awaiting use (rich textbox)
        private void richCommandLine_KeyDown(object sender, KeyEventArgs e)
        {
           if (e.KeyCode == Keys.Enter)
            {
                String command = richCommandLine.Text.Trim().ToLower();
                String[] commands = command.Split(' ', ',');

                try
                {
                    String instruction = commands[0];
                    int variable1 = int.Parse(commands[1]);
                    int variable2 = int.Parse(commands[2]);

                    //hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh
                   // int sizeGiven = int.Parse(commands[3]);

                    if (commands[0].Equals("drawto") == true)
                    {
                        pictureBoxCanvas.drawLine(variable1, variable2);
                        Console.WriteLine("Line has been drawn");

                    }

                    else if (commands[0].Equals("moveto") == true)
                    {
                        pictureBoxCanvas.moveLine(variable1, variable2);
                        Console.WriteLine("You have moved the pen position");
                    }

                    else if (commands[0].Equals("square") == true)
                    {
                        drawSquare.createSquare(variable1, variable2);
                        Console.WriteLine("Square has been drawn");
                    }

                    else if (commands[0].Equals("circle") == true)
                    {
                        drawCircle.createCircle(variable1, variable2);
                        Console.WriteLine("Circle has been drawn");
                    }

                    else if (commands[0].Equals("triangle") == true)
                    {
                        //hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh
                        drawTriangle.createTriangle(variable2);
                        Console.WriteLine("Triangle has been drawn");
                    }

                    //Changes pen color to red
                    else if (commands[0].Equals("penred") ==true)
                    {
                        pictureBoxCanvas.changePenRed();
                    }

                    commandLine.Text = "";
                    Refresh();
                }
                
                catch (FormatException)
                {
                    Console.WriteLine("Invalid parameter");
                }

                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Invalid parameter");
                }
            }
        }

        //Command line awaiting use (textbox)
        private void commandLine_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                String command = commandLine.Text.Trim().ToLower();
                String[] commands = command.Split(' ', ',');

                try
                {
                    String instruction = commands[0];
                    int variable1 = int.Parse(commands[1]);
                    int variable2 = int.Parse(commands[2]);

                    //hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh
                  //  int sizeGiven = int.Parse(commands[3]);

                    if (commands[0].Equals("drawto") == true)
                    {
                        pictureBoxCanvas.drawLine(variable1, variable2);
                        Console.WriteLine("Line has been drawn");

                    }

                    else if (commands[0].Equals("moveto") == true)
                    {
                        pictureBoxCanvas.moveLine(variable1, variable2);
                        Console.WriteLine("You have moved the pen position");
                    }

                    else if (commands[0].Equals("square") == true)
                    {
                        drawSquare.createSquare(variable1, variable2);
                        Console.WriteLine("Square has been drawn");
                    }

                    else if (commands[0].Equals("circle") == true)
                    {
                        drawCircle.createCircle(variable1, variable2);
                        Console.WriteLine("Circle has been drawn");
                    }

                    else if (commands[0].Equals("triangle") == true)
                    {
                        //hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh
                        drawTriangle.createTriangle(variable2);
                        Console.WriteLine("Triangle has been drawn");
                    }

                    //Changes pen color to red
                    else if (commands[0].Equals("penred") == true)
                    {
                        pictureBoxCanvas.changePenRed();
                    }

                    //Run command
                    else if (commands[0].Equals("run") == true)
                    {
                        string o  = richCommandLine.Text;

                        List<string> commandLineList = new List<string>(
                            o.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries));

                        foreach (string order in commandLineList)
                        {
                            String[] orders = order.Split(' ', ',');

                            String instruct = orders[0];
                            int order1 = int.Parse(orders[1]);
                            int order2 = int.Parse(orders[2]);

                                 if (instruct.Equals("circle") == true)
                            {
                                drawCircle.createCircle(order1, order2);
                                Console.WriteLine("Circle has been drawn");

                            }

                        }

                    }

                    commandLine.Text = "";
                    Refresh();
                }
                
                catch (FormatException)
                {
                    Console.WriteLine("Invalid parameter");
                   
                }

                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Invalid parameter");
                    
                }
            }
        }

        //Run button being clicked (button)
        private void buttonRun_Click(object sender, EventArgs e)
        {
          

        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImageUnscaled(outputBitmap, 0, 0);
        }

        private void clear_MouseDown(object sender, MouseEventArgs e)
        {
        //    pictureBox.clearCanvas();
        //    Console.WriteLine("samber lightning");
        }


    }
}
