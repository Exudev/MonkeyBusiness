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
        public Types Type { get; set; }

    }
    public enum Types
    {
        Expense,
        Income
    }
}
