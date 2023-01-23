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
            var rates = RateSearcher.GetCurrencyRates().Result;
            var dollarRate = rates.Where(r => r.Entity == "Banco Popular" && r.OGCurrency == "DOP" && r.NewCurrency == "USD").First();
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
