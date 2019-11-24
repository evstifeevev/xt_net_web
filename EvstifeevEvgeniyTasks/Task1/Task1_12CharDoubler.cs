using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Task1
{
    class Task1_12CharDoubler
    {
        /// <summary>
        /// Doubles all symbols of the first string which both strings contain.
        /// </summary>
        /// <param name="str1">The first string</param>
        /// <param name="str2">The second string</param>
        public static void CharDoubler(ref string str1, ref string str2){
            List<char> DifferentSymbols = new List<char>();  //Create new list of char which will contain
            //different symbols
            foreach (char currentSymbol in str2) {//For each symbol in string
                if (!DifferentSymbols.Contains(currentSymbol)) {//If current symbols in son in the list
                    DifferentSymbols.Add(currentSymbol);//Add the symbol to the list
                    if(!Char.IsWhiteSpace(currentSymbol)
                        && !Char.IsPunctuation(currentSymbol)
                        && !Char.IsSeparator(currentSymbol)) //Check if currentSymbol is a symbol character
                        for (int i = 0; i < str1.Length; i++)//Check every symbol of the string
                            if (str1[i] == currentSymbol) {//If the symbol from the list is contained in the second string
                                str1=str1.Insert(i, currentSymbol.ToString());//Double the symbol
                                i++;//Change index of symbol
                            }
                }
            }
        }
        public static void ConsoleInterface()//An interaction interface
        {
            string str1 = "", str2 = "";
            Timer timer = new Timer(timerExit, null, 60000, 60000);//Create timer to escape infinite loop
            do
            {
                noResponse = true;//Change the user state to default
                Console.Write("Enter the first string: ");
                str1 = Console.ReadLine();//Read the first string from console
                noResponse = false;//Change the user state to response
                timer.Change(60000, 60000);//reset timer
            } while (str1.Length < 1);//While the string is empty
            do
            {
                noResponse = true;//Change the user state to default
                Console.Write("Enter the second string: ");
                str2 = Console.ReadLine();//Read the second string from console
                noResponse = false;//Change the user state to response
                timer.Change(60000, 60000);//reset timer
            } while (str2.Length < 1);//While the string is empty
            CharDoubler(ref str1,ref str2);//Double all symbols of the first string which are
            //contained in both strings
            Console.WriteLine("Resulting string: "+str1);
        }
        private static void timerExit(object state)
        {
            if (noResponse) Environment.Exit(0);//Terminate application
        }
        private static bool noResponse = true;//State of no response from user
        //If user don't push enter that counts for no response
    }
}
