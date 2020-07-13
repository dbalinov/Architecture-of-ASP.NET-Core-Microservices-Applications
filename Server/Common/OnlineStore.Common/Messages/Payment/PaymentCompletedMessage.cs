using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.Common.Messages.Payment
{
    public class PaymentCompletedMessage
    {
        public int OrderId { get; set; }
    }
}
