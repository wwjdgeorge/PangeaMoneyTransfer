using PangeaMoneyTransfer.Commen.Enum;

namespace PangeaMoneyTransfer.DomainModels.ResponseModels
{
    public class ExchangeRate
    {
        public string CurrencyCode { get; set; }
        public string CountryCode { get; set; }
        public decimal PangeaRate { get; set; }
        public PaymentMethods PaymentMethod { get; set; }
        public DeliveryMethods DeliveryMethod { get; set; }
    }
}
