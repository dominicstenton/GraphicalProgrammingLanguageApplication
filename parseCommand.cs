using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicalProgrammingLanguageApplication
{
    public class ParseCommand
    {
        PictureBox pictureBoxCanvas;
        Square drawSquare;
        Circle drawCircle;
        Triangle drawTriangle;
        Dictionary<string, int> uniqueValues;
        int result;

        public ParseCommand(PictureBox pictureBox, Circle drawCircle, Square drawSquare, Triangle drawTriangle)
        {
            this.pictureBoxCanvas = pictureBox;
            this.drawCircle = drawCircle;
            this.drawSquare = drawSquare;
            this.drawTriangle = drawTriangle;
        }

        //Method RehashValue holding KeyValue pairs dictionary (uniqueValues)
        public void RehashValue(Dictionary<string, int> valueDiction)
        {
            uniqueValues = valueDiction;

            foreach(KeyValuePair<string, int> kvp in uniqueValues)
            {
                System.Diagnostics.Debug.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
            }
        }

        public void Parse(string load)
        {
            string instruction = "default";
            string equals = "=";
            int variable1 = 0;
            int variable2 = 0;
            int variable3 = 0;

            load = load.Trim().ToLower();

            List<string> loadValue = new List<string>(
                load.Split(new string[] { ",", " " }, 
                StringSplitOptions.RemoveEmptyEntries));

            for (int q = 0; q < loadValue.Count; q++)
            {
                if (q == 0)
                {
                    instruction = loadValue[q];
                }

                else if (q == 1)
                {
                    try
                    {
                        if(loadValue[q] == "=")
                        {
                            equals = variable1.ToString();
                        }
                        else if (uniqueValues.TryGetValue(loadValue[q], out result))
                        {
                            variable1 = result;
                        }
                        else
                        {
                            variable1 = int.Parse(loadValue[q]);
                        }
                    }

                    catch (FormatException)
                    {
                        Console.WriteLine("This is an invalid command");
                    }
                }

                else if (q == 2)
                {
                    try
                    {
                        variable2 = int.Parse(loadValue[q]);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("This is an invalid command");
                    }
                }

                else if (q == 3)
                {
                        variable3 = int.Parse(loadValue[q]);
                }

                else
                {
                    Console.Write("Error");
                }
                Console.WriteLine(instruction + " " + equals + " " + variable1);
            }

            try {

                if (instruction.Equals("drawto") == true)
                {
                    pictureBoxCanvas.drawLine(variable1, variable2);
                    Console.WriteLine("You have drawn a line with the value of " + variable1 + " & " + variable2);
                }

                else if (instruction.Equals("moveto") == true)
                {
                    pictureBoxCanvas.MoveLine(variable1, variable2);
                    Console.WriteLine("You have moved the pen to position " + variable1 + " & " + variable2);
                }

                else if (instruction.Equals("rect") == true)
                {
                    drawSquare.createSquare(variable1, variable2);
                    Console.WriteLine("A Square has been drawn with the value of " + variable1 +  " & " + variable2);
                }

                else if (instruction.Equals("circle") == true)
                {
                    drawCircle.createCircle(variable1);
                    Console.WriteLine("A Circle has been drawn with the value of " + variable1);
                }

                else if (instruction.Equals("triangle") == true)
                {
                    drawTriangle.CreateTriangle();
                    Console.WriteLine("A Triangle has been drawn with the value of " + variable1 + " & " + variable2);
                }

                //Changes pen color to red
                else if (instruction.Equals("penred") == true)
                {
                    pictureBoxCanvas.ChangePenRed();
                    Console.WriteLine("You have changed your Pen color to Red!");
                }

                //Changes pen color to blue
                else if (instruction.Equals("penblue") == true)
                {
                    pictureBoxCanvas.ChangePenBlue();
                    Console.WriteLine("You have changed your Pen color to Blue!");
                }

                //Changes pen color to green
                else if (instruction.Equals("pengreen") == true)
                {
                    pictureBoxCanvas.ChangePenGreen();
                    Console.WriteLine("You have changed your Pen color to Green!");
                }

                else if (instruction.Equals("fillon") == true)
                {
                    drawSquare.BrushOn();
                    drawCircle.BrushOn();
                    drawTriangle.BrushOn();
                    Console.WriteLine("Fill shape command is now activated");
                }

                else if (instruction.Equals("filloff") == true)
                {
                    drawSquare.BrushOff();
                    drawCircle.BrushOff();
                    drawTriangle.BrushOff();
                    Console.WriteLine("The Fill command is now deactivated");
                }

                else if (instruction.Equals("reset") == true)
                {
                    pictureBoxCanvas.ResetPen(0, 0);
                    Console.WriteLine("You have Reset your Pen position!");
                }

                else if (instruction.Equals("clear") == true)
                {
                    pictureBoxCanvas.ClearCanvas();
                    Console.WriteLine("You have cleared your canvas!");
                }

                else
                {
                    Console.WriteLine("This is an invalid command");
                }
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Error");
            }
            }
        }
    }
