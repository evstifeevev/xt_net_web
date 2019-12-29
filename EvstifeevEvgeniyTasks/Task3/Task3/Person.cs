using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Subtask3
{
    public class Person : IComparable<Person>
    {
        public string Name = "";
        public int Number { get; }
        public Person(int num)
        {
            Number = num;
        }
        public Person()
        {
        }
        public Person(string name)
        {
            this.Name = name;
        }
        public override string ToString() => Name;

        public int CompareTo(Person other)
        {
            return this.Name == other.Name && this.Number == other.Number ?
                0
                : this.Name.CompareTo(other.Name) != 0 ?
                this.Name.CompareTo(other.Name)
                : this.Number.CompareTo(other.Number);
        }
    }
}
