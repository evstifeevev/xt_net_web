using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7
{
    class SubTask2UI
    {
        public static void ConsoleInterface()
        {
            RegularExpressionsCheck regularExpressionsCheck = new RegularExpressionsCheck();
            string text = CommonConsoleUI.GetString("This program replaces all html tags in entered text. " + Environment.NewLine +
                "Enter text that contains html tag(s): ", "This string is empty. Enter another string.");
            Console.WriteLine(Environment.NewLine + "Replace result: " +
    regularExpressionsCheck.RemoveHtmlTags(text));
        }
    }
}
