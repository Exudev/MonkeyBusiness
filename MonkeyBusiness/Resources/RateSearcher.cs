using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp;

/*
 * Este archivo completo lo pueden copiar y pegar en su proyecto.
 * Para esto, tienen que tener instalado "AngleSharp" en su proyecto, y asegurense
 * de cambiar el nombre del namespace al que están usando.
 */

namespace MonkeyBusiness.Resources
{
    // esto es símplemente para agrupar los valores de cada tasa
    public struct Rate
    {
        public string Entity;
        public float Value;
        public string OGCurrency;
        public string NewCurrency;

        public Rate(float value, string ogCurrency, string newCurrency, string entity = "")
        {
            Entity = entity;
            Value = value;
            OGCurrency = ogCurrency;
            NewCurrency = newCurrency;
        }

    }

    // Esta interfaz es para poder hacer un stub de BuscadorTasas para las Pruebas Unitarias
    public interface IRateSearcher
    {
        public Task<List<Rate>> GetCurrencyRates();
    }

    /* Esta es la clase que hace un request a infodolar.com.do y hace un scrapping de las tasas.
    Tendrán que hacer un stub de esta clase en el proyecto de Pruebas Unitarias, para sustituirla
    por una versión que no haga el request realmente (al final, descarté lo que les había comentado
    de hacer un stub del HttpClient o del BrowsingContext porque se complicaría demasiado).*/
    public class RateSearcher : IRateSearcher
    {
        /* Este método debería ser async para poder hacerle un await al método "OpenAsync". 
         La razón por la que no lo puse async, es para que lo hagan ustedes mismos cuando lo integren
        a su proyecto. */
        public async Task<List<Rate>> GetCurrencyRates()
        {
            List<Rate> rates = new List<Rate>();
            var config = Configuration.Default.WithDefaultLoader();
            var address = "https://www.infodolar.com.do/";
            var context = BrowsingContext.New(config);
            var document = await context.OpenAsync(address); //deben de sustituirlo por un await
            var cells = document.QuerySelectorAll("table#Dolar tbody tr");

            foreach (var i in cells)
            {
                var bankName = i.Children[0].QuerySelector("span.nombre")?.TextContent.Trim() ?? "";
                var signedBuyPrice = i.Children[1].TextContent.Split('\n')[1].Trim();
                var signedSellPrice = i.Children[2].TextContent.Split('\n')[1].Trim();
                float buyPrice = signedBuyPrice != "" ? Convert.ToSingle(signedBuyPrice.Replace("$", "")) : 0.0f;
                float sellPrice = signedSellPrice != "" ? Convert.ToSingle(signedSellPrice.Replace("$", "")) : 0.0f;
                rates.Add(new Rate(buyPrice, "USD", "DOP", bankName));
                rates.Add(new Rate(sellPrice, "DOP", "USD", bankName));
            }
            return rates;

        }
    }
}