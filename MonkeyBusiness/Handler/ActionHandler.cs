using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonkeyBusiness.Models;


namespace MonkeyBusiness.Handler
{
    public class ActionHandler
  {
        AccountHandler handler;
       public Transaction GerenateIncome(Account account, decimal balance)
        {
            account.Balance += balance;
            Transaction transaction = new();
            
            

            return transaction;
        }

        
  }
}

