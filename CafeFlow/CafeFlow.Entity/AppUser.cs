using Microsoft.AspNetCore.Identity;

namespace CafeFlow.Entity
{
    public class AppUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Customer? Customer { get; set; }
    }
}
