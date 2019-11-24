using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Task1_11AverageStringLength
    {
        /// <summary>
        /// Returns average length of word in string.
        /// If any exception occures returns 0.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int AverageWordLength(string str) {
            try
            {
                int sumOfWords = 0,//Sum of words
                    numberOfWords = 0;//Amount of words
                bool newWord = true;//Flag if new word has been found
                for (int i = 0; i < str.Length; i++)//For all symbols of the string
                {
                    if (!char.IsPunctuation(str[i]) &&//If symbol is not punctuation
                        !char.IsWhiteSpace(str[i]) &&//or whitespace
                        !char.IsSeparator(str[i]))//or separator
                    {
                        sumOfWords++;//Update sum of words
                        if (newWord)//If new word has been found
                        {
                            numberOfWords++;//update number of words
                            newWord = false;//reverse flag
                        }

                    }
                    else if (!newWord) newWord = true;//if symbol is punctuation, whitespace or separator then
                    //create reverse flag
                }
                if (numberOfWords < 1) return 0;//return 0 if the string contains no words
                else return (sumOfWords / numberOfWords);//return average word length
            }
            catch (Exception e) {//If exception occures
                Console.WriteLine(e);//Display the discription of exception
                return 0;
            }
        }
        public static void ConsoleInterface()//An interaction interface
        {
            Console.WriteLine("Example string:");
            string str = @"Format Item Syntax
Each format item takes the following form and consists of the following components:

{ index[,alignment][:formatString]}

The matching braces (""{ "" and ""}
            "") are required.";//Example string
            Console.WriteLine(str);//Display the string
            Console.WriteLine("The average length of the words equals to " + AverageWordLength(str));//Display average 
            //word length in the string
        }
    }
}
