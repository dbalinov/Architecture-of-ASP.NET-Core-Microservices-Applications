using System.Collections.Generic;

namespace OnlineStore.Ordering.Data.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public IEnumerable<OrderLine> OrderLines { get; set; } = new List<OrderLine>();
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public OrderStatus Status { get; set; }
    }
}
