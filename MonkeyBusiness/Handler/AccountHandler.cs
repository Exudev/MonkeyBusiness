using MonkeyBusiness.Models;
using MonkeyBusiness.Resources;
using MonkeyBusiness.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyBusiness.Handler
{
    public class AccountHandler
    {
        public string AccountPath { get; set; }
        public string CategoriesPath { get; set; }
        
        public MoneyConverter Converter { get; set; }
        public MainView mainView { get; set; }
        public UserView userView { get; set; }
        public CategoriesView categoriesView { get; set; }
        public AccountView accountView { get; set; }
        public List<User> appUsers{ get; set; }
        public List<Category> categories { get; set; }
        public AccountHandler(string accountPath, string categoriesPath)
        {
            this.AccountPath = accountPath;
            this.CategoriesPath = categoriesPath;
            appUsers = new List<User>();
            categories = new List<Category>();
            mainView = new MainView();
            userView = new UserView();
             accountView = new AccountView();
            categoriesView = new CategoriesView();
            Converter = new MoneyConverter();
            Deserialize(accountPath, categoriesPath);
            Initialize();
        }
        public void Deserialize(string accounts, string categories)
        {
            using (var reader = new StreamReader(accounts))
            {
                string readingsFromJson = reader.ReadToEnd();
                if(readingsFromJson != string.Empty)
                {
                    List<User> screensFromJson = JsonConvert.DeserializeObject<List<User>>(readingsFromJson);
                    this.appUsers = screensFromJson;
                }
                
            }
            using (var reader = new StreamReader(categories))
            {
                string readingsFromJson = reader.ReadToEnd();
                if(readingsFromJson != string.Empty)
                {
                    List<Category> categoriesFromJson = JsonConvert.DeserializeObject<List<Category>>(readingsFromJson);
                    this.categories = categoriesFromJson;
                }             
            }
        }
        public void Initialize()
        {
            mainView.ShowMainView(this);
        }
        public void GoToUser(User user)
        {
            userView.ShowUserView(this, user);
        }
        public void GoToAccount(User user, Account account)
        {
            accountView.ShowAccountView(this, user, account);
        }
        public void GoToCategories()
        {
            categoriesView.ShowCategoriesView(this);
        }
        public int GetTransactionID(Account currentAccount)
       {
            int result = currentAccount.Transactions.Count;
            return result + 1;
       }
       public void SaveUsersToJson()
       {
            var json = JsonConvert.SerializeObject(this.appUsers.ToArray(), Formatting.Indented);
            File.WriteAllText(AccountPath, json);
       }
        public void SaveCategoriesToJson()
        {
            var json = JsonConvert.SerializeObject(this.categories.ToArray(), Formatting.Indented);
            File.WriteAllText(CategoriesPath, json);
        }
        public void Exit()
        {
            Environment.Exit(0);
        }
        public void ShowCategories()
        {
            foreach (var item in this.categories)
            {
                Console.WriteLine("{0}: {1}",item.Id, item.Name);
            }
        }
        public void UpdateCategoriesID()
        {
            for (int i = 0; i < categories.Count(); i++)
            {
                categories[i].Id = i + 1;
            }
        }
    } 
}
