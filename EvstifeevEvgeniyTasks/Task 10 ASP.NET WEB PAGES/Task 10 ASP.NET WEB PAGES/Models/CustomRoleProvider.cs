using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using CustomUsers;

namespace Task_10_ASP.NET_WEB_PAGES.Models
{
    public class CustomRoleProvider : RoleProvider
    {
        public override bool IsUserInRole(string userName, string roleName)
        {
            return (CustomUsers.CustomUsers.IsUserInRole(userName, roleName));
            //if(CustomUsers.CustomUsers.)
            //return (username == "admin" && roleName == "admin") ||
            //    (username =="user" && roleName =="user");
        }

        public override string[] GetRolesForUser(string username)
        {
            return CustomUsers.CustomUsers.GetUserRoles(username);
            //if (username == "admin") return new string[] { "admin" };
            //else if (username == "user") return new string[] { "user" };
            //else return new string[] { };
        }

        #region NOT_IMPLEMENTED
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }



        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}