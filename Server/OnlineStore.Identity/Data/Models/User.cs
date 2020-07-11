using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Identity;

namespace OnlineStore.Identity.Data.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
