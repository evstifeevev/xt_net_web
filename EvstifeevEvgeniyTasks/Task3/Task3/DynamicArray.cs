using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Subtask3
{
    class DynamicArray<T> : IEnumerable<T>
        where T : IComparable
    {
        public int Capacity { get { return _array.Length; } }
        public int Length
        {
            get
            {
                for (int i = 0; i < _array.Length; i++)
                {
                    if (!_arrayValuableItems[i] || i == _array.Length)
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
            for (int i = 0; i < MyCount(collection); i++)
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
                _array = new T[_array.Length * 2];
                _arrayValuableItems = new bool[_array.Length];
                for (int i = 0; i < temp.Length; i++)
                {
                    _array[i] = temp[i];
                    _arrayValuableItems[i] = true;
                }
                _array[temp.Length] = item;
                _arrayValuableItems[temp.Length] = true;
                return;
            }
            for (int i = 0; i < _array.Length; i++)
            {
                if (!_arrayValuableItems[i])
                {
                    _array[i] = item;
                    _arrayValuableItems[i] = true;
                    return;
                }
            }
        }
        public void AddRange(IEnumerable<T> collection)
        {
            if (MyCount(collection) + Length > Capacity)
            {
                T[] temp = new T[_array.Length];
                for (int i = 0; i < temp.Length; i++)
                {
                    temp[i] = _array[i];
                }
                int length = Length;
                int newCapacity = _array.Length * 2;
                while (newCapacity < temp.Length + MyCount(collection))
                    newCapacity *= 2;
                _array = new T[newCapacity];
                _arrayValuableItems = new bool[newCapacity];
                for (int i = 0; i < temp.Length; i++)
                {
                    _array[i] = temp[i];
                    _arrayValuableItems[i] = true;
                }
                for (int i = 0; i < MyCount(collection); i++)
                {
                    _array[i + length] = collection.ElementAt(i);
                    _arrayValuableItems[i + length] = true;
                }
                return;
            }
            for (int i = 0; i < _array.Length; i++)
            {
                if (!_arrayValuableItems[i])
                {
                    for (int k = 0; k < MyCount(collection); k++)
                    {
                        _array[k + i] = MyElementAt(collection, k);
                        _arrayValuableItems[k + i] = true;
                    }
                    return;
                }
            }
        }
        private T MyElementAt(IEnumerable<T> collection, int k)
        {
            if (k >= MyCount(collection))
                throw new ArgumentOutOfRangeException();
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
            int length = Length;
            T[] temp = new T[_array.Length];
            for (int i = 0; i < length; i++)
            {
                while (item.CompareTo(_array[i]) == 0)
                {
                    result = true;
                    i++;
                }
                if (item.CompareTo(_array[i]) != 0)
                {
                    if (i < length)
                    {
                        temp[newIndex] = _array[i];
                        removableItems[newIndex] = true;
                    }
                    newIndex++;
                }

            }
            if (result)
            {
                int newCapacity = Capacity;
                while (newIndex <= newCapacity / 2)
                {
                    newCapacity /= 2;
                }
                _array = new T[newCapacity];
                _arrayValuableItems = new bool[newCapacity];
                Array.Copy(temp, _array, newIndex);
                Array.Copy(removableItems, _arrayValuableItems, newIndex);
            }
            return result;
        }
        public bool Insert(T item, int position)
        {
            bool result = false;
            int length = Length;
            if (position >= Length)
                throw new ArgumentOutOfRangeException();
            if (_arrayValuableItems[_array.Length - 1])
            {
                T[] temp = new T[_array.Length];
                for (int i = 0; i < _array.Length; i++)
                {
                    temp[i] = _array[i];
                }
                _array = new T[_array.Length * 2];
                _arrayValuableItems = new bool[_array.Length];
                for (int i = 0; i < temp.Length; i++)
                {
                    _array[i] = temp[i];
                    _arrayValuableItems[i] = true;
                }
                _arrayValuableItems[temp.Length] = true;
            }
            for (int i = length + 1; i >= position; i--)
            {
                _array[i] = _array[i - 1];
            }
            _array[position] = item;
            return result;
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
