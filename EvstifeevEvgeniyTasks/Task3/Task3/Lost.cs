using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Subtask1
{
    public class Lost<T> : ICollection<T>
        where T : IComparable<T>
    {

        protected T[] people = new T[4];

        public int Count = 0;

        public bool IsReadOnly => false;

        int ICollection<T>.Count => Count;

        private int _capacity = 4;
        public virtual void Add(T item)
        {
            var temp = people!=null? people : new T[0];
            
            int LastIndex = 0;
                if (people == null || Count >= _capacity)
                {
                    if (Count >= _capacity)
                    {
                        LastIndex = people.Length;
                        _capacity *= 2;
                    }
                    people = new T[_capacity];
                    for (int i = 0; i < temp.Length; i++)
                        people[i] = temp[i];
                }
                else while (people[LastIndex] != null)
                        LastIndex++;
            people[LastIndex] = item;
            Count = LastIndex+1;
        }
        public int Next(bool printInfo) {
            if (Count < 2) return 0;
            bool[] unchosen = new bool[Count];
            for (int i = 0; i < Count; i++)
                unchosen[i] = true;
            int itemIndex = 1;
            int generalIndex = 1;
            // Find the last item index.
            while (generalIndex < Count)
            {
                if (unchosen[itemIndex])
                {
                    if(printInfo) Console.WriteLine($"{itemIndex}th person has been excluded.");
                    unchosen[itemIndex] = false;
                    generalIndex++;
                }
                itemIndex = (itemIndex + 2)>=Count? (itemIndex + 1) % Count : (itemIndex + 2) % Count;
            }
            int lastItemIndex = 0;
            while (unchosen[lastItemIndex] == false)
                lastItemIndex++;
            return lastItemIndex;
        }
        public int Next()
        {
            return Next(false);
        }
        public T NextPerson() => people[Next()];
        public void RemoveAllExceptNext() {
            // Remove all items except one that was not chosen.
            people = new T[] { people[Next()] };
            _capacity = 4;
            Count = 1;
        }

        public void Clear()
        {
            people = null;
            Count = 0;
            _capacity = 4;
        }


        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)people).GetEnumerator();
        }

        public bool Remove(T item)
        {
            int newCount = Count;
            bool[] removableItems = new bool[Count];
        
            for (int i = 0; i < Count; i++)
                if (item.ToString()==(people[i].ToString())) 
                {
                    removableItems[i] = true;
                    newCount--;
                }
                else removableItems[i] = false;
            T[] temp = new T[Count];
            int k = 0;
            int newIndex = 0;
            while (removableItems.Contains(true))
            {
                if (removableItems[k])
                {
                    removableItems[k] = false;
                }
                else
                {
                    temp[newIndex] = people[k]; 
                    newIndex++;
                }
                k++;
                if (!removableItems.Contains(true)) {
                    while (k < Count) 
                    { 
                        temp[newIndex] = people[k];
                        k++;
                        newIndex++;
                    }
                    people = new T[newCount];
                    people = temp;
                    Count = newCount;
                    return true;
                }
            }
            return false;
        }

        public bool Contains(T item)
        {
            if (people == null)
                throw new NullReferenceException();
            foreach (var person in people)
                if (item.Equals(person))
                    return true;
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            for (int i = arrayIndex; i < Count; i++) 
            {
                array[i - arrayIndex] = people[i];
            }
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return people.GetEnumerator();
        }
    }

}
