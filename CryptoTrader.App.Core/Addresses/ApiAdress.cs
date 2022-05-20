using System;
using System.Web;

namespace CryptoTrader.App.Core
{
    public static class ApiAdress
    {
        public const string PortfolioApi = "https://localhost:44321/api/";

        public const string DataApi = "https://api.nomics.com/v1/currencies/ticker";

        private static readonly string API_KEY = "a9dd48ab86d9a5226102aa57b06c0502fbf4259f";

        /// <summary>Gets the API adress for the external api. Adress depends on querys set in the method.</summary>
        /// <returns>System.String.</returns>
        public static string GetApiAdress()
        {
            var URL = new UriBuilder(DataApi);

            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["key"] = API_KEY;
            queryString["interval"] = "1d";
            queryString["convert"] = "USD";
            queryString["per-page"] = "100";
            queryString["page"] = "1";

            URL.Query = queryString.ToString();

            return URL.ToString();
        }
    }
}
