using System.ComponentModel.DataAnnotations;

namespace OrderProducts.Domain.Entities
{
    public class OrderDetails
    {
        [Key]
        public int OrderDetailId { get; set; }
        public int Quantity { get; set; }
        public virtual Order Orders { get; set; } = null!;
        public int OrderId { get; set; } 
        public virtual Product Product { get; set; } = null!;
        public int ProductId { get; set; }
    }
}