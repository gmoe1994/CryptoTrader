using ComicsUniverse.Core.Helpers;
using CryptoTrader.App.Core.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CryptoTrader.App.Core.Services
{
    public class ExternalApiService
    {
        private static readonly string API_KEY = "a9dd48ab86d9a5226102aa57b06c0502fbf4259f";

        public ExternalApiService()
        {
        }

        
        public async Task<IEnumerable<CryptoDto>> GetCryptoDtosAsync()
        {

            var URL = new UriBuilder("https://api.nomics.com/v1/currencies/ticker");

            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["key"] = API_KEY;
            //queryString["ids"] = "BTC,ETH,XRP,SOL,ADA,DOT,DOGE,SHIB,NEAR,XMR";
            queryString["interval"] = "1d";
            queryString["convert"] = "USD";
            queryString["per-page"] = "100";
            queryString["page"] = "1";

            URL.Query = queryString.ToString();

            var client = new WebClient();
            client.Headers.Add("Accepts", "application/json");
            var itemsInString = await client.DownloadStringTaskAsync(URL.ToString());
            var items = await Json.ToObjectAsync<List<CryptoDto>>(itemsInString);

            return items;

        }



    }
}
