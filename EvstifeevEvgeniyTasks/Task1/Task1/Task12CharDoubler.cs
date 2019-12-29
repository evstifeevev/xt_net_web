using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Task1
{
    internal class Task12CharDoubler
    {
        // State of no response from user.
        // If user don't push enter that counts for no response.
        private static bool _noResponse = true;
        // An interaction interface.
        internal static void ConsoleInterface()
        {
            string str1 = "", str2 = "";
            // Create timer to escape infinite loop.
            Timer timer = new Timer(TimerExit, null, 60000, 60000);
            // Read the first string.
            do
            {
                // Change the user response state to default.
                _noResponse = true;
                Console.Write("Enter the first string: ");
                // Read the first string from console.
                str1 = Console.ReadLine();
                // Change the user state to response.
                _noResponse = false;
                // Reset timer.
                timer.Change(60000, 60000);

            }  
            while (str1.Length < 1);
            // Read the second string.
            do
            {
                _noResponse = true;
                Console.Write("Enter the second string: ");
                // Read the second string from console.
                str2 = Console.ReadLine();
                // Change the user response state to response.
                _noResponse = false;
                // Reset timer.
                timer.Change(60000, 60000);
            } while (str2.Length < 1);
            // Double all symbols of the first string which are
            // contained in both strings.
            CharDoubler(ref str1, ref str2);
            Console.WriteLine("Resulting string: " + str1);
        }
        /// <summary>
        /// Doubles all symbols of the first string which both strings contain.
        /// </summary>
        /// <param name="str1">The first string.</param>
        /// <param name="str2">The second string.</param>
        internal static void CharDoubler(ref string str1, ref string str2){
            // Create new list of char which will contain
            // different symbols.
            List<char> DifferentSymbols = new List<char>();  
            //For each symbol in string.
            foreach (char currentSymbol in str2) {
                // If current symbols in son in the list.
                if (!DifferentSymbols.Contains(currentSymbol)) {
                    // Add the symbol to the list.
                    DifferentSymbols.Add(currentSymbol);
                    // Check if currentSymbol is a symbol character.
                    if (!Char.IsWhiteSpace(currentSymbol)
                        && !Char.IsPunctuation(currentSymbol)
                        && !Char.IsSeparator(currentSymbol))
                        // Check every symbol of the string.
                        for (int i = 0; i < str1.Length; i++)
                        {
                            // If the symbol from the list is contained in the second string.

                            if (str1[i] == currentSymbol)
                            {
                                //Double the symbol.
                                str1 = str1.Insert(i, currentSymbol.ToString());
                                // Change index of the symbol.
                                i++;
                            }
                        }
                }
            }
        }
        private static void TimerExit(object state)
        {
            // Terminate application.
            if (_noResponse) Environment.Exit(0);
        }
    }
}
