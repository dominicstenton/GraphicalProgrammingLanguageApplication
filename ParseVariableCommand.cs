using System;
using System.Collections.Generic;

namespace GraphicalProgrammingLanguageApplication
{
    /// <summary>A class used to parse variable commands. Using data from the multi-line parser to seperate into different methods.</summary>
    public class ParseVariableCommand
    {
        PictureBox pictureBoxCanvas;
        ParseCommand parseTell;
        int ans;
        Dictionary<string, int> valueDiction = new Dictionary<string, int>();
        Square drawSquare;
        Circle drawCircle;
        Triangle drawTriangle;
        ParseVariableCommand pvCommand;
        ParseRichCommand prCommand;
        parseCondition pcCommand;

        //Calling classes
        public ParseVariableCommand(PictureBox pictureBoxCanvas, ParseCommand parseCommand, Circle drawCircle, Square drawSquare, Triangle drawTriangle, ParseRichCommand prCommand)
        {
            this.pictureBoxCanvas = pictureBoxCanvas;
            this.parseTell = parseCommand;
            this.drawCircle = drawCircle;
            this.drawSquare = drawSquare;
            this.drawTriangle = drawTriangle;
            this.prCommand = prCommand;
        }

        //Parsing method
        public void Parse(string direct)
        {
            string valueName = "Name";
            string matchOperation = "=";
            string countOperation = "+";
            int assignValue = 0;
            int assignValue1 = 0;
            direct = direct.Trim().ToLower();
            List<string> loadValue = new List<string>(
                            direct.Split(new string[] { ",", " " },
                            StringSplitOptions.RemoveEmptyEntries));

            for (int i = 0; i < loadValue.Count; i++)
            {
                if (i == 0)
                {
                    valueName = loadValue[i];
                }
                else if (i == 1)
                {
                    matchOperation = loadValue[i];
                }
                else if (i == 2)
                {
                    if (valueDiction.ContainsKey(valueName))
                    {
                        valueName = loadValue[i];
                    }
                    else
                    {
                        assignValue = Int32.Parse(loadValue[i]);
 
                    }
                }
                else if (i == 3)
                {
                    countOperation = loadValue[i];
                }
                else if (i == 4)
                {
                    assignValue1 = Int32.Parse(loadValue[i]);
                }
                else
                {
                    Console.WriteLine("Parameter boundary has been met");
                }
            }
            try
            {
                valueDiction.Add(valueName, assignValue);
            }
            catch (ArgumentException)
            {
                System.Diagnostics.Debug.WriteLine(valueName + " Enter another value");
            }
            if (valueDiction.ContainsKey(valueName))
            {
                valueDiction.TryGetValue(valueName, out ans);
                int updateValue = ans + assignValue1;
                valueDiction[valueName] = updateValue;
                if (pcCommand == null)
                {
                    string send = updateValue.ToString();
                    pcCommand = new parseCondition(pictureBoxCanvas, parseTell, prCommand);
                    pcCommand.convertVal(send);
                }
                else
                {
                    string send = updateValue.ToString();
                    pcCommand.convertVal(send);
                }
            }
            if (prCommand == null)
            {
                prCommand = new ParseRichCommand(pictureBoxCanvas, parseTell, pvCommand, drawCircle, drawSquare, drawTriangle);
                prCommand.convertVal(valueDiction);
            }
            else
            {
                prCommand.convertVal(valueDiction);
            }
            if (pcCommand == null)
            {
                string send = ans.ToString();
                pcCommand = new parseCondition(pictureBoxCanvas, parseTell, prCommand);
                pcCommand.convertVal(send);
            }
            else
            {
                string send = ans.ToString();
                pcCommand.convertVal(send);
            }
            parseTell.RehashValue(valueDiction);
        }
    }
}