namespace OnlineStore.Ordering.Models
{
    public class CreateOrderOutputModel
    {
        public CreateOrderOutputModel(int orderId)
            => this.OrderId = orderId;
        
        public int OrderId { get; set; }
    }
}
