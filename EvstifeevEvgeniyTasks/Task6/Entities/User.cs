using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Task6.Entities
{
    public class User
    {
        public readonly int Id = 0;
        public readonly string Name = string.Empty;
        public readonly DateTime DateOfBirth = default;
        public User(int id, string name, DateTime dateOfBirth) 
        {
            if (name == null) 
            {
                throw new ArgumentNullException("name", "The name can not be null.");
            }
            if (name.Length < 1)
            {
                throw new ArgumentException("The name can not be empty.", "name");
            }
            if (!new Regex(@"[\w]").IsMatch(name))
            {
                throw new ArgumentException("The name must contain only word characters.", "name");
            }
            if (dateOfBirth > DateTime.Now) 
            {
                throw new ArgumentException("Date of birth can not be greater than the current date.", "dateOfBirth");
            }
            this.Id = id;
            this.Name = name;
            this.DateOfBirth = dateOfBirth;
        }
        public DateTime Age { get => new DateTime(DateOfBirth.Ticks - DateTime.Now.Ticks); }
    }
}
