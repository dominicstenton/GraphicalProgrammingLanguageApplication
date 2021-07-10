using System;
using System.Collections.Generic;

namespace GraphicalProgrammingLanguageApplication
{
    /// <summary>A class capable of parsing information that will be inputed through a miltiline system/textbox</summary>
    public class ParseRichCommand
    {
        PictureBox pictureBoxCanvas;
        ParseCommand parseTell;
        ParseVariableCommand pvCommand;
        Square drawSquare;
        Circle drawCircle;
        Triangle drawTriangle;
        parseCondition pcCommand;
        ParseRichCommand prCommand;
        Dictionary<string, int> stowVar = new Dictionary<string, int>();
        List<string> loopIndex = new List<string>();

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
        public void convertVal(Dictionary<string, int> valueDiction)
        {
            stowVar = valueDiction;
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
                                System.Diagnostics.Debug.WriteLine("Calculated loops: " + i);
                            }
                        }
                        else
                        {
                            if (loopLoad.Contains("loop") == true)
                            {
                                System.Diagnostics.Debug.WriteLine("Ignore");
                            }
                            else
                            {
                                loopIndex.Add(loopLoad);
                            }
                        }
                    }
                }
               else if (direct.Contains("if") == true)
                {
                    if (pcCommand == null)
                    {
                        pcCommand = new parseCondition(pictureBoxCanvas, parseTell, prCommand);
                        pcCommand.ifParser(commandList);
                    }
                    else
                    {
                        pcCommand.ifParser(commandList);
                    }
                } 
                //Variables
                //Checks if ParseVariableCommand is null, if it is, it parses the data
                else if (direct.Contains("=") == true)
                {
                    if (pvCommand == null)
                    {
                        pvCommand = new ParseVariableCommand(pictureBoxCanvas, parseTell, drawCircle, drawSquare, drawTriangle, prCommand);
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