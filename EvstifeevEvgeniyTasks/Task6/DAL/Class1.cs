using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Task6.Entities;

namespace DAL
{
    public class Class1
    {
        private List<User> _userList = new List<User>();
        private string _ReportFileName = Environment.CurrentDirectory+"\\.json";
        public void Create(User user)
        {
            _userList.Add(user);
            
            //JsonConvert.SerializeObject(_userList);
        }
        public void Remove(User user)
        {
            _userList.Remove(user);
        }
        public void ShowAll()
        {
            foreach (var item in _userList) 
            {
                Console.WriteLine(item);
            }
        }
    }
}
