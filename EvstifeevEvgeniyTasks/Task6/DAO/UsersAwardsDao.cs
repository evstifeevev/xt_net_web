using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6.Entities;
using System.IO;
using Newtonsoft.Json;

namespace Task6.DAL
{
    /// <summary>
    /// Defines methods to interact with the awarded users.
    /// </summary>
    internal class UsersAwardsDao
    {
        /// <summary>
        /// Contains pairs of user's id and award's id.
        /// </summary>
        private static List<UserAwardPair> _pairOfIds = new List<UserAwardPair>();

        /// <summary>
        /// Full path to the file of the id pairs.
        /// </summary>
        private static readonly string _usersAwardsFileName = Environment.CurrentDirectory + "\\UsersAwards.json";

        /// <summary>
        /// Initializes fiels. 
        /// </summary>
        static UsersAwardsDao() 
        {
            if (File.Exists(_usersAwardsFileName))
            {
                // Read from file.
                string temp = string.Empty;

                using (var sr = new StreamReader(_usersAwardsFileName))
                {
                    temp = sr.ReadToEnd();
                }
                _pairOfIds = JsonConvert.DeserializeObject<List<UserAwardPair>>(temp);
                if (_pairOfIds == null)
                {
                    // Create empty collection.
                    _pairOfIds = new List<UserAwardPair>();
                }
                else
                {
                    using (var sw = new StreamWriter(_usersAwardsFileName))
                    {
                        sw.WriteLine(JsonConvert.SerializeObject(_pairOfIds));
                    }
                    // Get rid of users or awards that are not contained in UserDao._users or AwardDao._awards.
                    for (int i=0;i<_pairOfIds.Count;i++)
                    {
                        if (!UserDao._users.ContainsKey(_pairOfIds[i].UserId)
                            || !AwardDao._awards.ContainsKey(_pairOfIds[i].AwardId))
                        {
                            _pairOfIds.Remove(_pairOfIds[i]);
                            i--;
                        }
                    }
                }
            }
            else
            {
                // Create empty collection.
                _pairOfIds = new List<UserAwardPair>();
            }
        }

        /// <summary>
        /// Add pair of ids to the collection.
        /// </summary>
        /// <param name="userId"> User's id. </param>
        /// <param name="awardId"> Award's id. </param>
        /// <returns> The operation result. </returns>
        internal static bool Add(int userId, int awardId) 
        {
            // Check if the collection does not contain the pair and specified user and award exist.
            if (!_pairOfIds.Any(x=>x.AwardId==awardId && x.UserId==userId)
                && UserDao._users.ContainsKey(userId)
                && AwardDao._awards.ContainsKey(awardId)) 
            { 
                // Add the pair.
                _pairOfIds.Add(new UserAwardPair(userId, awardId));
                // Add the award to the user.
                UserDao._users[userId].Awards.Add(AwardDao._awards[awardId]);
                // Export the collection to the file.
                ExportListToFile();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Removes pair of ids from the collection.
        /// </summary>
        /// <param name="userId"> User's id. </param>
        /// <param name="awardId"> Award's id. </param>
        /// <returns> The operation result. </returns>
        internal static bool Remove(int userId, int awardId)
        {
            // Check if the collection does not contain the pair and specified user and award exist.
            if (_pairOfIds.Any(x => x.AwardId == awardId && x.UserId == userId)
                && UserDao._users.ContainsKey(userId)
                && AwardDao._awards.ContainsKey(awardId))
            {
                // Remove the pair.
                _pairOfIds.RemoveAll(x=>x.AwardId==awardId && x.UserId == userId);
                // Remove the award.
                UserDao._users[userId].Awards.Remove(UserDao._users[userId].Awards.FirstOrDefault(x=>x.Id==awardId));
                // Export the collection to the file.
                ExportListToFile();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Takes user's id and returns all its rewards.
        /// </summary>
        /// <param name="userId"> The user's id. </param>
        /// <returns> Enumerable of all user's awards. </returns>
        internal static IEnumerable<int> GetByUserId(int userId)
        {
            return _pairOfIds.Where(x => x.UserId == userId).Select(x => x.AwardId);
        }

        /// <summary>
        /// Takes award's id and return all users which contain it.
        /// </summary>
        /// <param name="awardId"> The award's id. </param>
        /// <returns> Enumerable of all users with the award. </returns>
        internal static IEnumerable<int> GetByAwardId(int awardId)
        {
            return _pairOfIds.Where(x => x.AwardId == awardId).Select(x => x.UserId);
        }
        
        /// <summary>
        /// Removes all pairs with the user's id.
        /// </summary>
        /// <param name="userId"> The user's id. </param>
        internal static void RemoveByUserId(int userId)
        {
            _pairOfIds.RemoveAll(x => x.UserId == userId);
        }

        /// <summary>
        /// Removes all pairs with the award's id.
        /// </summary>
        /// <param name="awardId"> The award's id. </param>
        internal static void RemoveByAwardId(int awardId)
        {
            _pairOfIds.RemoveAll(x => x.AwardId == awardId);
        }

        /// <summary>
        /// Exports the collection of ids to the file.
        /// </summary>
        private static void ExportListToFile()
        {
            using (var sw = new StreamWriter(_usersAwardsFileName))
            {
                sw.WriteLine(JsonConvert.SerializeObject(_pairOfIds));
            }
        }
    }
}
