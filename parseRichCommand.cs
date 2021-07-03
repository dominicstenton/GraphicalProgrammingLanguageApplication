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
                //Checks if ParseVariableCommand is null, if it is, it parses the data
                if (direct.Contains("=") == true)
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
