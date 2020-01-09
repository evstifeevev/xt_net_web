using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6.Interfaces;
using Task6.DAL;
using Task6.BLL;

namespace Task6.InversionOfControl
{
	// Singlton pattern realization. There is only one instance of Dao classes and Logic classes.
    public static class DependencyResolver
    {
		private static IUserDaoInterface _userDao;

		public static IUserDaoInterface UserDao
		{
			get { return _userDao?? (_userDao = new UserDao()); }
		}

		private static IUserLogicInterface _userLogic;

		public static IUserLogicInterface UserLogic
		{
			get { return _userLogic ?? (_userLogic = new UserLogic(UserDao)); }
		}

		private static IAwardDaoInterface _awardDao;

		public static IAwardDaoInterface AwardDao
		{
			get { return _awardDao ?? (_awardDao = new AwardDao()); }
		}

		private static IAwardLogicInterface _awardLogic;

		public static IAwardLogicInterface AwardLogic
		{
			get { return _awardLogic ?? (_awardLogic = new AwardLogic(AwardDao)); }
		}
	}
}
