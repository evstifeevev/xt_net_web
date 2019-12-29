using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class ConsoleUI
    {
        public static int ReadInt(string message, Predicate<int> condition)
        {
            int n = 0;
            Console.WriteLine(message);
            while (!int.TryParse(Console.ReadLine(), out n) || !condition(n))
            {
                Console.WriteLine("Wrong number. Try again.");
            }
            return n;
        }
    }
}
