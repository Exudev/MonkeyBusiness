using MonkeyBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyBusiness.Handler
{
    public class AccountHandler
    {
        public string AccountPath { get; set; }
        public string CategoriesPath { get; set; }
        public ActionHandler actionHandler { get; set; }
        public List<User> appUsers{ get; set; }
        public AccountHandler(string accountPath, string categoriesPath)
        {
            this.AccountPath = accountPath;
            this.CategoriesPath = categoriesPath;
        }

       public int GetTransactionID(Account currentAccount)
       {
            int result = currentAccount.Transactions.Count;
            return result + 1;
       }
    } 
}
