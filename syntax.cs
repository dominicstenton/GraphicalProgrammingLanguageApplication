using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//class made to check syntax
namespace GraphicalProgrammingLanguageApplication
{
    /// <summary>A class designed to check user inputted data for errors, line by line.</summary>
    class syntax
    {
        PictureBox pictureBoxCanvas;
        ParseCommand parseTell;
        int ans;
        Dictionary<string, int> valueDiction = new Dictionary<string, int>();
        Square drawSquare;
        Circle drawCircle;
        Triangle drawTriangle;

        int lineCount = 0;
        int commandCount = 0;
        string[] commandz = new string[] { "circle" };

        //Calling classes
        public syntax(PictureBox pictureBoxCanvas, ParseCommand parseCommand, Circle drawCircle, Square drawSquare, Triangle drawTriangle)
        {
            this.pictureBoxCanvas = pictureBoxCanvas;
            this.parseTell = parseCommand;
            this.drawCircle = drawCircle;
            this.drawSquare = drawSquare;
            this.drawTriangle = drawTriangle;
        }

        public void checkSyntax(string commandLine)
        {
            //System.Diagnostics.Debug.WriteLine(commandLine);
            List<string> loadValue = new List<string>(
                commandLine.Split(new string[] { "\r\n" },
                StringSplitOptions.RemoveEmptyEntries));

            foreach (string thing in loadValue)
            {
                lineCount++;
                thingy(thing);
            }
        }

        public void thingy(string stuff)
        {
            stuff = stuff.Trim().ToLower();

            List<string> loadValue = new List<string>(
                stuff.Split(new string[] { ",", " " },
                StringSplitOptions.RemoveEmptyEntries));

            for (int i = 0; i < loadValue.Count; i++)
            {

                if (i % 2 == 0)
                {
                    for (int n = 0; n < commandz.Length; n++)
                    {
                        if (loadValue[i] == commandz[n])
                        {
                            //System.Diagnostics.Debug.WriteLine("SHAPE command good");
                        }
                        else
                        {
                            string update = "spelling incorrect " + lineCount + " at space 1";
                            System.Windows.Forms.MessageBox.Show(update);

                        }
                    }
                }
                else
                {
                    int testNum = 0;
                    string numCommand = loadValue[i];
                    bool isNum = int.TryParse(numCommand, out testNum);

                    if (isNum == true)
                    {
                        System.Diagnostics.Debug.WriteLine("NUM COMMAND FINE");
                    }
                    else
                    {
                        //System.Diagnostics.Debug.WriteLine("error on line: " + lineCount + " at space two");
                        string update2 = "incorrect use of numbers " + lineCount + " at space 2";
                        System.Windows.Forms.MessageBox.Show(update2);
                    }
                }
            }
        }
    }
}
