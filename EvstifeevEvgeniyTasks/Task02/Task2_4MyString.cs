using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    class Task2_4MyString
    {
        public static void ConsoleInterface() {
            MyString myString = new MyString("Example of a string.");
            Console.WriteLine(nameof(myString) +": "+ myString);
            MyString myString2 = new MyString("Example of a string № 2.".ToCharArray());
            Console.WriteLine(nameof(myString2) + ": " + myString2);
            Console.WriteLine("Length of myString = " + myString.Length);
            Console.WriteLine("First string == second string? " + (myString == myString2));
            Console.WriteLine("First string != second string? " + (myString != myString2));
            Console.WriteLine("First string == first string? " + (myString == new MyString("Example of a string.")));
            Console.WriteLine("First string > second string? " + (myString > myString2));
            Console.WriteLine("First string < second string? " + (myString < myString2));
            Console.WriteLine("First string >= second string? " + (myString >= myString2));
            Console.WriteLine("First string <= second string? " + (myString <= myString2));

            Console.WriteLine("Index of 'a' in myString = " + myString.IndexOf('a'));
            Console.WriteLine("Last index of 'a' in myString = " + myString.LastIndexOf('a'));

        }
        public class MyString
        {
            private readonly char[] _string;
            public int Length { get { return _string.Length; }  }

            /// <summary>
            /// Creates string from array of chars.
            /// </summary>
            /// <param name="chars"></param>
            public MyString(char[] chars) {
                _string = new char[chars.Length];
                Array.Copy(chars, 0, _string, 0,chars.Length);
            }
            /// <summary>
            /// Creates string from string.
            /// </summary>
            /// <param name="str"></param>
            public MyString(string str)
            {
                _string = new char[str.Length];
                for (int i = 0; i < str.Length; i++)
                    _string[i] = str[i];
            }
            /// <summary>
            /// Returns string converted from char[].
            /// </summary>
            /// <param name="chars"></param>
            /// <returns></returns>
            public static string ConvertToString(MyString myString) {
                string result="";
                foreach (var c in myString) result += c;
                return result;
            }
            /// <summary>
            /// Returns char[] converted from string.
            /// </summary>
            /// <param name="chars"></param>
            /// <returns></returns>
            public static MyString ConvertToString(string str)
            {
                MyString result = new MyString(new char[str.Length]);
                for (int i = 0; i < str.Length; i++)
                    result[i] = str[i];
                return result;
            }
            /// <summary>
            /// Returns index of the first char == c and -1 if Mystring does not contain 
            /// the symbol.
            /// </summary>
            /// <param name="c"></param>
            /// <returns></returns>
            public int IndexOf( char c)
            {
                for (int i = 0; i < this.Length; i++)
                    if (this[i] == c)
                        return i;
                return -1;
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="c"></param>
            /// <returns></returns>
            public int LastIndexOf( char c)
            {
                for (int i = this.Length-1; i >= 0; i--)
                    if (this[i] == c)
                        return i;
                return -1;
            }
            public static MyString operator +(MyString myString1, MyString myString2) {
                int allCount = myString1.Length + myString2.Length;
                char[] result = new char[allCount];
                for (int i = 0; i < myString1.Length; i++)
                    result[i] = myString1[i];
                for (int i = myString1.Length; i < myString2.Length; i++)
                    result[i] = myString2[i- myString1.Length];
                return new MyString(result);
            }
            public static bool operator >(MyString myString1, MyString myString2) =>  myString1.Length > myString2.Length;
            public static bool operator <(MyString myString1, MyString myString2) => myString1.Length < myString2.Length;
            public static bool operator >=(MyString myString1, MyString myString2) => !(myString1 < myString2);
            public static bool operator <=(MyString myString1, MyString myString2) => !(myString1 > myString2);
            public static bool operator ==(MyString myString1, MyString myString2) {
                if (myString1.Length != myString2.Length)
                    return false;
                for (int i = 0; i < myString1.Length; i++)
                    if (myString1[i] != myString2[i])
                        return false;
                return true;
            }
            public static bool operator !=(MyString myString1, MyString myString2)
            {
                return !(myString1==myString2);
            }
            public char this[int index] {
                get
                {
                    return _string[index];
                }
                set
                {
                    _string[index] = value;
                }
            }
            

            public override bool Equals(object obj)
            {
                return base.Equals(obj);
            }
            public override int GetHashCode()
            {
                return base.GetHashCode();
            }
            public override string ToString()
            {
                return ConvertToString(this);
            }
            public IEnumerator GetEnumerator() 
            { 
                return _string.GetEnumerator(); 
            }
        }
    }
}
