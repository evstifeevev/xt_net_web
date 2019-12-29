using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Task11AverageStringLength
    {
        // An interaction interface.
        internal static void ConsoleInterface()
        {
            Console.WriteLine("Example string:");
            // Example string.
            string str = @"Format Item Syntax
Each format item takes the following form and consists of the following components:

{ index[,alignment][:formatString]}

The matching braces (""{ "" and ""}
            "") are required.";
            // Display the string.
            Console.WriteLine(str);
            // Display average length of words in the string.
            Console.WriteLine("The average length of the words equals to "
                + AverageWordLength(str));
        }
        /// <summary>
        /// Returns average length of word in string.
        /// If any exception occures returns 0.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        internal static int AverageWordLength(string str) {
            try
            {
                // Sum of words.
                int sumOfWords = 0,
                // Amount of words.
                 numberOfWords = 0;
                // Flag if new word has been found.
                bool newWord = true;
                // For all symbols of the string.
                for (int i = 0; i < str.Length; i++)
                {
                    if (
                        // If symbol is not a punctuation nor a whitespace nor a separator.
                        !char.IsPunctuation(str[i]) &&
                        !char.IsWhiteSpace(str[i]) &&
                        !char.IsSeparator(str[i]))
                    {
                        // Update sum of words.
                        sumOfWords++;
                        if (newWord)// If new word has been found.
                        {
                            numberOfWords++;// Update number of words.
                            newWord = false;// Rverse flag.
                        }

                    }
                    else if (!newWord) 
                    {
                        // if symbol is punctuation, whitespace or separator then
                        // create reverse flag.
                        newWord = true; 
                    }
                }
                if (numberOfWords < 1) 
                {
                    // Return 0 if the string contains no words.
                    return 0; 
                }

                else
                    // Return average word length.
                    return (sumOfWords / numberOfWords);
            }
            catch (Exception e) 
            {
                
                // Display the discription of exception.
                Console.WriteLine(e);
                return 0;
            }
        }

    }
}
