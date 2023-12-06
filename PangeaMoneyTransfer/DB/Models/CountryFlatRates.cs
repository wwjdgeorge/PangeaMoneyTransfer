namespace PangeaMoneyTransfer.DB.Models
{
    public class CountryFlatRates
    {
        public int id { get; set; }
        public int  currencyId { get; set; }
        public decimal flatRate { get; set; }
    }
}
