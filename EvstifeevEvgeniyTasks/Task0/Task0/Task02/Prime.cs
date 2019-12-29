using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task0.Task02
{
    internal class Prime
    {
        // Simple primality test of number n
        internal static bool IsPrime(uint n)
        {
            if (n < 2) return false;
            // All number that should be checked are in range of from 2 to Sqrt(n)
            double SqrtN = Math.Sqrt(Convert.ToDouble(n));
            for (uint i = 2; i <= SqrtN; i++)
            {
                if (n % i == 0)
                {
                    // n is not prime 
                    return false;
                }
            }
            // The number n is a prime number if all test have been passed
            return true;
        }
        // Fermat primality test of number n
        internal static bool IsPrimeFermat(int n, int TestsCount)
        // This method has a serious disadvantage - some of not prime numbers passes this test
        {
            if (n < 2) return false;
            if (n < 4) return true;
            Random Rand = new Random();

            // Number of passed tests
            double NumPassed = 0;
            double PassingValue = 1.0 / (TestsCount / 10.0);
            long temp, result;

            // Minimal number of tests
            uint MinimalSteps = 10000;
            for (uint i = 0; i < TestsCount; i++)
            {
                // Random value in range from 2 to n-2
                temp = Rand.Next(2, n - 2);
                // Calculation of (temp ^ n - 1) % n
                result = temp;
                for (int power = 1; power < n - 1; power++) result = (result * temp) % n;
                if (result != 1)
                {
                    // Quit if test fails
                    return false;
                }
                else
                    NumPassed++;
                // 1 - summ/i is a probability of the number n being prime
                // Check after minimal number of tests to save time
                if ((i > MinimalSteps) && (1 - NumPassed / i < PassingValue))
                { 
                    return true;
                }
            }
            // The number n is a prime number if all test have been passed
            return true;
        }
    }
}
