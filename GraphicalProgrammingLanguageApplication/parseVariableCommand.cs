using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace GraphicalProgrammingLanguageApplication
{
    public class ParseVariableCommand
    {
        PictureBox pictureBoxCanvas;
        ParseCommand parseTell;
        int ans;
        Dictionary<string, int> valueDiction = new Dictionary<string, int>();
        Square drawSquare;
        Circle drawCircle;
        Triangle drawTriangle;

        //Calling classes
        public ParseVariableCommand(PictureBox pictureBoxCanvas, ParseCommand parseCommand, Circle drawCircle, Square drawSquare, Triangle drawTriangle)
        {
            this.pictureBoxCanvas = pictureBoxCanvas;
            this.parseTell = parseCommand;
            this.drawCircle = drawCircle;
            this.drawSquare = drawSquare;
            this.drawTriangle = drawTriangle;
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

                        //Exception
                        try
                        {
                            assignValue = Int32.Parse(loadValue[i]);
                        }
                        catch
                        {

                            GraphicalProgrammingLanguageApplication.exception exMeth = new exception();
                            exMeth.stuff(0);
                        
                        }

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
                System.Diagnostics.Debug.WriteLine(valueName + " This value already exists");
            }
            if (valueDiction.ContainsKey(valueName))
            {
                System.Diagnostics.Debug.WriteLine(assignValue1);
                valueDiction.TryGetValue(valueName, out ans);
                int updateValue = ans + assignValue1;
                valueDiction[valueName] = updateValue;
            }
            parseTell.RehashValue(valueDiction);
        }
    }
}