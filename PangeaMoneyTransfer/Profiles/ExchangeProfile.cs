using PangeaMoneyTransfer.DB.Models;

namespace PangeaMoneyTransfer.Profiles
{
    public class ExchangeProfile :AutoMapper.Profile
    {
        public ExchangeProfile() {
            CreateMap<Country, PangeaMoneyTransfer.DomainModels.Country>();
            CreateMap<Currency, PangeaMoneyTransfer.DomainModels.Currency>();
            CreateMap<CountryFlatRates, PangeaMoneyTransfer.DomainModels.CountryFlatRates>();
        }
    }
}
