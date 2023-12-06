using PangeaMoneyTransfer.DomainModels.ResponseModels;

namespace PangeaMoneyTransfer.Interfaces.Application.Service
{
    public interface IExchangeService
    {
        Task<(bool isSuccess, IEnumerable<ExchangeRate> rates)> ExchangeRatesAsync(string currencyCode);
    }
}
