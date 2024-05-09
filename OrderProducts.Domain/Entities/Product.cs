
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace OrderProducts.Domain.Entities
{
    public class Product
    {
        [Key]
        [Required]
        public int ProductId { get; set; }

        [Required]
        [StringLength(50)]
        public string? ProductCode { get; set; }

        [Required]
        [StringLength(255)]
        public string? ProductName { get; set; }

        [StringLength(50)]
        public string? ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public ICollection<OrderDetails> Details { get; set; } = new Collection<OrderDetails>();        
    }
}
