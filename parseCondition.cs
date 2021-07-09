using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalProgrammingLanguageApplication
{
    public class parseCondition
    {
        PictureBox pictureBoxCanvas;
        //variabletextparser
        ParseVariableCommand pvCommand;
        //textparser
        ParseCommand parseTell;
        //multiline
        ParseRichCommand richCommand;
        //parseCommand
        parseCondition pcCommand;

        Square drawSquare;
        Circle drawCircle;
        Triangle drawTriangle;

        int result;
        int result2;
        int elseCounter = 0;
        int ifCounter = 0;

        List<string> commandList = new List<string>();
        List<string> ifList = new List<string>();
        List<string> elseList = new List<string>();
        Dictionary<string, int> userVariables = new Dictionary<string, int>();

        public parseCondition(PictureBox pictureBoxCanvas, ParseCommand parseCommand, ParseRichCommand parseRichCommand)
        {
            this.pictureBoxCanvas = pictureBoxCanvas;
            this.parseTell = parseCommand;
            this.richCommand = parseRichCommand;
        }

        public void ValueConverter(Dictionary<string, int> varDictionary)
        {
            userVariables = varDictionary;
        }

        public void ifParser(List<string> commandList)
        {
            int ifVal = 0;
            string ifCondition;
            int ifVal2 = 0;
            int elseVal = 0;
            string elseCondition;
            int elseVal2 = 0;

            for (int i = 0; i < commandList.Count; i++)
            {
                if (commandList[i].Contains("if") == true)
                {
                    ifCounter = i;
                }
                else if (commandList[i].Contains("else") == true)
                {
                    elseCounter = i;
                }

            }
            for (int i = 0; i < commandList.Count; i++)
            {
                System.Diagnostics.Debug.WriteLine("loopcounter: " + i);
                if (i >= ifCounter && i < elseCounter)
                {
                    ifList.Add(commandList[i]);
                }
                else if (i > elseCounter && i <= commandList.Count)
                {
                    System.Diagnostics.Debug.WriteLine("command: " + commandList[i] + "counter: " + i);
                    elseList.Add(commandList[i]);
                }
            }


            foreach (string inputs in commandList)
            {
                List<string> ifParams = new List<string>(
                                    inputs.Split(new string[] { ",", " " },
                                    StringSplitOptions.RemoveEmptyEntries));

                if (inputs.Contains("if") == true)
                {
                    for (int i = 0; i < ifParams.Count; i++)
                    {
                        if (i == 1)
                        {
                            if (userVariables.TryGetValue(ifParams[i], out result))
                            {
                                ifVal = result;
                            }
                            else
                            {
                                ifVal = int.Parse(ifParams[i]);
                            }
                        }
                        else if (i == 2)
                        {
                            ifCondition = ifParams[i];
                        }
                        else if (i == 3)
                        {
                            ifVal2 = int.Parse(ifParams[i]);
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine("...");
                        }
                    }
                }
                else if (inputs.Contains("else") == true)
                {
                    for (int i = 0; i < ifParams.Count; i++)
                    {
                        if (i == 1)
                        {
                            if (userVariables.TryGetValue(ifParams[i], out result2))
                            {
                                elseVal = result2;
                            }
                            else
                            {
                                elseVal = int.Parse(ifParams[i]);
                            }
                        }
                        else if (i == 2)
                        {
                            elseCondition = ifParams[i];
                        }
                        else if (i == 3)
                        {
                            elseVal2 = int.Parse(ifParams[i]);
                            System.Diagnostics.Debug.WriteLine(elseVal2);

                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine("...");
                        }
                    }
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("...");
                }
            }
            System.Diagnostics.Debug.WriteLine(ifVal + " " + ifVal2 + " " + elseVal + " " + elseVal2);
            ifElseDecider(ifVal, ifVal2, elseVal, elseVal2);
        }
        public void ifElseDecider(int ifVal, int ifVal2, int elseVal, int elseVal2)
        {
            if (ifVal > ifVal2)
            {
                System.Diagnostics.Debug.WriteLine("if statement executing...");
                foreach (string item in ifList)
                {
                    System.Diagnostics.Debug.WriteLine("executing..." + item);
                }
                ifElseExecution(ifList);
            }
            else if (elseVal < elseVal2)
            {
                System.Diagnostics.Debug.WriteLine("else statement executing...");
                foreach (string item in elseList)
                {
                    System.Diagnostics.Debug.WriteLine("executing..." + item);
                }
                ifElseExecution(elseList);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("invalid if else statement currently...");
            }
        }
        public void ifElseExecution(List<string> ifExe)
        {
            foreach (string command in ifExe)
            {
                System.Diagnostics.Debug.WriteLine("...executing: " + command);
                if (richCommand == null)
                {
                    richCommand = new ParseRichCommand(pictureBoxCanvas, parseTell, pvCommand, drawCircle, drawSquare, drawTriangle);
                    richCommand.parseRich(command);
                }
                else
                {
                    richCommand.parseRich(command);
                }
            }
        }


    }
}
