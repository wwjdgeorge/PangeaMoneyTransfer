namespace PangeaMoneyTransfer.DB.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set;}
        public DateTime CreatedDate { get; set;}
        public DateTime UpdatedDate { get; set;}

    }
}
