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
    public partial class FormGraphicalProgrammingLanguageApplication : Form
    {
        //Size of the form
        static int sizeX = 480;
        static int sizeY = 640;

        Bitmap outputBitmap = new Bitmap(sizeX, sizeY);
        PictureBox pictureBoxCanvas;
        Square drawSquare;
        Circle drawCircle;
        Triangle drawTriangle;
        ParseRichCommand richCommand;
        ParseCommand varCommand;
        ParseVariableCommand pvCommand;

        public FormGraphicalProgrammingLanguageApplication()
        {
            //Initialization section where other classes are called
            InitializeComponent();
            pictureBoxCanvas = new PictureBox(Graphics.FromImage(outputBitmap));
            drawSquare = new Square(Graphics.FromImage(outputBitmap));
            drawCircle = new Circle(Graphics.FromImage(outputBitmap));
            drawTriangle = new Triangle(Graphics.FromImage(outputBitmap));
            varCommand = new ParseCommand(pictureBoxCanvas, drawCircle, drawSquare, drawTriangle);
            richCommand = new ParseRichCommand(pictureBoxCanvas, varCommand, pvCommand, drawCircle, drawSquare, drawTriangle);
            pvCommand = new ParseVariableCommand(pictureBoxCanvas, varCommand, drawCircle, drawSquare, drawTriangle);
        }
        //New menu item
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormGraphicalProgrammingLanguageApplication myForm = new FormGraphicalProgrammingLanguageApplication();
            this.Hide();
            myForm.ShowDialog();
            this.Close();
        }
        //Open menu item allowing the user to open/import a text file
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
        //Save as... menu item allowing the user to save a text file of the application
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
        //Exit menu item allowing the user to exit the program
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Help button being clicked (tool strip menu item)
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("An application used to simulate a programming language for educational purposes.");
        }
        //Command line waiting to be called (textbox)
        private void commandLine_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                String direct = commandLine.Text.Trim().ToLower();
                String charge = richCommandLine.Text.Trim().ToLower();

                //Run command
                if (direct.Equals("run") == true)
                {
                    richCommand.parseRich(charge);
                }
                else
                {
                    varCommand.Parse(direct);
                }

                commandLine.Text = "";
                Refresh();
            }
        }
        //Run button being clicked (incomplete)
        private void buttonRun_Click(object sender, EventArgs e)
        {

        }
        //Canvas being given an initial position to hold
        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImageUnscaled(outputBitmap, 0, 0);
        }
        //Clear button (incomplete)
        private void clear_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox_Click(object sender, EventArgs e)
        {

        }

        private void richCommandLine_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            System.InvalidOperationException exOne = new System.InvalidOperationException("this operation isn't allowed");
            throw exOne;
        }

        public void richTextBox1_TextChanged_1(object sender, EventArgs e)
        {
            
        }
    }
}