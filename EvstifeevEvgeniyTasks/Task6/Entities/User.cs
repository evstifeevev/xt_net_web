using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace Task6.Entities
{
    /// <summary>
    /// Element representing user.
    /// </summary>
    public class User
    {
        #region User fiels
        /// <summary>
        /// User's id - unique number
        /// </summary>
        public int Id = 0;
        
        /// <summary>
        /// User's name.
        /// </summary>
        //public readonly string Name = string.Empty;
        
        /// <summary>
        /// User's date of birth.
        /// </summary>
        //public readonly DateTime DateOfBirth = default;
        #endregion

        #region User constructor
        /// <summary>
        /// Create new instance of class User.
        /// </summary>
        /// <param name="name"> Name. </param>
        /// <param name="dateOfBirth"> Date of birth. </param>
        [JsonConstructor]
        public User(string name, DateTime dateOfBirth, string imageLink="")
        {
            // Check data for correctness.
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
            // Set the values.
            this.Name = name;
            this.DateOfBirth = dateOfBirth;
            this.ImageLink = imageLink;
            this.Awards = new List<Award>();
        }
        #endregion

        #region User public methods
        /// <summary>
        /// User's age.
        /// </summary>
        [JsonIgnore]
        public DateTime Age
        {
            get => new DateTime(DateTime.Now.Ticks - DateOfBirth.Ticks);
        }

      //  [JsonIgnore]
        public string ImageLink
        {
            get => _imageLink;
            private set { _imageLink = value; }
        }

    //    [JsonIgnore]
        public DateTime DateOfBirth
        {
            get => _dateOfBirth;
            private set { _dateOfBirth = value; }
        }

     //   [JsonIgnore]
        public string Name{
            get=>_name;
            private set { _name = value; }
        }

        public void ChangeImageLink(string newImageLink)
        {
            ImageLink = newImageLink;
        }

        public void ChangeName(string newName) {
            Name = newName;
        }
    
        public void ChangeDateOfBirth(DateTime newDateOfBirth)
        {
            DateOfBirth = newDateOfBirth;
        }

        /// <summary>
        /// Collection of user's awards.
        /// </summary>
        [JsonIgnore]
        public virtual ICollection<Award> Awards { get; set; }

        /// <summary>
        /// Cast this object to string.
        /// </summary>
        /// <returns> User's id, name, date of birth, age and list of awards. </returns>
        public override string ToString()
        {
            // Find all user's awards.
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var item in Awards) 
            {
                stringBuilder.Append(item.Title + "\n");
            }
            return $"Id:{Id}, name:{Name},\n date of birth:{DateOfBirth.ToShortDateString()},\n age:{Age.Year},\n awards: {stringBuilder}. ";
        }

        /// <summary>
        /// Compares current instance of class User with another.
        /// </summary>
        /// <param name="user"> Another instance of class User. </param>
        /// <returns> The result of comparison. </returns>
        public bool Equals(User user)
        {
            return (this.Id == user.Id && this.Name == user.Name && this.DateOfBirth == user.DateOfBirth);
        }
        #endregion

        private string _name = string.Empty;
        private DateTime _dateOfBirth = default;
        private string _imageLink = string.Empty;
    }
}
