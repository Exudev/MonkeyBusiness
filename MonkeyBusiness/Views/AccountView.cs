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
                Console.Clear();
                Console.WriteLine("You're currenty in Account #{0}", account.Id);
                Console.WriteLine("Current balance: ${0}DOP (${1}USD)\n", account.Balance, IntoDollars(account.Balance));
                Console.WriteLine("Last 5 Transactions: ");
                for (int i = user.Account.Count; i > 0; i--)
                {
                    Console.WriteLine("{0}: {1} {2}${3}DOP (${4}USD), {5}", account.Transactions[i].Id, account.Transactions[i].Description,
                        account.Transactions[i].GetType(), account.Transactions[i].Amount, IntoDollars(account.Transactions[i].Amount), account.Transactions[i].Date);
                }
                Console.WriteLine("\nWhat do you want to do?");
                int decision = ChoiceMenu();
                switch (decision)
                {
                    case 1:
                        NewTransaction(handler, account);
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
        public void NewTransaction(AccountHandler handler, Account account)
        {
        }
        public decimal IntoDollars(decimal dop) { return (dop * 57); }
    }
}
