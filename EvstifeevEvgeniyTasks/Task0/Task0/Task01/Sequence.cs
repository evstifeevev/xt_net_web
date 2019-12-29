using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task0.Task01
{
    class Sequence
    {
        /// <summary>
        ///  Returns a sequence of the form: 1,2,3,...,n  
        /// </summary>
        /// <param name="n">A positive 64-bit integer number </param>
        /// <returns></returns>
        public static string Create(ulong n) 
        {
            // Check if the number is positive
            if (n > 0)
            {
                // Use StringBuilder to create the result string
                StringBuilder Result = new StringBuilder(string.Empty);
                // Add data to the result string
                for (ulong i = 1; i <= n; i++) Result.Append(i);
                // Return the result
                return Result.ToString();
            }
            else 
            {
                throw new ArgumentException("The number (n) must be more than zero.","n");
            }
        }
    }
}
