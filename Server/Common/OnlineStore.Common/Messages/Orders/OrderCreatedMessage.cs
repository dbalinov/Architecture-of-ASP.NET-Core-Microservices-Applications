using System.Collections.Generic;

namespace OnlineStore.Common.Messages.Orders
{
    public class OrderCreatedMessage
    {
        public IList<OrderCreatedProduct> Products { get; set; }
    }
}
