using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task0.Task01
{
    public class ConsoleUI
    {
        public static void Run() 
        {
            int n = Common.ConsoleUI.ReadInt("Enter the positive integer number:",
                new Predicate<int>(x=>x>0));
            Console.WriteLine("The sequence: " + Sequence.Create((ulong)n));
        }
    }
}
