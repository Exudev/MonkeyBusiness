using MonkeyBusiness.Handler;
using MonkeyBusiness.Models;
using System;

public class UsersView
{
	public void ShowUsersView(AccountHandler handler)
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
			int desicion = ChoiceMenu();
			switch (desicion)
			{
				case 1:
					LogInMenu(handler);
					break;
				case 2:
					UserCreationMenu(handler);
					break;
				case 3:
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
        Console.WriteLine("(3) Exit");
		try
		{
			int desicion = int.Parse(Console.ReadLine());
			if (desicion is > 0 and < 4)
			{
				return desicion;
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
	public void LogInMenu(AccountHandler handler)
	{

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
				ShowUsersView(handler);
            }
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				Thread.Sleep(1000);
			}
        }
	}
}
