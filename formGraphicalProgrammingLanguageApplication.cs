using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
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
        parseRichCommand richCommand;
        parseCommand varCommand;
        

        public formGraphicalProgrammingLanguageApplication()
        {
            InitializeComponent();
            pictureBoxCanvas = new pictureBox(Graphics.FromImage(outputBitmap));
            drawSquare = new square(Graphics.FromImage(outputBitmap));
            drawCircle = new circle(Graphics.FromImage(outputBitmap));
            drawTriangle = new triangle(Graphics.FromImage(outputBitmap));
            varCommand = new parseCommand(pictureBoxCanvas, drawCircle, drawSquare, drawTriangle);
            richCommand = new parseRichCommand(pictureBoxCanvas, varCommand);

        }

        //New menu item
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
  
                   
        }

        //Open menu item
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

            }
                OpenFileDialog dlg = new OpenFileDialog();
            String retProg = richCommandLine.Text;
            var fileContent = string.Empty;
            var filePath = string.Empty;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
               filePath = dlg.FileName;

                var fileStream = dlg.OpenFile();

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    fileContent = reader.ReadToEnd();

                    richCommandLine.Text = fileContent;
                }

            }

        }

        //Save as... menu item
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            String retProg = richCommandLine.Text;

            List<string> commandLineList = new List<string>(
                            retProg.Split(new string[] { "\r\n" }, 
                            StringSplitOptions.RemoveEmptyEntries));

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(dlg.FileName);

                for (int i = 0; i < commandLineList.Count; i++)
                {
                    writer.WriteLine(commandLineList[i]);
                }

                writer.Close();
            }
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

        //Command line awaiting use (textbox)
        private void commandLine_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                String command = commandLine.Text.Trim().ToLower();
                String commandz = richCommandLine.Text.Trim().ToLower();
                
  
                    //Run command
                    if (command.Equals("run") == true)
                    {
                        richCommand.parseRich(commandz);
                        
                    }

                    else
                    {
                        varCommand.Parse(command);
                    }

                    commandLine.Text = "";
                    Refresh();
 
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