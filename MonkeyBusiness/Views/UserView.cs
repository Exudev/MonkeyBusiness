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
            while (true)
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
                        LogInTry(handler, user);
                        break;
                    case 2:
                        CreateAccount(user);
                        break;
                    case 3:
                        DeleteAccount(user);
                        break;
                    case 4:
                        DeleteUser(handler, user);
                        break;
                    case 5:
                        handler.Initialize();
                        break;
                    default:
                        break;
                }
            }
        }
        public int ChoiceMenu()
        {
            Console.WriteLine("(1) Enter an account");
            Console.WriteLine("(2) Create an account");
            Console.WriteLine("(3) Delete an account");
            Console.WriteLine("(4) Delete user");
            Console.WriteLine("(5) Exit");
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
        public void LogInTry(AccountHandler handler, User user)
        {
            try
            {
                Console.WriteLine("Which account do you want to check?");
                string decision = Console.ReadLine();
                if (int.Parse(decision) > user.Account.Count || int.Parse(decision) < 1)
                {
                    throw new Exception("Number is not valid, please select a valid number");
                }
                handler.GoToAccount(user.Account.Where(a => a.Id == int.Parse(decision)).First());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Thread.Sleep(1000);
            }
        }
        public void CreateAccount(User user)
        {
            try
            {
                Console.WriteLine("Create a new account? (Y/N)");
                char decision = Console.ReadLine().ToString().ToLower()[0];
                switch (decision)
                {
                    case 'y':
                        user.Account.Add(new Account(user.Account.Count()+1, user.Id)) ;
                        break;
                    case 'n':
                        throw new Exception("Operation canceled");
                    default:
                        throw new Exception("Please select an available option");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Thread.Sleep(1000);
            }
        }
        public void DeleteAccount(User user)
        {
            try
            {
                Console.WriteLine("Which account do you want to delete? (C) to cancel");
                string decision = Console.ReadLine();
                if (decision.ToLower() == "c")
                {
                    throw new Exception("Operation canceled");
                }
                if (int.Parse(decision) > user.Account.Count || int.Parse(decision) < 1)
                {
                    throw new Exception("Number is not valid, please select a valid number");
                }
                user.Account.Remove(user.Account.Where(a => a.Id == int.Parse(decision)).First());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Thread.Sleep(1000);
            }
        }
        public void DeleteUser(AccountHandler handler, User user)
        {
            try
            {
                Console.WriteLine("Are you sure you want to delete this user? (Y/N)");
                char decision = Console.ReadLine().ToString().ToLower()[0];
                switch (decision)
                {
                    case 'y':
                        handler.appUsers.Remove(user);
                        handler.Initialize();
                        break;
                    case 'n':
                        throw new Exception("Operation canceled");
                        break;
                    default:
                        throw new Exception("Please select an available option");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Thread.Sleep(1000);
            }
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
