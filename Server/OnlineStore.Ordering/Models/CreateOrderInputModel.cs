using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static OnlineStore.Ordering.Data.DataConstants.Orders;

namespace OnlineStore.Ordering.Models
{
    public class CreateOrderInputModel
    {
        [Required]
        [MinLength(MinPhoneNumberLength)]
        [MaxLength(MaxPhoneNumberLength)]
        [RegularExpression(PhoneNumberRegularExpression)]
        public string PhoneNumber { get; set; }

        [Required]
        [MinLength(MinAddressLength)]
        [MaxLength(MaxAddressLength)]
        public string Address { get; set; }

        public IEnumerable<CreateOrderLineInputModel> OrderLines { get; set; } = new List<CreateOrderLineInputModel>();
    }
}
