using PangeaMoneyTransfer.Commen.Enum;
using PangeaMoneyTransfer.DB.Models;

namespace PangeaMoneyTransfer.DomainModels.RequestModels
{
    public class PartnerRate
    {
        public int Id { get; set; }
        public Currency Currency { get; set; }
        public PaymentMethods PaymentMethod { get; set; }
        public DeliveryMethods DeliveryMethod { get; set; }
        public decimal Rate { get; set; }
        public DateTime AcquiredDate { get; set; }
    }
}
