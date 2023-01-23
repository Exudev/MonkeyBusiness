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
            while (true)
            {
                int count = 0;
                Console.Clear();
                Console.WriteLine("You're currenty in Account #{0}", account.Id);
                Console.WriteLine("Current balance: ${0}DOP (${1}USD)\n", account.Balance, handler.Converter.ConvertCurrency(account.Balance, true));
                if (user.Account.Count > 5)
                {
                    count = account.Transactions.Count - 5;
                }
                Console.WriteLine("Last 5 Transactions: ");
                for (int i = account.Transactions.Count; i > count; i--)
                {
                    Console.WriteLine("{0}: {1} {2}${3}DOP (${4}USD), {5}", account.Transactions[i].Id, account.Transactions[i].Description,
                        account.Transactions[i].GetType(), account.Transactions[i].Amount,
                        handler.Converter.ConvertCurrency(account.Transactions[i].Amount, true), account.Transactions[i].Date);
                }
                Console.WriteLine("\nWhat do you want to do?");
                int decision = ChoiceMenu();
                switch (decision)
                {
                    case 1:
                        NewTransaction(handler, account);
                        break;
                    case 2:
                        //ShowTransaction(handler, account);
                        break;
                    case 3:
                        handler.GoToUser(user);
                        break;
                    default:
                        break;
                }
            }
        }
        public int ChoiceMenu()
        {
            Console.WriteLine("(1) Register a new transaction");
            Console.WriteLine("(2) Examine all transactions");
            Console.WriteLine("(3) Exit");
            try
            {
                int decision = int.Parse(Console.ReadLine());
                if (decision is > 0 and < 4)
                {
                    return decision;
                }
                else
                {
                    throw new Exception("Number is out of bounds");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Please select a valid option");
                Thread.Sleep(1000);
            }
            return 0;
        }
      /*  public void ShowTransaction(AccountHandler handler, Account account) 
        { 
        } */
        public void NewTransaction(AccountHandler handler, Account account)
        {
        }
        public decimal IntoDollars(decimal dop) { return (dop * 57); }
    }
}
