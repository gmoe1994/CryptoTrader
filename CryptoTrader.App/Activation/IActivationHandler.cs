using System.Threading.Tasks;

namespace CryptoTrader.App.Activation
{
    public interface IActivationHandler
    {
        bool CanHandle(object args);

        Task HandleAsync(object args);
    }
}
