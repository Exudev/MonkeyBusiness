using MonkeyBusiness.Models;
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
        public UsersView userView { get; set; }
        public List<User> appUsers{ get; set; }
        public List<Category> categories { get; set; }
        public AccountHandler(string accountPath, string categoriesPath)
        {
            this.AccountPath = accountPath;
            this.CategoriesPath = categoriesPath;
            appUsers = new List<User>();
            categories = new List<Category>();
            actionHandler = new ActionHandler();
            userView = new UsersView();
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
            userView.ShowUsersView(this);
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

        }
    } 
}
