using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7.UI
{
    class SubTask1UI
    {
        public static void ConsoleInterface()
        {
            // Instantiate class RegularExpressionsCheck to use predefined regular expression methods
            RegularExpressionsCheck regularExpressionsCheck = new RegularExpressionsCheck();
            string text = CommonConsoleUI.GetString("This program checks if an entered text contains date. " + Environment.NewLine +
            "Enter text that contains date: ", "This string is empty. Enter another string.");
            if (regularExpressionsCheck.IsDate(text)) 
            {
                Console.WriteLine("The text " + text.Trim() + " contains date.");
            } else 
            {
                Console.WriteLine("The text " + text.Trim() + " does not contain date.");
            }
        }
    }
}
