using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Subtask2
{
    public class MyList<T> : Task3.Subtask1.Lost<T>
        where T : IComparable<T>
    {
        public T this[int i]
        {
            get
            {
                if (i > Count)
                    throw new ArgumentOutOfRangeException();
                return people[i];
            }
            set
            {
                if (i > Count)
                    throw new ArgumentOutOfRangeException();
                people[i] = value;
            }
        }
    }
}
