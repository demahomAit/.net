using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AndalusRestaurant.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string? UserId { get; set; }
        public ApplicationUser User { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal TotalAmount { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }

    }
}
