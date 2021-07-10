using System;

namespace GraphicalProgrammingLanguageApplication
{
    /// <summary>This class is used to generate custom exceptions.</summary>
    class exception : Exception
    {
        /// <summary>Handles the exception.</summary>
        /// <param name="use">Unused.</param>
        public void handle()
        {
            System.InvalidOperationException exceptionOne = new System.InvalidOperationException("Custom Exception: This operation isn't allowed. Please rerun the program.");
            System.Windows.Forms.MessageBox.Show("exception" + exceptionOne);
        }
    }
}
