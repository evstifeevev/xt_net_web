using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Subtask3;

namespace Task3.UI
{
    class Task3UI
    {
        public static void ConsoleInterface()
        {
            var array = new DynamicArray<int>();
            var list = new List<int>();
            Console.WriteLine("List elements: ");
            for (int i = 0; i < 10; i++)
            {
                list.Add(i % 3 + 1);
                Console.Write(list[i] + ",");
            }

            for (int i = 0; i < 10; i++)
            {
                array.Add(i % 4 + 1);
                Console.WriteLine("Adding " + array[i] + ":" + Environment.NewLine +
                    "Dynamic array length: " + array.Length + Environment.NewLine +
                     "Dynamic array capacity: " + array.Capacity);
            }
            Console.WriteLine(Environment.NewLine + "Dynamic array elements: ");
            foreach (var item in array)
            {
                Console.Write(item + ",");
            }
            Console.WriteLine(Environment.NewLine + "Array after removing item = 1:");
            if (array.Remove(1)) Console.WriteLine("Success!");
            else Console.WriteLine("There is no such item!");
            foreach (var item in array)
            {
                Console.Write(item + ",");
            }
            Console.WriteLine("Dynamic array length: " + array.Length + Environment.NewLine +
     "Dynamic array capacity: " + array.Capacity);
            Console.WriteLine("Adding a list to the dynamic array:");
            array.AddRange(list);
            foreach (var item in array)
            {
                Console.Write(item + ",");
            }
            Console.WriteLine("Dynamic array length: " + array.Length + Environment.NewLine +
     "Dynamic array capacity: " + array.Capacity);
            Console.WriteLine(Environment.NewLine + "Array after insertion of item = 9 at 9th position:");
            if (array.Insert(9, 9)) Console.WriteLine("Success!");
            else Console.WriteLine("Failure!");
            foreach (var item in array)
            {
                Console.Write(item + ",");
            }
            Console.WriteLine("Dynamic array length: " + array.Length + Environment.NewLine +
     "Dynamic array capacity: " + array.Capacity);
        }
    }
}
