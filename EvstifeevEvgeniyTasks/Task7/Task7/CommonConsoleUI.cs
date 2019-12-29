using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7
{
    public abstract class CommonConsoleUI
    {
        public static string GetString(string message, string error) 
        {
            Console.Write(message);
            string line = string.Empty;
            do
            {
                line = Console.ReadLine();
                if (line.Length < 1)
                {
                    Console.WriteLine(error);
                }
            }
            while ((line).Length < 1);
            return line;
        } 
    }
}
