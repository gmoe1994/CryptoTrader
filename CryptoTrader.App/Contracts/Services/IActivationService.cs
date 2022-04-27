using System.Threading.Tasks;

namespace CryptoTrader.App.Contracts.Services
{
    public interface IActivationService
    {
        Task ActivateAsync(object activationArgs);
    }
}
