using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task0.Task02
{
    internal class ConsoleUI
    {
        internal static void Run() 
        {
            int n = Common.ConsoleUI.ReadInt("Enter an unsigned integer number:",
                new Predicate<int>(x => x >= 0));
            Console.WriteLine("The classical test: "+Environment.NewLine+$"The number {n} is " 
                + (Prime.IsPrime((uint)n)? "" : "not ") + "a prime number.");
            Console.WriteLine("The Fermat test: " + Environment.NewLine + $"The number {n} is "
                + (Prime.IsPrimeFermat(n, 1000000000) ? "" : "not ") + "a prime number.");
        }
    }
}
