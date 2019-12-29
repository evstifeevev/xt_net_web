using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7
{
    class SubTask5UI
    {
        public static void ConsoleInterface()
        {
            RegularExpressionsCheck regularExpressionsCheck = new RegularExpressionsCheck();
            string text = CommonConsoleUI.GetString("This program displays the count of time contained in a text. " + Environment.NewLine +
            "Enter text that contains time: ", "This string is empty. Enter another string.");
            Console.WriteLine($"Time appears in the text {regularExpressionsCheck.TimeCount(text)} time(s).");
        }
    }
}
