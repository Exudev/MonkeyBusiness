using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyBusiness.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Password { get; set; }
        public List<Account> Account { get; set; }
        public User() { }
        public User(int id, string username, string firstName, string lastName, string password)
        {
            this.Id = id;
            this.Username = username;
            this.Name = firstName;
            this.Lastname = lastName;
            this.Password = password;
            Account = new List<Account>();
        }
    }
}
