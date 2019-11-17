using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvstifeevEvgeniyTasks
{
    class Task01
    {
        public static string Sequence(ulong n)  //The function return a sequence of the form: 1,2,3,...,n  
        {
            if (n > 0)  //Check if the number is positive
            {
                string Result = ""; //The result string
                for (ulong i = 1; i <= n; i++) Result += i.ToString();  //Add data to the result string
                return Result;  //Return the result
            }
            return "Error: the input number must be a positive integer."; //Return an error string
        }
    }
}
