using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    public class Task2_3User
    {
        public static void ConsoleInterface()
        {
            // Declaring an object of type User with specified birth date, name and last name.
            User user = new User(new DateTime(1999,1,1),"John","James");
            // Printing user's fields and properties.
            Console.WriteLine("User's name: "+user.Name+Environment.NewLine+
                "User's lastname: " + user.LastName+Environment.NewLine+
                "User's patrinimyc name:" + user.PatronimycName);
            Console.WriteLine("User's birthDate: " + user.BirthDate);
            Console.WriteLine("Age of user is "+user.Age+" year(s)");
        }
        /// <summary>
        /// Describes user with a specified name, lastname, firstname and birthdate. Allows to calculate user age. 
        /// </summary>
        public class User
        {
            /// <summary>
            /// User's name/last name/patronimyc name.
            /// </summary>
            public readonly string Name, LastName, PatronimycName;
            /// <summary>
            /// User's birth date.
            /// </summary>
            public readonly DateTime BirthDate;
            /// <summary>
            /// User's age.
            /// </summary>
            public int Age
            { 
                get { 
                    return new DateTime(DateTime.Now.Ticks - BirthDate.Ticks).Year; 
                }
            }
            protected User() { 
                
            }
            /// <summary>
            /// Creates new user with specified birthdate, name, last name and patronimyc name.
            /// </summary>
            /// <param name="birthDate">Birth date.</param>
            /// <param name="param">Name, last name, patronimyc name (not necessary).</param>
            public User(DateTime birthDate, params string[] names)
            {
                // Checking if at least name and the last name are defined.
                if (names == null || names.Length < 2)
                    throw new ArgumentException("The Name and the LastName must be defined.","Name, LastName");
                // Checking if every name is not empty.
                foreach (var s in names)
                    if(s==null || string.IsNullOrWhiteSpace(s))
                        throw new ArgumentException("The name cannot be empty or consist only from white space.", s);
                // Checking if birth date is defined.
                if(birthDate==null)
                    throw new ArgumentNullException("BirthDate", "Date must not be null.");
                // Checking if birth date is correct.
                if(birthDate.Date<new DateTime(1850,1,1))
                    throw new ArgumentException($"{birthDate} is to small to be correct user birth date.", "DateTime");
                // Assigning all parameters.
                BirthDate = birthDate;
                Name = names[0];LastName = names[1]; 
                if(names.Length>2)
                    PatronimycName = names[2];
            }
        }
    }
}
