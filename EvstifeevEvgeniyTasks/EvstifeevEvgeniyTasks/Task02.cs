using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvstifeevEvgeniyTasks
{
    class Task02
    {
        public static bool IsPrime(uint n)
        {//Simple primality test of number n
            if (n < 2) return false;
            //All number that should be checked are in range of from 2 to Sqrt(n)
            double SqrtN = Math.Sqrt(Convert.ToDouble(n));
            for (uint i = 2; i <= SqrtN; i++) {
                if (n % i == 0) return false;//n is not prime 
            }
            return true;//The number n is a prime number if all test have been passed
        }
        public static bool IsPrimeFermat(int n, int TestsCount)//Fermat primality test of number n
            //This method has a serious disadvantage - some of not prime numbers passes this test
        {
            if (n < 2) return false;
            if (n < 4) return true;
            Random Rand = new Random();  
            double NumPassed = 0;//Number of passed tests
            double PassingValue = 1.0 / (TestsCount/10.0);
            long temp, result;
            uint MinimalSteps = 10000;//Minimal number of tests
            for (uint i = 0; i < TestsCount; i++)
            {
                temp = Rand.Next(2, n-2);//Random value in range from 2 to n-2
                //Calculation of (temp ^ n - 1) % n
                result = temp;
                for (int power = 1; power < n - 1; power++) result = (result*temp)%n;
                if (result != 1) return false;  //Quit if test fails
                else
                    NumPassed++;
                //1 - summ/i is a probability of the number n being prime
                //Check after minimal number of tests to save time
                if ((i > MinimalSteps) && (1- NumPassed / i < PassingValue)) return true;
            }
            return true;//The number n is a prime number if all test have been passed
        }
    }
}
