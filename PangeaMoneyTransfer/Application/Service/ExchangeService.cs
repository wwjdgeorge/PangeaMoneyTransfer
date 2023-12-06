using AutoMapper;
using PangeaMoneyTransfer.Commen.Enum;
using PangeaMoneyTransfer.DB;
using PangeaMoneyTransfer.DomainModels.RequestModels;
using PangeaMoneyTransfer.DomainModels.ResponseModels;
using PangeaMoneyTransfer.Interfaces.Application.Service;
using System.Runtime.CompilerServices;

namespace PangeaMoneyTransfer.Application.Service
{
    public class ExchangeService : IExchangeService
    {
        private readonly ILogger<ExchangeService> _logger;
        private readonly IMapper _mapper;
        private readonly IServiceConfig _serviceConfig;
        private readonly ExchangeDBContext _dBContext;

        public ExchangeService(ILogger<ExchangeService> logger, IMapper mapper, IServiceConfig serviceConfig, ExchangeDBContext dBContext )
        {
            _logger = logger;
            _mapper = mapper;
            _serviceConfig = serviceConfig;
            _dBContext = dBContext;
        }
        public async Task<(bool isSuccess, IEnumerable<ExchangeRate> rates)> ExchangeRatesAsync(string currencyCode)
        {
            try
            {
                var result = await _serviceConfig.JsonDeserializeAsync();
                if (result.IsSuccess)
                {
                    var rates = result.PartnerRates.Where((O) => O.Currency.CurrencyCode == currencyCode).OrderByDescending(o => o.AcquiredDate).Take(1)
                        .Select((PR) => new ExchangeRate()
                        {
                            CurrencyCode = PR.Currency?.CurrencyCode ?? currencyCode,
                            CountryCode = GetCountryCode(PR.Currency?.CurrencyCode),
                            PangeaRate = Math.Round(GetPangeaRate(PR.Rate, PR.Currency?.CurrencyCode), 2),
                            PaymentMethod = PR.PaymentMethod,
                            DeliveryMethod = PR.DeliveryMethod
                        });
                    return (true, rates);
                }
                return (false, null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return (false, null);
            }
        }
        private string GetCountryCode(string currencyCode)
        {
             
            var countryCode = from curr in _dBContext.currencys
                    from coun in _dBContext.countries
                    where (curr.CountryId == coun.Id && curr.CurrencyCode== currencyCode)
                    select new
                    {
                        coun.Code                        
                    };
            return countryCode.ToString();
        }

        private Decimal GetPangeaRate(Decimal pangeaRate, string currencyCode)
        {
            var flatRate = from curr in _dBContext.currencys
                              from coun in _dBContext.countryFlatRates
                              where (curr.Id == coun.currencyId && curr.CurrencyCode == currencyCode)
                              select new
                              {
                                  coun.flatRate
                              };
            var rate = (pangeaRate + Convert.ToDecimal(flatRate));
            return rate;
        }

    }
    
}