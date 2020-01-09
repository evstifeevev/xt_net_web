using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6.Entities;
using Task6.Interfaces;

namespace Task6.BLL
{
    public class AwardLogic : IAwardLogicInterface
    {
        private readonly IAwardDaoInterface _awardDao;
        public AwardLogic(IAwardDaoInterface awardDao)
        {
            this._awardDao = awardDao;
        }
        public Award Add(Award award)
        {
            return _awardDao.Add(award);
        }
        public void Remove(int id)
        {
            _awardDao.Remove(id);
        }
        public Award GetById(int id)
        {
            return _awardDao.GetById(id);
        }

        public void AddUsers(int awardId, int[] userIds) 
        {
            _awardDao.AddUsers(awardId, userIds);
        }

        public void RemoveUsers(int awardId, int[] userIds)
        {
            _awardDao.RemoveUsers(awardId, userIds);
        }

        public IEnumerable<Award> GetAll()
        {
            return _awardDao.GetAll();
        }
    }
}
