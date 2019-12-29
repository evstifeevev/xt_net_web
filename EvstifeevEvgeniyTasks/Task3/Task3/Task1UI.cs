using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Subtask1;
using Task3.Subtask3;

namespace Task3.UI
{
    internal class Task1UI
    {
        internal static void ConsoleInterface()
        {
            Lost<Person> list = new Lost<Person>();
            for (int i = 0; i < 3; i++)
                list.Add(new Person($"Jerry the 1th"));
            for (int i = 0; i < 9; i++)
                list.Add(new Person($"Jerry the {i}th"));
            Console.WriteLine("List of all persons:");
            foreach (var item in list)
                Console.WriteLine(item);
            Console.WriteLine($"Count of persons is {list.Count}");
            Console.WriteLine($"The next person number is {list.Next(true)}");
            Console.WriteLine($"The next person is {list.NextPerson()}");
            list.Remove(new Person($"Jerry the 1th"));
            Console.WriteLine($"Removed Jerry the 1th");
            Console.WriteLine("List of all persons:");
            foreach (var item in list)
                Console.WriteLine(item);
            Console.WriteLine($"Count of persons is {list.Count}");
            Console.WriteLine($"The next person number is {list.Next(true)}");
            Console.WriteLine($"The next person is {list.NextPerson()}");
            list.RemoveAllExceptNext();
            Console.WriteLine($"Count of persons is {list.Count}");
            Console.WriteLine($"The next person number is {list.Next(true)}");
            Console.WriteLine($"The next person is {list.NextPerson()}");
        }
    }
}
