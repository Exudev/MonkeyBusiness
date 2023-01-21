using MonkeyBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyBusiness.Views
{
    public class UserView
    {
        public void ShowUserView(User user)
        {
            Console.Clear();
            Console.WriteLine("You arrived here with {0}", user.Username);
            Console.ReadLine();
        }
    }
}
