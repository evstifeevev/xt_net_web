using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task03
{
    public class Task0303
    {
        public static void ConsoleInterface()
        {
            var array = new DynamicArray<int>();
            var list = new List<int>();
            Console.WriteLine("List elements: ");
            for (int i = 0; i < 10; i++)
            {
                list.Add(i % 3);
                Console.Write(list[i]+ ",");
            }
            Console.WriteLine(Environment.NewLine+"Dynamic array elements: ");
            for (int i = 0; i < 10; i++)
            {
                array.Add(i % 4);
                Console.Write(array[i] + ",");
            }
            Console.WriteLine(Environment.NewLine + "Dynamic array elements: ");
        }
    }
    class DynamicArray<T> : IEnumerable<T>
        where T:IComparable
    {
        public int Capacity{ get {return _array.Length; } }
        public int Length { 
            get 
            {
                for (int i = 0; i < _array.Length; i++)
                {
                    if (!_arrayValuableItems[i] || i ==_array.Length)
                        return i;
                }
                return _array.Length;
            }
        }
        T[] _array = null;
        bool[] _arrayValuableItems = null;
        /// <summary>
        /// Creates array with 8 elements.
        /// </summary>
        public DynamicArray() 
        {
            _array = new T[8];
            _arrayValuableItems = new bool[8];
        }
        /// <summary>
        /// Creates array with specified capacity.
        /// </summary>
        /// <param name="capacity"></param>
        public DynamicArray(int capacity) 
        {
            _array = new T[capacity];
            _arrayValuableItems = new bool[capacity];
        }
        public DynamicArray(IEnumerable<T> collection) 
        {
            _array = new T[MyCount(collection)];
            for (int i=0;i< MyCount(collection); i++)
            {
                _array[i] = MyElementAt(collection, i);
            }
        }
        /// <summary>
        /// Adds an element to the end of the array.
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item) 
        {
            if (_arrayValuableItems[_array.Length - 1])
            {
                T[] temp = new T[_array.Length];
                for (int i = 0; i < _array.Length; i++) 
                {
                    temp[i] = _array[i];
                }
                _array = new T[_array.Length*2];
                _arrayValuableItems = new bool[_array.Length];
                for (int i = 0; i < temp.Length; i++)
                {
                    _array[i] = temp[i];
                    _arrayValuableItems[i] = true;
                }
                _array[temp.Length + 1] = item;
                return;
            }
            for (int i=0;i<_array.Length;i++)
            {
                if (!_arrayValuableItems[i]) { 
                    _array[i] = item;
                    _arrayValuableItems[i] = true;
                    return;
                }
            }
        }
        public void AddRange(IEnumerable<T> collection)
        {
            if (_arrayValuableItems[_array.Length - 1])
            {
                T[] temp = new T[_array.Length];
                
                int newCapacity = _array.Length * 2;
                while (newCapacity < temp.Length + MyCount(collection))
                    newCapacity *= 2;
                _array = new T[newCapacity];

                for (int i = 0; i < temp.Length; i++)
                {
                    _array[i] = temp[i];
                }
                for (int i = 0; i < MyCount(collection); i++)
                {
                    _array[i + temp.Length] = collection.ElementAt(i);
                }
                return;
            }
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i] == null)
                {
                    for (int k = 0; k < MyCount(collection); k++)
                    {
                        _array[k + i] = MyElementAt(collection, k);
                        _arrayValuableItems[k+i] = true;
                    }
                    return;
                }
            }
        }
        private T MyElementAt(IEnumerable<T> collection, int k) 
        {
            int temp = 0;
            foreach (T item in collection) 
            {
                if (temp == k) return item;
                temp++;
            }
            throw new ArgumentException();
        }
        private int MyCount(IEnumerable<T> collection)
        {
            int temp = 0;
            try
            {

                foreach (T item in collection)
                {
                    temp++;
                }
                if (temp == 0)
                {
                    throw new ArgumentException();
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            return temp;
            
        }
        public bool Remove(T item)
        {
            bool result = false;
            bool[] removableItems = new bool[_array.Length];
            int newIndex = 0;
            T[] temp = new T[_array.Length];
            for (int i = 0; i < _array.Length; i++)
            {
                if (item.CompareTo(_array[i]) ==0) 
                {
                    result = true;
                    newIndex++;
                } 
                else temp[newIndex] = _array[i];
            }
            if (result) 
            { 
                Array.Copy(temp, _array,temp.Length);
            }
            return result;
        }
        public void Insert() 
        { 
            
        }
        public IEnumerator<T> GetEnumerator()
        {
            return (_array as IEnumerable<T>).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _array.GetEnumerator();
        }
        public T this[int i]
        {
            get
            {
                if (i > Length)
                    throw new ArgumentOutOfRangeException();
                return _array[i];
            }
            set
            {
                if (i > Length)
                    throw new ArgumentOutOfRangeException();
                _array[i] = value;
            }
        }
    }
}
