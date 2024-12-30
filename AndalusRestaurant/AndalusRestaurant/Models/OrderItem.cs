using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Http.Headers;

namespace AndalusRestaurant.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public Order? Order { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public int Quantity { get; set; }
        [Column(TypeName ="decimal(10,2)")]
        public decimal Price { get; set; }
    }
}
