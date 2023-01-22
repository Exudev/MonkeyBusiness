using MonkeyBusiness.Models;
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
        public ActionHandler actionHandler { get; set; }
        public MainView mainView { get; set; }
        public UserView userView { get; set; }
        public AccountView accountView { get; set; }
        public List<User> appUsers{ get; set; }
        public List<Category> categories { get; set; }
        public AccountHandler(string accountPath, string categoriesPath)
        {
            this.AccountPath = accountPath;
            this.CategoriesPath = categoriesPath;
            appUsers = new List<User>();
            categories = new List<Category>();
            actionHandler = new ActionHandler();
            mainView = new MainView();
            userView = new UserView();
             accountView = new AccountView();
            Deserialize(accountPath, categoriesPath);
            Initialize();
        }
        public void Deserialize(string accounts, string categories)
        {
            using (var reader = new StreamReader(accounts))// esta linea me dio error: tuve que crear en el bin la misma carpeta JsonFiles
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
        public void Exit()
        {
            Environment.Exit(0);
        }
        public async void ShowCategories()
        {
            foreach (var item in this.categories)
            {
                Console.WriteLine(item);
            }
        }
    } 
}
