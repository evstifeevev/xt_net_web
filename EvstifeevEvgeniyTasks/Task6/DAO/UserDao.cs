using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Task6.Entities;
using Task6.Interfaces;
using System.IO;

namespace Task6.DAL
{
    /// <summary>
    /// Contains methods to manipulate collection of class User instances at data access layer (DAL).
    /// </summary>
    public class UserDao : IUserDaoInterface
    {
        #region UserDao fields
        internal static readonly Dictionary<int, User> _users = new Dictionary<int, User>();

        private static readonly string _usersFileName = Environment.CurrentDirectory + "\\Users.json";
        #endregion

        #region UserDao constructor
        /// <summary>
        /// Initializes the dictionary of users.
        /// </summary>
        static UserDao()
        {
            // Check if containing users file exists.
            if (File.Exists(_usersFileName))
            {
                string temp = string.Empty;

                using (var sr = new StreamReader(_usersFileName))
                {
                    temp = sr.ReadToEnd();
                }
                _users = JsonConvert.DeserializeObject<Dictionary<int, User>>(temp);
                if (_users == null)
                {
                    _users = new Dictionary<int, User>();
                }
                else
                {
                    using (var sw = new StreamWriter(_usersFileName))
                    {
                        sw.WriteLine(JsonConvert.SerializeObject(_users));
                    }
                }
            }
            else
            {
                // Create new dictionary of users.
                _users = new Dictionary<int, User>();
            }
            // Add all users awards.
            foreach (var user in _users.Values)
            {
                foreach (int awardId in UsersAwardsDao.GetByUserId(user.Id))
                {
                    user.Awards.Add(AwardDao._awards[awardId]);
                }
            }
        }
        #endregion

        #region UserDao public methods
        /// <summary>
        /// Adds user and returns reference it. If the user already exists
        /// return the reference to the existing user instead.
        /// </summary>
        /// <param name="user"> The user. </param>
        /// <returns> Added User. </returns>
        public User Add(User user)
        {
            // Check if the collection contains the user.
            if (!_users.Values.Any(x => x.Id == user.Id && x.Name==user.Name && x.DateOfBirth==user.DateOfBirth))
            {
                int lastId = _users.Count == 0
                    ? 0
                    : _users.Keys.Max();

                user.Id = lastId + 1;

                _users.Add(user.Id, user);

                foreach (int awardId in UsersAwardsDao.GetByUserId(user.Id))
                {
                    user.Awards.Add(AwardDao._awards[awardId]);
                }

                ExportListToFile();

                return user;
            }
            else 
            {
                return _users.Values.FirstOrDefault(x => x.Equals(user));
            }
        }

        public void ChangeName(int id, string newName) {
            _users[id].ChangeName(newName);
            ExportListToFile();
        }

        public void ChangeDateOfBirth(int id, DateTime newDateOfBirth)
        {
            _users[id].ChangeDateOfBirth(newDateOfBirth);
            ExportListToFile();
        }

        public void ChangeImageLink(int id, string newImageLink)
        {
            _users[id].ChangeImageLink(newImageLink);
            ExportListToFile();
        }

        /// <summary>
        /// Removes the user by the id. 
        /// </summary>
        /// <param name="id"> The user's id. </param>
        public void Remove(int id)
        {
            _users.Remove(id);
            UsersAwardsDao.RemoveByUserId(id);
            ExportListToFile();
        }

        /// <summary>
        /// Returns Enumerable of users.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<User> GetAll()
        {
            return _users.Values;
        }

        /// <summary>
        /// Returns the user by the id.
        /// </summary>
        /// <param name="id"> The user's id. </param>
        /// <returns></returns>
        public User GetById(int id)
        {
            if (_users.TryGetValue(id, out User user))
            {
                return user;
            }
            return null;
        }

        /// <summary>
        /// Adds the awards to the user.
        /// </summary>
        /// <param name="userId"> The user's id. </param>
        /// <param name="awardIds"> 32-bit int array of award ids. </param>
        public void AddAwards(int userId, int[] awardIds)
        {
            for (int i = 0; i < awardIds.Length; i++)
            {
                if (UsersAwardsDao.Add(userId, awardIds[i])) 
                { 
                }
            }       
        }

        /// <summary>
        /// Removes the awards from the user.
        /// </summary>
        /// <param name="userId"> The user's id. </param>
        /// <param name="awardIds"> 32-bit int array of award ids. </param>
        public void RemoveAwards(int userId, int[] awardIds)
        {
            for (int i = 0; i < awardIds.Length; i++)
            {
                if (UsersAwardsDao.Remove(userId, awardIds[i]))
                {
                    _users[userId].Awards.Remove(AwardDao._awards[awardIds[i]]);
                }
            }
        }

        public string GetImageLink(int id) {
            if (_users.TryGetValue(id, out User user))
            {
                return user.ImageLink;
            }
            return "";
        }
        #endregion

        /// <summary>
        /// Removes the award from the user. 
        /// </summary>
        /// <param name="awardId"> The award's id. </param>
        internal static void RemoveInternal(int awardId)
        {
            foreach (var user in _users.Values) 
            {
                user.Awards.Remove(user.Awards.FirstOrDefault(x=>x.Id==awardId));
            }
        }

        #region UserDao private methods
        /// <summary>
        /// Exports users to the file.
        /// </summary>
        private void ExportListToFile()
        {
            using (var sw = new StreamWriter(_usersFileName))
            {
                sw.WriteLine(JsonConvert.SerializeObject(_users));
            }
        }
        #endregion
    }
}
