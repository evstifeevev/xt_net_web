using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    class Task2_5Employee
    {
        public static void ConsoleInterface()
        {
            //Declaring an object of type Employee with specified length of service, official capacity, birth date, name and last name 
            Employee employee = new Employee(2, "Mayor", new DateTime(1999, 1, 1), "John", "James");
            //Printing employee's parameters
            Console.WriteLine(nameof(employee.BirthDate)+": "+employee.BirthDate.ToShortDateString());
            Console.WriteLine(nameof(employee.Age)+ ": " + employee.Age);
            Console.WriteLine(nameof(employee.LastName) + ": " + employee.LastName);
            Console.WriteLine(nameof(employee.LengthOfService) + ": " + employee.LengthOfService);
            Console.WriteLine(nameof(employee.WorkingPosition) + ": " + employee.WorkingPosition);
            Console.WriteLine(nameof(employee.PatronimycName) + ": " + employee.PatronimycName);
        }
         class Employee : Task2_3User.User
        {
            /// <summary>
            /// Length of service
            /// </summary>
            public int LengthOfService { get; }
            /// <summary>
            /// Working position
            /// </summary>
            public string WorkingPosition { get; }
            /// <summary>
            /// Creates an employee with specified length of service, working position, birth date, name,
            /// last name and patronymic name (if the employee has it).
            /// </summary>
            /// <param name="lengthOfService">Length of service</param>
            /// <param name="workingPosition">Working position</param>
            /// <param name="birthdate">Birth date</param>
            /// <param name="names">Name, last name, patronimyc name (not  necessary).</param>
            public Employee(int lengthOfService, string workingPosition , DateTime birthdate, params string[] names) 
            : base(birthdate, names){
                //Checking if length of service is correct
                if (LengthOfService < 0)
                    throw new ArgumentException("Length of service must not be negative.", "lengthOfService");
                //Checking if working position is not empty
                if (workingPosition == null || string.IsNullOrWhiteSpace(workingPosition))
                    throw new ArgumentException("Official capacity must not be empty", "workingPosition");
                //Assigning length of service and working position 
                LengthOfService = lengthOfService;
                WorkingPosition = workingPosition;
            }
            /// <summary>
            /// Creates an employee from user with specified length of service and working position.
            /// </summary>
            /// <param name="user">User</param>
            /// <param name="lengthOfService">Length of service</param>
            /// <param name="workingPosition">Working position</param>
            public Employee(Task2_3User.User user, int lengthOfService, string workingPosition) :
                base(user.BirthDate,new string[]{ user.Name, user.LastName, user.PatronimycName}){
                //Checking if length of service is correct
                if (LengthOfService < 0)
                    throw new ArgumentException("Length of service must not be negative.", "lengthOfService");
                //Checking if working position is not empty
                if (workingPosition == null)
                    throw new ArgumentException("Official capacity must not be empty", "workingPosition");
                //Assigning length of service and working position 
                LengthOfService = lengthOfService;
                WorkingPosition = workingPosition;
            }
        }
    }
}
