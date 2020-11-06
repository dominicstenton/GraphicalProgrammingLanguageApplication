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

        static int sizeX = 480;
        static int sizeY = 640;
        Bitmap outputBitmap = new Bitmap(sizeX, sizeY);
        pictureBox pictureBoxCanvas;


        public formGraphicalProgrammingLanguageApplication()
        {
            InitializeComponent();
            pictureBoxCanvas = new pictureBox(Graphics.FromImage(outputBitmap));
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

                    if (commands[0].Equals("drawto") == true)
                    {
                        pictureBoxCanvas.DrawLine(variable1, variable2);
                        Console.WriteLine("Line has been drawn");

                    }

                    commandLine.Text = "";
                    Refresh();
                }
                
                catch (FormatException i)
                {
                    Console.WriteLine("Invalid parameter");
                }

                catch (IndexOutOfRangeException i)
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
    }
}
