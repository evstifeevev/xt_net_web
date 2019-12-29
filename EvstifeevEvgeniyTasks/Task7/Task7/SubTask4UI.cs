using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Task7
{
    class SubTask4UI
    {
        public static void ConsoleInterface()
        {
            RegularExpressionsCheck regularExpressionsCheck = new RegularExpressionsCheck();
            string text = CommonConsoleUI.GetString("This program displays notation type of entered real number. " + Environment.NewLine +
            "Enter a real number: ", "This string is empty. Enter another string.");
            if (regularExpressionsCheck.IsCommonRealNumber(text))
            {
                Console.WriteLine("The number is in the common notation.");
            }
            else if (regularExpressionsCheck.IsScientificRealNumber(text))
            {
                Console.WriteLine("The number is in the scientific notation.");
            }
            else 
            {
                Console.WriteLine("This is not a number.");
            }
        }
    }
}
