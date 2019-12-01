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
            Employee employee = new Employee(11, "", new DateTime(1999, 1, 1), "John", "James");
            //User user = new User(new DateTime(1999, 1, 1), "John", "James");
            //Console.WriteLine("User's name: " + user.Name + Environment.NewLine +
            //    "User's lastname: " + user.LastName + Environment.NewLine +
            //    "User's patrinimyc name:" + user.PatronimycName);
            //Console.WriteLine("User's birthDate: " + user.BirthDate);
            //Console.WriteLine("Age of user is " + user.Age + " year(s)");
        }
         class Employee : Task2_3User.User
        {
            public int LengthOfService { get; }
            public string OfficialСapacity { get; }
            public Employee(int lengthOfService, string officialCapacity , DateTime birthdate, params string[] names) 
            : base(birthdate, names){
                if (LengthOfService < 0)
                    throw new ArgumentException("lengthOfService must not be negative.", "lengthOfService");
                if (officialCapacity == null)
                    throw new ArgumentException("officialCapacity must not be empty", "officialCapacity");
                LengthOfService = lengthOfService;
                OfficialСapacity = officialCapacity;
            }
            public Employee(Task2_3User.User user, int lengthOfService, string officialCapacity) :
                base(user.BirthDate,new string[]{ user.Name, user.LastName, user.PatronimycName}){
                if (LengthOfService < 0)
                    throw new ArgumentException("lengthOfService must not be negative.", "lengthOfService");
                if (officialCapacity == null)
                    throw new ArgumentException("officialCapacity must not be empty", "officialCapacity");
                LengthOfService = lengthOfService;
                OfficialСapacity = officialCapacity;
            }
        }
    }
}
