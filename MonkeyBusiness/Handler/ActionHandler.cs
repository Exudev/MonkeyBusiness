using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MonkeyBusiness.Models;


namespace MonkeyBusiness.Handler
{
    public class ActionHandler
    {
        AccountHandler handler;

        public Transaction GerenateIncome(Account account, decimal amount)
        {
            Transaction transaction = TransStart(account);
            account.Balance += amount;
            transaction.Type = Types.Income;
            return transaction;
        }

        public Transaction GerenateExpense(Account account, decimal amount)
        {

            Transaction transaction = TransStart(account);
            account.Balance -= amount;
            transaction.Type = Types.Expense;
            return transaction;
        }

        public Transaction TransStart(Account account)
        {

            int id = handler.GetTransactionID(account);
            Console.WriteLine("Como desea nombrar el income?");
            string nameInco = Console.ReadLine();
            Console.WriteLine("Alguna descripcion para el income?");
            string desInco = Console.ReadLine();
            Console.WriteLine("Selecciona la categoria");
            handler.ShowCategories();
            Category category = new(4, "Gasoline");
            Console.WriteLine("Monto de la transaccion?");
            string monto = Console.ReadLine();
            if(IsNumber(monto))
            {
                Console.WriteLine("No digitaste un numero en el apartado de monto");
            }
            else
            {
                Console.WriteLine("No digitaste un numero en el apartado de monto");
               
            }
                 Transaction transaction = new(id, account.Id, nameInco, decimal.Parse(monto), category, desInco);
                 return transaction;
        }

        public bool IsNumber(string number)
        {
            if (Regex.IsMatch(number, @"^[0-9]+$"))//lo hice con regex porque el profe lo enseño
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

