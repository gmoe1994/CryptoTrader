﻿using ComicsUniverse.Core.Helpers;
using CryptoTrader.App.Core.Contracts.Services;
using CryptoTrader.App.Core.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CryptoTrader.App.Core.Services
{
    public class CryptoService : ICryptoService
    {
        public CryptoService() 
        {
            _httpClient = new HttpClient() { BaseAddress = new System.Uri(ApiAdress.PortfolioApi) };
        }

        private readonly HttpClient _httpClient;

        public async Task<IEnumerable<CryptoDto>> GetCryptoDtosAsync()
        {
            var client = new WebClient();
            var itemsInString = await client.DownloadStringTaskAsync(ApiAdress.GetApiAdress());
            var items = await Json.ToObjectAsync<List<CryptoDto>>(itemsInString);

            return items;

        }

        public async Task<IEnumerable<CryptoDto>> GetCryptosAsync()
        {
            var items = new List<CryptoDto>();
            HttpResponseMessage response = await _httpClient.GetAsync("CryptoCurrencies");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                items = await Json.ToObjectAsync<List<CryptoDto>>(content);
            }
            return items;
        }

        public async Task<CryptoDto> CreateCryptoAsync(CryptoDto crypto)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"CryptoCurrencies", crypto);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<CryptoDto>();
        }

        public Task<bool> DeleteCryptoAsync(CryptoDto crypto)
        {
            throw new NotImplementedException();
        }

        public void UpdateCryptoAsync(CryptoDto crypto)
        {
            throw new NotImplementedException();
        }
    }
}
