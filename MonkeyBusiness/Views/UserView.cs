using MonkeyBusiness.Handler;
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
        public void ShowUserView(AccountHandler handler, User user)
        {
            Console.Clear();
            Console.WriteLine("Welcome back, {0}!", user.Name);
            Console.WriteLine("Current balance: ${0}DOP (${1}USD)\n", TotalBalance(user), IntoDollars(TotalBalance(user)));
            Console.WriteLine("Accounts: ");
            for (int i = 0; i < user.Account.Count; i++)
            {
                Console.WriteLine("{0}: ${1}DOP {${2}USD}", user.Account[i].Id, user.Account[i].Balance, IntoDollars(user.Account[i].Balance));
            }
            Console.WriteLine("\nWhat do you want to do?");
            int decision = ChoiceMenu();
            switch (decision)
            {
                case 1:
                    break; 
                case 2:
                    break; 
                case 3:
                    break; 
                case 4:
                    handler.Initialize();
                    break;
                default:
                    break;
            }
        }
        public int ChoiceMenu()
        {
            Console.WriteLine("(1) Enter an account");
            Console.WriteLine("(2) Delete an account");
            Console.WriteLine("(3) Delete user");
            Console.WriteLine("(4) Exit");
            try
            {
                int decision = int.Parse(Console.ReadLine());
                if (decision is > 0 and < 5)
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
        public decimal TotalBalance(User user)
        {
            decimal total = 0;
            for (int i = 0; i < user.Account.Count; i++)
            {
                user.Account[i].Balance += total;
            }
            return total;
        }

        
        public decimal IntoDollars(decimal dop) { return (dop * 57); }
    }
}
