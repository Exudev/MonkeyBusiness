using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyBusiness.Resources
{
    public class MoneyConverter
    {
        IRateSearcher RateSearcher { get; set; }
        public MoneyConverter(IRateSearcher rateSearcher)
        {
            RateSearcher = rateSearcher;
        }
        public MoneyConverter() { RateSearcher = new RateSearcher();}
        public decimal ConvertCurrency(decimal value, bool isDOP)
        {
            int nom = 0;
            var rates = RateSearcher.GetCurrencyRates();
            while (!rates.IsCompleted)
            {
                nom++;
                if (nom % 3 == 0)
                {
                    Console.Write(@"\");
                }
                else if (nom % 3 == 1)
                {
                    Console.Write("-");
                }
                else
                {
                    Console.Write("/");
                }
                Thread.Sleep(85);
                Console.Write("\b");
            }
            var dollarRate = rates.Result.Where(r => r.Entity == "Banco Popular" && r.OGCurrency == "DOP" && r.NewCurrency == "USD").First();
            decimal exchangeRate = 0;
            if (isDOP)
            {
                exchangeRate = value / (decimal)dollarRate.Value;
                return decimal.Round(exchangeRate, 2);
            }
            else
            {
                exchangeRate = value * (decimal)dollarRate.Value;
                return decimal.Round(exchangeRate, 2); ;
            }
        }
    }
}
