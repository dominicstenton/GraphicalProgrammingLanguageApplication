using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalProgrammingLanguageApplication
{
    public class ParseRichCommand
    {
        PictureBox pictureBoxCanvas;
        ParseCommand parseTell;
        ParseVariableCommand pvCommand;
        Square drawSquare;
        Circle drawCircle;
        Triangle drawTriangle;

        List<string> loopIndex = new List<string>();
        int processLoop = 0;
        string loadLoop;
        string loopContent;

        //Calling classes
        public ParseRichCommand(PictureBox pictureBox, ParseCommand parseCommand, ParseVariableCommand parseVariableCommand, Circle drawCircle, Square drawSquare, Triangle drawTriangle)
        {
            this.pictureBoxCanvas = pictureBox;
            this.parseTell = parseCommand;
            this.pvCommand = parseVariableCommand;
            this.drawCircle = drawCircle;
            this.drawSquare = drawSquare;
            this.drawTriangle = drawTriangle;
        }

        public void parseRich(string charge)
        {
            List<string> commandList = new List<string>(
                charge.Split(new string[] { "\r\n" }, 
                StringSplitOptions.RemoveEmptyEntries));

            foreach (string direct in commandList)
            {

                if (direct.Contains("loop") == true)
                {
                    string loadLoop = direct.Trim().ToLower();

                    List<string> loadValue = new List<string>(
                                    loadLoop.Split(new string[] { ",", " " },
                                    StringSplitOptions.RemoveEmptyEntries));


                    int processLoop = Int32.Parse(loadValue[2]);

                    foreach (string loopLoad in commandList)
                    {
                        if (loopLoad.Contains("end") == true)
                        {
                            for (int i = 0; i < processLoop; i++)
                            {
                                foreach (string j in loopIndex)
                                {
                                    string loopContent = j;
                                    parseRich(loopContent);
                                }
                                System.Diagnostics.Debug.WriteLine("Amount of loops: " + i);    
                            }
                        }
                        else
                        {
                            if (loopLoad.Contains("loop") == true)
                            {
                                System.Diagnostics.Debug.WriteLine("Ignore loopIndex");
                            }
                            else
                            {
                                loopIndex.Add(loopLoad);
                            }
                        }
                    }
                }

                //Checks if ParseVariableCommand is null, if it is, it parses the data
                else if (direct.Contains("=") == true)
                {
                    if (pvCommand == null)
                    {
                        pvCommand = new ParseVariableCommand(pictureBoxCanvas, parseTell, drawCircle, drawSquare, drawTriangle);
                        pvCommand.Parse(direct);
                    }
                    else
                    {
                        pvCommand.Parse(direct);
                    }
                }
                else
                {
                    parseTell.Parse(direct);
                }
            }
        }
    }
}
