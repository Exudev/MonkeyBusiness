using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace MonkeyBusiness.Models
{
    public class Account
    {
        public int Id { get; set; }
        public int NextId { get; set; }
        public int UserId { get; set; }
        public decimal Balance { get; set; }
        public List<Transaction> Transactions { get; set; }
        public Account() { }
        public Account(int id, int userId)
        {
            this.Id = id;
            this.NextId = 0;
            this.UserId = userId;
            this.Balance = 0;
            this.Transactions = new List<Transaction>();
        }
        public void updateNextID(int newId)
        {
            this.NextId = newId + 1;
        }
    }
}
