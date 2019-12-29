using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task0.Task03
{
    internal class ConsoleUI
    {
        internal static void Run() 
        {
            int n = Common.ConsoleUI.ReadInt("Enter a positive integer number:",
                new Predicate<int>(x => x > 0));
            Square.DrawSquare((uint) n);
        }
    }
}
