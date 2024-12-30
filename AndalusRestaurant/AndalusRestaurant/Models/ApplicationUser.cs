using Microsoft.AspNetCore.Identity;

namespace AndalusRestaurant.Models
{
    public class ApplicationUser:IdentityUser
    {
        public ICollection<Order>? orders { get; set; }
    }
}
