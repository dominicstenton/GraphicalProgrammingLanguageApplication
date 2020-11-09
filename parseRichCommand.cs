using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalProgrammingLanguageApplication
{
    class parseRichCommand
    {
        pictureBox pictureBoxCanvas;
        parseCommand parseCommander;
        square drawSquare;
        circle drawCircle;
        triangle drawTriangle;

        public parseRichCommand(pictureBox pictureBox, parseCommand parseCommand)
        {
            this.pictureBoxCanvas = pictureBox;
            this.parseCommander = parseCommand;
        }

        public void parseRich(string commands)
        {
            List<string> commandList = new List<string>(
                commands.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries));

            foreach (string input in commandList)
            {
                parseCommander.Parse(input);
            }
        }
    }
}
