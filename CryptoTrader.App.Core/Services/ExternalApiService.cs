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
        public ExternalApiService() { }

        
        public async Task<IEnumerable<CryptoDto>> GetCryptoDtosAsync()
        {
            var client = new WebClient();
            var itemsInString = await client.DownloadStringTaskAsync(ApiAdress.GetApiAdress());
            var items = await Json.ToObjectAsync<List<CryptoDto>>(itemsInString);

            return items;

        }



    }
}
