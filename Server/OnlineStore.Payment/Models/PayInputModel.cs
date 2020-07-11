using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Payment.Models
{
    public class PayInputModel
    {
        public int OrderId { get; set; }
        public decimal TotalPrice { get; set; }

        [Required]
        public string CardNumber { get; set; }

        [Required]
        public string Ccv { get; set; }

        [Required]
        public string Year { get; set; }

        [Required]
        public string Month { get; set; }
    }
}
