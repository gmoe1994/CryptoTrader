using System.Collections.Generic;
using System.Threading.Tasks;

using CryptoTrader.App.Core.Models;

namespace CryptoTrader.App.Core.Contracts.Services
{
    // Remove this class once your pages/features are using your data.
    public interface ISampleDataService
    {
        Task<IEnumerable<SampleOrder>> GetListDetailsDataAsync();

        Task<IEnumerable<SampleOrder>> GetContentGridDataAsync();
    }
}
