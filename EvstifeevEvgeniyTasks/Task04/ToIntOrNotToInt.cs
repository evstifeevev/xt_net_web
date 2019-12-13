using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task04
{
    class Task0405
    {
        public static void ConsoleInterface()
        {
            //Initializing 
            string str = "+1.0";
            string num = "--12345";
            string pos = "+1";
            string neg = "---54";
            string combined = "--5+4";
            //Checking that the strings are numbers 
            Console.WriteLine("String1: "+str+Environment.NewLine + "String2: " + num);
            Console.WriteLine("String3: " + pos + Environment.NewLine + "String4: " + neg);
            Console.WriteLine("String5: " + combined);
            Console.WriteLine("Checking if the strings are positive integer numbers: " + Environment.NewLine + 
                "Result of String1: " + str.IsNumber() + Environment.NewLine + 
                "Result of String2: " + num.IsNumber() + Environment.NewLine +
                "Result of String3: " + pos.IsNumber() + Environment.NewLine + 
                "Result of String4: " + neg.IsNumber() + Environment.NewLine + 
                "Result of String5: " + combined.IsNumber());

        }
    }
    /// <summary>
    /// Contains extension method string
    /// </summary>
    static class ToIntOrNotToInt
    {
        /// <summary>
        /// Checks if string is a positive integer number.
        /// Does not iclude checking for integers represented as fractions (1.00,2.0,2/5, etc).
        /// Also, does not include operators logic (+,-,/,*,%, etc).
        /// </summary>
        public static bool IsNumber(this string str) 
        {
            //Check for null value
            if (str == null)
                return false;
            //Amount of minuses
            int MinusCount = 0;
            //Index of the last minus
            int LastMinusIndex = -1;
            //Check all symbols of the string
            for (int i = 0; i < str.Length; i++) 
            {
                if (str[i] == '-')
                {
                    //If previous symbol is not minus and current symbol is not the first
                    if (LastMinusIndex != i - 1)
                        return false;
                    //Updates
                    LastMinusIndex = i;
                    MinusCount++;
                } else 
                if (!Char.IsDigit(str[i])&&(str[i]!='+'))
                {
                    //If the symbol is not digit or + then the string is not a number
                    return false;
                }
            }
            //If amount of precede minuses is not even then the string is a negative number
            if (MinusCount % 2 != 0)
                return false;
            return true;
        }
    }
}
