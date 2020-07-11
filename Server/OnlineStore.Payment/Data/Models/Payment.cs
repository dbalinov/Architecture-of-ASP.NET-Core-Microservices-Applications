namespace OnlineStore.Payment.Data.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
