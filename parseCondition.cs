using System;
using System.Collections.Generic;

namespace GraphicalProgrammingLanguageApplication
{
    /// <summary>
    ///   <para>A class used to further parse information into if and else commands.</para>
    /// </summary>
    public class parseCondition
    {
        PictureBox pictureBoxCanvas;
        ParseVariableCommand pvCommand;
        ParseCommand parseTell;
        ParseRichCommand richCommand;
        Square drawSquare;
        Circle drawCircle;
        Triangle drawTriangle;

        string sum = "";
        int checkElse = 0;
        int checkIf = 0;
        int useIf = 0;
        int useIf1 = 0;
        int useElse = 0;
        int useElse1 = 0;
        int ifElse = 0;
        int stop = 0;
        string ifCondition;
        string elseCondition;

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
        public void convertVal(string use)
        {
            sum = use;
        }
        public void ifParser(List<string> commandList)
        {
            for (int i = 0; i < commandList.Count; i++)
            {
                if (commandList[i].Contains("if") == true)
                {
                    checkIf = i;
                }
                else if (commandList[i].Contains("else") == true)
                {
                    checkElse = i;
                }
            }
            for (int i = 0; i < commandList.Count; i++)
            {
                if (i >= checkIf && i < checkElse)
                {
                    ifList.Add(commandList[i]);
                }
                else if (i > checkElse && i <= commandList.Count)
                {
                    elseList.Add(commandList[i]);
                }
            }
            foreach (string inputs in commandList)
            {
                List<string> pCommands = new List<string>(
                                    inputs.Split(new string[] { ",", " " },
                                    StringSplitOptions.RemoveEmptyEntries));

                if (inputs.Contains("if") == true)
                {
                    for (int i = 0; i < pCommands.Count; i++)
                    {
                        if (i == 1)
                        {
                            int testNum = 0;
                            string pCommand = pCommands[i];
                            bool isNum = int.TryParse(pCommand, out testNum);

                            if (isNum == true)
                            {
                                useIf = int.Parse(pCommand);
                            }
                            else
                            {
                                useIf = ifElse;
                            }
                        }
                        else if (i == 2)
                        {
                            ifCondition = pCommands[i];
                        }
                        else if (i == 3)
                        {
                            useIf1 = int.Parse(pCommands[i]);
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine("");
                        }
                    }
                }
                else if (inputs.Contains("else") == true)
                {
                    for (int i = 0; i < pCommands.Count; i++)
                    {
                        if (i == 1)
                        {
                            int testNum = 0;
                            string pCommand = pCommands[i];
                            bool isNum = int.TryParse(pCommand, out testNum);

                            if (isNum == true)
                            {
                                useElse = int.Parse(pCommand);
                            }
                            else
                            {
                                useElse = ifElse;
                            }
                        }
                        else if (i == 2)
                        {
                            elseCondition = pCommands[i];
                        }
                        else if (i == 3)
                        {
                            useElse1 = int.Parse(pCommands[i]);
                            System.Diagnostics.Debug.WriteLine(useElse1);
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine("");
                        }
                    }
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("");
                }
            }
            System.Diagnostics.Debug.WriteLine(useIf + " " + useIf1 + " " + useElse + " " + useElse1);
            ifElseDecider(useIf, useIf1, useElse, useElse1);
        }
        public void ifElseDecider(int useIf, int useIf1, int useElse, int useElse1)
        {
            if (useIf > useIf1)
            {
                foreach (string item in ifList)
                {
                    System.Diagnostics.Debug.WriteLine(item);
                }
                ifElseExecute(ifList);
            }
            else if (useElse < useElse1)
            {
                foreach (string item in elseList)
                {
                    System.Diagnostics.Debug.WriteLine(item);
                }
                ifElseExecute(elseList);
            }
        }
        public void ifElseExecute(List<string> excecute)
        {
            if (stop == 1)
            {
                return;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine(stop);
                stop = 1;
                foreach (string command in excecute)
                {
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
}
