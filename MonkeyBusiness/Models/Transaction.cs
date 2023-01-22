using AngleSharp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyBusiness.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public Category Category { get; set; }
        public string Description { get; set; }
        public TransactionType TType { get; set; }

        public Transaction(int id, int accId, string name,decimal amount, Category category, string description)
        {
           Id = id;
           AccountId = accId;
           Name = name;
           Amount = amount;
           Date = DateTime.Now;    
           Category = category;
           Description = description;
           
        }
        public string GetEnumType(Transaction transaction)
        {
            if (transaction.TType == TransactionType.Income)
            {
                return "+";
            }
            else
            {
                return "-";
            }
        }
    }
   
    public enum TransactionType
    {
        Expense,
        Income
    }
}
