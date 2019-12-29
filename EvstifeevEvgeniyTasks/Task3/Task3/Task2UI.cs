using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Subtask2;

namespace Task3.UI
{
    internal class Task2UI
    {
            internal static void ConsoleInterface()
            {
                var list = new WordFrequency<float>("Peter Piper picked a peck of pickled peppers. " +
                    "A peck of pickled peppers Peter Piper picked. If Peter Piper picked a peck of pickled peppers, " +
                    "Where's the peck of pickled peppers Peter Piper picked?");
                for (int i = 0; i < list.Count; i++)
                {
                    Console.WriteLine($"Frequency of the word \"{list.Words[i]}\" is {list[i]}");
                }
            }
    }
}
