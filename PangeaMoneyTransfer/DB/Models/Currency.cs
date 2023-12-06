namespace PangeaMoneyTransfer.DB.Models
{
    public class Currency
    {        
        public int Id { get; set; } 
        public int CountryId { get; set; }
        public string CurrencyCode { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencyDescription { get; set; }
        public string CurrencyPrice { get; set; }
        public string CurrencySymbol { get; set; }

    }
}