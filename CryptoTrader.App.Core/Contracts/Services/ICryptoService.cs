using CryptoTrader.App.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CryptoTrader.App.Core.Contracts.Services
{
    // Remove this class once your pages/features are using your data.
    public interface ICryptoService
    {
        Task<IEnumerable<CryptoDto>> GetCryptoDtosAsync();
        Task<IEnumerable<CryptoDto>> GetCryptosAsync();
        Task<CryptoDto> GetCryptoAsync(string id);
        Task<CryptoDto> CreateCryptoAsync(CryptoDto crypto);
        Task<bool> DeleteCryptoAsync(CryptoDto crypto);
        void UpdateCryptoAsync(CryptoDto crypto);

    }
}

