using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Task7
{
    class SubTask3UI
    {
        public static void ConsoleInterface()
        {
            RegularExpressionsCheck regularExpressionsCheck = new RegularExpressionsCheck();
            string text = CommonConsoleUI.GetString("This program displays all emails found in an entered text. " + Environment.NewLine +
            "Enter text that contains email(s): ", "This string is empty. Enter another string.");
            Console.WriteLine(Environment.NewLine + "Emails found: ");
            MatchCollection emails = regularExpressionsCheck.GetEmails(text);
            foreach (Match item in emails)
            { 
                Console.WriteLine(item);
            }

          

        }
    }
}
