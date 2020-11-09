using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalProgrammingLanguageApplication
{
    class ParseCommand
    {
        PictureBox pictureBoxCanvas;
        Square drawSquare;
        Circle drawCircle;
        Triangle drawTriangle;

        public ParseCommand(PictureBox pictureBox, Circle drawCircle, Square drawSquare, Triangle drawTriangle)
        {
            this.pictureBoxCanvas = pictureBox;
            this.drawCircle = drawCircle;
            this.drawSquare = drawSquare;
            this.drawTriangle = drawTriangle;

        }

        public void Parse(string input)
        {
            string instruction = "default";
            int variable1 = 0;
            int variable2 = 0;
            input = input.Trim().ToLower();
            List<string> loadVar = new List<string>(
                input.Split(new string[] { ",", " " }, StringSplitOptions.RemoveEmptyEntries));

            for (int q = 0; q < loadVar.Count; q++)
            {
                if (q == 0)
                {
                    instruction = loadVar[q];
                   // Console.WriteLine(instruction);
                }

                else if (q == 1)
                {
                    try
                    {
                        variable1 = int.Parse(loadVar[q]);
                        //Console.WriteLine(instruction + " " + variable1);
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
                        variable2 = int.Parse(loadVar[q]);
                        Console.WriteLine(instruction + " " + variable1 + " " + variable2);
                    }
                    catch
                    {
                        Console.WriteLine("This is an invalid command");
                    }
                }

                else
                {
                    Console.Write("Error");
                }
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
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Error");
            }
            }
        }
    }
