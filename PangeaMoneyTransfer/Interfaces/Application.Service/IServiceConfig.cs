using PangeaMoneyTransfer.DomainModels.RequestModels;

namespace PangeaMoneyTransfer.Interfaces.Application.Service
{
    public interface IServiceConfig
    {
        Task<(bool IsSuccess, IEnumerable<PartnerRate> PartnerRates, string ErrorMessage)> JsonDeserializeAsync(); 
    }
}
