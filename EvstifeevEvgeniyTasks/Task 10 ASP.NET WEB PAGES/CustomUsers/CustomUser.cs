using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CustomUsers
{
    public class CustomUser
    {
        private string _name = string.Empty;
        private List<string> _roles = new List<string>();
        private string _password = string.Empty;

        public List<string> Roles { get => _roles; private set => _roles = value; }
        public string Password { get => _password; private set => _password = value; }

        public string Name { get => _name; private set => _name = value; }

        [JsonConstructor]
        public CustomUser(string name, string password, IEnumerable<string> roles)
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
            if (password == null)
            {
                throw new ArgumentNullException("password", "The password can not be null.");
            }
            if (password.Length < 1)
            {
                throw new ArgumentException("The password can not be empty.", "password");
            }
            // Set the values.
            this.Name = name;
            this.Password = password;
            if (roles != null && roles.Count() != 0)
            {
                this.Roles = roles.ToList();
            }
        }

        public void ChangeAdministrativeRole(string administrativeRoleName)
        {
            if (Roles.Contains(administrativeRoleName))
            {
                Roles.Remove(administrativeRoleName);
            }
            else
            {
                Roles.Add(administrativeRoleName);
            }
        }
    }
}
