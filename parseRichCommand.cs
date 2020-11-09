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
        
        public ParseRichCommand(PictureBox pictureBox, ParseCommand parseCommand)
        {
            this.pictureBoxCanvas = pictureBox;
            this.parseTell = parseCommand;
        }

        public void parseRich(string commands)
        {
            List<string> commandList = new List<string>(
                commands.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries));

            foreach (string input in commandList)
            {
                parseTell.Parse(input);
            }
        }
    }
}
