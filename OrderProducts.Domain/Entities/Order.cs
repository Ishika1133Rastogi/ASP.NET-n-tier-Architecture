
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace OrderProducts.Domain.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        [Required]
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime OrderDate { get; set; }
        public decimal OrederAmount { get; set; }
        public string? Comments { get; set; }

        public virtual Customer Customers { get; set; } = null!;
        public int CustomerId { get; set; }
        public ICollection<OrderDetails> OrderDetail { get; set; } = new Collection<OrderDetails>();       
    }
}
