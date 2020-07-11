using System.ComponentModel.DataAnnotations;

using static OnlineStore.Common.Data.DataConstants.Common;

namespace OnlineStore.Identity.Models.Identity
{
    public class CreateUserInputModel : UserInputModel
    {

        [Required]
        [MinLength(MinNameLength)]
        [MaxLength(MaxNameLength)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(MinNameLength)]
        [MaxLength(MaxNameLength)]
        public string LastName { get; set; }
    }
}
