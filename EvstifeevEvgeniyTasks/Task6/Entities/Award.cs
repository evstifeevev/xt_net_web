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
    /// Element representing user's award.
    /// </summary>
    public class Award
    {
        #region Award fields
        /// <summary>
        /// Award's id.
        /// </summary>
        public int Id = 0;

        /// <summary>
        /// Award's title.
        /// </summary>
        //public string Title = "";
        #endregion

        #region Award constructor
        /// <summary>
        /// Creates new instance of class Award.
        /// </summary>
        /// <param name="title"> Award's title. </param>
        [JsonConstructor]
        public Award(string title, string imageLink="") 
        {
            // Check the data for correctness.
            if(title == null)
            {
                throw new ArgumentNullException("name", "The name can not be null.");
            }
            
            if (title.Length < 1)
            {
                throw new ArgumentException("The name can not be empty.", "name");
            }

            if (!new Regex(@"[\w]").IsMatch(title))
            {
                throw new ArgumentException("The name must contain only word characters.", "name");
            }

            // Set the values.
            this.Title = title;
            this.ImageLink = imageLink;
            this.Users = new List<User>();
        }
        #endregion

        #region Award public methods
        /// <summary>
        /// Collection of award's users.
        /// </summary>
        [JsonIgnore]
        public ICollection<User> Users { get; set; }

        public string Title
        {
            get => _title;
            private set { _title = value; }
        }

        public string ImageLink
        {
            get => _imageLink;
            private set { _imageLink = value; }
        }

        public void ChangeTitle(string newTitle)
        {
            Title = newTitle;
        }
        public void ChangeImageLink(string newImageLink)
        {
            ImageLink = newImageLink;
        }

        /// <summary>
        /// Cast this object to string.
        /// </summary>
        /// <returns> Award's id and title. </returns>
        public override string ToString()
        {
            return $"Id: {Id}, Title: {Title}. ";
        }
        #endregion

        private string _title = string.Empty;
        private string _imageLink = string.Empty;
    }
}
