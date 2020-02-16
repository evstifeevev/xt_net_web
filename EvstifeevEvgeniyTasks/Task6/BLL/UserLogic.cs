using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6.Interfaces;
using Task6.Entities;


namespace Task6.BLL
{
    public class UserLogic : IUserLogicInterface
    {
        private readonly IUserDaoInterface _userDao;
        public UserLogic(IUserDaoInterface userDao)
        {
            this._userDao = userDao;
        }
        public User Add(User user)
        {
            return _userDao.Add(user);
        }
        public void Remove(int id)
        {
            _userDao.Remove(id);
        }
        public IEnumerable<User> GetAll()
        {
            return _userDao.GetAll();
        }

        public void AddAwards(int userId, int[] awardsIds)
        {
            _userDao.AddAwards(userId, awardsIds);
        }
        public void RemoveAwards(int userId, int[] awardsIds)
        {
            _userDao.RemoveAwards(userId, awardsIds);
        }

        public void ChangeName(int id, string newName)
        {
            _userDao.ChangeName(id, newName);
        }

        public void ChangeDateOfBirth(int id, DateTime newDateOfBirth)
        {
            _userDao.ChangeDateOfBirth(id, newDateOfBirth);
        }

        public void ChangeImageLink(int id, string newImageLink)
        {
            _userDao.ChangeImageLink(id, newImageLink);
        }

        public string GetImageLink(int id) {
            return _userDao.GetImageLink(id);
        }

        public User GetById(int id)
        {

            return _userDao.GetById(id);
        }
    }
}
