using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace CustomUsers
{
    public static class CustomUsers
    {
        private static readonly Dictionary<string, CustomUser> _customUsers = new Dictionary<string, CustomUser>();

        private static readonly string _fileCustomUsersPath = Environment.CurrentDirectory + "\\CustomUsers.json";

        static CustomUsers(){
            if (File.Exists(_fileCustomUsersPath))
            {
                string temp = string.Empty;

                using (var sr = new StreamReader(_fileCustomUsersPath))
                {
                    temp = sr.ReadToEnd();
                }
                _customUsers = JsonConvert.DeserializeObject<Dictionary<string, CustomUser>>(temp);
                if (_customUsers == null)
                {
                    _customUsers = new Dictionary<string, CustomUser>();
                }
                else
                {
                    using (var sw = new StreamWriter(_fileCustomUsersPath))
                    {
                        sw.WriteLine(JsonConvert.SerializeObject(_customUsers));
                    }
                }
            }
            else
            {
                // Create new dictionary of users.
                _customUsers = new Dictionary<string, CustomUser>();
            }
            if (!_customUsers.ContainsKey("admin"))
            {
                _customUsers.Add("admin", new CustomUser("admin","paSSSword".GetHashCode().ToString(),new string[] { "admin"}));
                ExportToFile();
            }
        }

        public static Dictionary<string, CustomUser> Users { get=>_customUsers; }

        public static void AddUser(string userName, string password, string[] roles)
        {
            if (userName!=null && !_customUsers.ContainsKey(userName))
            {
                _customUsers.Add(userName, new CustomUser(userName, password, roles));
                ExportToFile();
            }
        }

        public static void AddRole(string userName, string role) {
            if (_customUsers.ContainsKey(userName) && !_customUsers[userName].Roles.Contains(role))
            {
                _customUsers[userName].Roles.Add(role);
                ExportToFile();
            }
        }

        public static bool IsUserInRole(string userName, string roleName) {
            return (_customUsers.ContainsKey(userName) && _customUsers[userName].Roles.Contains(roleName));
        }

        public static string[] GetUserRoles(string userName)
        {
            if (_customUsers.ContainsKey(userName) && _customUsers[userName].Roles!=null)
            {
                return _customUsers[userName].Roles.ToArray();
            }
            return new string[] { "user" };
        }

        public static void ChangeAdministrativeRole(string username, string administrativeRoleName)
        {
            if (_customUsers.ContainsKey(username))
            {
                _customUsers[username].ChangeAdministrativeRole(administrativeRoleName);
                ExportToFile();
            }
        }

        private static void ExportToFile()
        {
            using (var sw = new StreamWriter(_fileCustomUsersPath))
            {
                sw.WriteLine(JsonConvert.SerializeObject(_customUsers));
            }
        }
    }
}
