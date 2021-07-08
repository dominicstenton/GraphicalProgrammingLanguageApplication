using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicalProgrammingLanguageApplication
{
    class exception : Exception
    {
        public void stuff(int mars)
        {
 
            System.InvalidOperationException exceptionOne = new System.InvalidOperationException("this operation isn't allowed");
            throw exceptionOne;
            MessageBox.Show("Test");

        }
        
    }
}
