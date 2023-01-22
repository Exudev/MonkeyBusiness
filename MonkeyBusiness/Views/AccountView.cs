using MonkeyBusiness.Handler;
using MonkeyBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyBusiness.Views
{
    public class AccountView
    {
        public void ShowAccountView(AccountHandler handler, User user, Account account)
        {
            Console.WriteLine("Has entrado a la cuenta #{0} del id {1}", account.Id, account.UserId);
            Console.ReadLine();
        }
    }
}
