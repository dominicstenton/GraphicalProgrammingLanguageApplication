using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalProgrammingLanguageApplication
{
    class parseCommand
    {
        pictureBox pictureBoxCanvas;
        square drawSquare;
        circle drawCircle;
        triangle drawTriangle;

        public parseCommand(pictureBox pictureBox, circle drawCircle, square drawSquare, triangle drawTriangle)
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
                        Console.WriteLine(instruction + " " + variable1);
                        
                    }

                    catch (FormatException)
                    {
                        Console.WriteLine("error here val1");
                      
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
                        Console.WriteLine("error here val2");
                    }

                }

                else
                {
                    Console.Write("Erro8r");
                }
            }

            try {

                if (instruction.Equals("drawto") == true)
                {
                    pictureBoxCanvas.drawLine(variable1, variable2);
                    Console.WriteLine("Line has been drawn");

                }

                else if (instruction.Equals("moveto") == true)
                {
                    pictureBoxCanvas.moveLine(variable1, variable2);
                    Console.WriteLine("You have moved the pen position");
                }

                else if (instruction.Equals("rect") == true)
                {
                    drawSquare.createSquare(variable1, variable2);
                    Console.WriteLine("Square has been drawn");
                }

                else if (instruction.Equals("circle") == true)
                {
                    drawCircle.createCircle(variable1);
                    //Console.WriteLine("Circle has been drawn");
                }

                else if (instruction.Equals("triangle") == true)
                {
                    drawTriangle.createTriangle(variable1, variable2);
                    Console.WriteLine("Triangle has been drawn");
                }

                //Changes pen color to red
                else if (instruction.Equals("penred") == true)
                {
                    pictureBoxCanvas.changePenRed();
                }

                //Changes pen color to blue
                else if (instruction.Equals("penblue") == true)
                {
                    pictureBoxCanvas.changePenBlue();
                }

                //Changes pen color to green
                else if (instruction.Equals("pengreen") == true)
                {
                    pictureBoxCanvas.changePenGreen();
                }

                else if (instruction.Equals("fillon") == true)
                {
                    drawSquare.brushOn();
                    drawCircle.brushOn();
                    drawTriangle.brushOn();
                    Console.WriteLine("Brush ON");

                }

                else if (instruction.Equals("filloff") == true)
                {
                    drawSquare.brushOff();
                    drawCircle.brushOff();
                    drawTriangle.brushOff();
                    Console.WriteLine("Brush OFF");
                }

                else if (instruction.Equals("reset") == true)
                {
                    pictureBoxCanvas.resetPen(0, 0);
                    Console.WriteLine("Reset");
                }

                else if (instruction.Equals("clear") == true)
                {
                    pictureBoxCanvas.clearCanvas();
                    Console.WriteLine("Canvas Cleared");
                }

            }
            catch (ArgumentException)
            {
                Console.WriteLine("Com");
            }

            }
        }

    }
