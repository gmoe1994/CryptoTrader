using System;

namespace CryptoTrader.App.Contracts.Services
{
    public interface IPageService
    {
        Type GetPageType(string key);
    }
}
