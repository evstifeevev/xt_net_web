using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6.Entities;
using Task6.Interfaces;
using System.IO;
using Newtonsoft.Json;

namespace Task6.DAL
{
    public class AwardDao : IAwardDaoInterface
    {
        #region AwardDao fields
        internal static readonly Dictionary<int, Award> _awards = new Dictionary<int, Award>();

        private static readonly string _awardsFileName = Environment.CurrentDirectory + "\\Awards.json";

        #endregion

        #region AwardDao constructor
        [JsonConstructor]
        static AwardDao()
        {
            // Check if file containg awards exists
            if (File.Exists(_awardsFileName))
            {
                string temp = string.Empty;

                using (var sr = new StreamReader(_awardsFileName))
                {
                    temp = sr.ReadToEnd();
                }
                _awards = JsonConvert.DeserializeObject<Dictionary<int, Award>>(temp);
                if (_awards == null)
                {
                    _awards = new Dictionary<int, Award>();
                }
                else
                {
                    using (var sw = new StreamWriter(_awardsFileName))
                    {
                        sw.WriteLine(JsonConvert.SerializeObject(_awards));
                    }
                }
            }
            else
            {
                _awards = new Dictionary<int, Award>();
            }
            foreach (var award in _awards.Values)
            {
                foreach (int awardId in UsersAwardsDao.GetByAwardId(award.Id))
                {
                    award.Users.Add(UserDao._users[awardId]);
                }
            }
        }
        #endregion

        #region AwardDao public methods
        public Award Add(Award award)
        {
            if (!_awards.Values.Any(x => x.Title==award.Title))
            {
                int lastId = _awards.Count == 0
                ? 0
                : _awards.Keys.Max();

            award.Id = lastId + 1;

            _awards.Add(award.Id, award);

            foreach (int awardId in UsersAwardsDao.GetByAwardId(award.Id))
            {
                award.Users.Add(UserDao._users[awardId]);
            }

            ExportListToFile();

            return award;
            }
            else
            {
                return _awards.Values.FirstOrDefault(x => x.Title == award.Title);
            }
        }

        public void Remove(int id)
        {
            _awards.Remove(id);
            UsersAwardsDao.RemoveByAwardId(id);
            UserDao.RemoveInternal(id);
            ExportListToFile();
        }

        public IEnumerable<Award> GetAll()
        {
            return _awards.Values;
        }

        public Award GetById(int id)
        {
            if (_awards.TryGetValue(id, out Award award))
            {
                return award;
            }
            return null;
        }

        public void AddUsers(int awardId, int[] userIds)
        {

            for (int i = 0; i < userIds.Length; i++)
            {
                if (UsersAwardsDao.Add(userIds[i], awardId))
                {
                    _awards[awardId].Users.Add(UserDao._users[userIds[i]]);
                }
            }
        }

        public void RemoveUsers(int awardId, int[] userIds)
        {

            for (int i = 0; i < userIds.Length; i++)
            {
                if (UsersAwardsDao.Remove(userIds[i], awardId))
                {
                    _awards[awardId].Users.Remove(UserDao._users[userIds[i]]);
                }
            }

        }
        #endregion

        internal static void RemoveInternal(int userId)
        {
            foreach (var award in _awards.Values)
            {
                award.Users.Remove(award.Users.FirstOrDefault(x => x.Id == userId));
            }
        }

        #region AwardDao private methods
        private void ExportListToFile()
        {
            using (var sw = new StreamWriter(_awardsFileName))
            {
                sw.WriteLine(JsonConvert.SerializeObject(_awards));
            }
        }
        #endregion
    }
}
