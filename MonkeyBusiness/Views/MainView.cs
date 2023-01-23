using MonkeyBusiness.Handler;
using MonkeyBusiness.Models;
using System;

public class MainView
{
	public void ShowMainView(AccountHandler handler)
	{
		while (true)
		{
			Console.Clear();
			Console.WriteLine("~~~MONKEY BUSINESS~~~\n");
			Console.WriteLine("Accounts in system");
			foreach (var item in handler.appUsers)
			{
				Console.WriteLine("{0}: {1} - Accounts: {2}", item.Id, item.Username, item.Account.Count);
			}
			Console.WriteLine("What do you want to do?");
			int decision = ChoiceMenu();
			switch (decision)
			{
				case 1:
					LogInTry(handler);
					break;
				case 2:
					UserCreationMenu(handler);
					break;
				case 3:
					CategoriesMenu(handler);
					break;
				case 4:
					handler.Exit();
					break;
				default:
					break;
			}
		}
	}
	public int ChoiceMenu()
	{
		Console.WriteLine("(1) Log in");
        Console.WriteLine("(2) Create new account");
		Console.WriteLine("(3) Manage Categories");
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
	public void LogInTry(AccountHandler handler)
	{
		try
		{
            Console.WriteLine("Which user do you want to log into?");
            string decision = Console.ReadLine();
            if (int.Parse(decision) > handler.appUsers.Count || int.Parse(decision) < 1)
    		{
				throw new Exception("Number is not valid, please select a valid number");
            }
			Console.WriteLine("Password: ");
			string pwd = Console.ReadLine();
			if (handler.appUsers.Where(a => a.Id == int.Parse(decision) && a.Password == pwd).ToList().Count > 0)
			{
				handler.GoToUser(handler.appUsers.Where(a => a.Id == int.Parse(decision) && a.Password == pwd).First());
			}
			else
			{
				throw new Exception("Password is incorrect");
			}
        }
		catch (Exception ex)
		{
            Console.WriteLine(ex.Message);
            Thread.Sleep(1000);
        }
	}
	public void UserCreationMenu(AccountHandler handler)
	{
		while (true)
		{
			Console.Clear();
			try
			{
                Console.WriteLine("Create your username: ");
                string username = Console.ReadLine();
                if (handler.appUsers.Where(u => u.Username == username).ToList().Count > 0)
                {
                    throw new Exception("Username already exist");
                }
                Console.WriteLine("What is your name?");
				string firstName = Console.ReadLine();
                Console.WriteLine("Last name?");
				string lastName = Console.ReadLine();
                Console.WriteLine("Please write you password?");
				string password = Console.ReadLine();
				User tempUser = new User(handler.appUsers.Count + 1, username, firstName, lastName, password);
				handler.appUsers.Add(tempUser);
				handler.SaveUsersToJson();
				Console.WriteLine("User created!");
				Thread.Sleep(1000);
				ShowMainView(handler);
            }
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				Thread.Sleep(1000);
			}
        }
	}
	public void CategoriesMenu(AccountHandler handler)
	{
		handler.GoToCategories();
	}
}
