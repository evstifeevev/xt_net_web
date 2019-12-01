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
            User user = new User(new DateTime(1999,1,1),"John","James");
            Console.WriteLine("User's name: "+user.Name+Environment.NewLine+
                "User's lastname: " + user.LastName+Environment.NewLine+
                "User's patrinimyc name:" + user.PatronimycName);
            Console.WriteLine("User's birthDate: " + user.BirthDate);
            Console.WriteLine("Age of user is "+user.Age+" year(s)");
        }
        /// <summary>
        /// Creates user with a corresponding name, lastname, firstname and birthdate
        /// </summary>
        public class User
        {
            public readonly string Name, LastName, PatronimycName;
            public readonly DateTime BirthDate;
            public int Age
            { 
                get { 
                    return new DateTime(DateTime.Now.Ticks - BirthDate.Ticks).Year; 
                }
            }
            protected User() { 
                
            }
            /// <summary>
            /// Creates new triangle with 
            /// </summary>
            /// <param name="param"></param>
            public User(DateTime birthDate, params string[] names)
            {
                if (names == null || names.Length < 2)
                    throw new ArgumentException("The Name and the LastName must be defined.","Name, LastName");
                foreach (var s in names)
                    if(s==null || string.IsNullOrWhiteSpace(s))
                        throw new ArgumentException("The name cannot be empty or consist only from white space.", s);
                if(birthDate==null)
                    throw new ArgumentNullException("BirthDate", "Date must not be null.");
                if(birthDate.Date<new DateTime(1850,1,1))
                    throw new ArgumentException($"{birthDate} is to small to be correct user birth date.", "DateTime");
                BirthDate = birthDate;
                Name = names[0];LastName = names[1]; 
                if(names.Length>2)
                    PatronimycName = names[2];
            }
        }
    }
}
