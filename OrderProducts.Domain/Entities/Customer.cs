using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace OrderProducts.Domain.Entities
{
    
    public class Customer
    {
        public Customer()
        {
            Order  = new Collection<Order>();
        }

        [Required]
        public int CustomerId { get; set; }
        
        [Required]
        [StringLength(255)]
        public string CustomerName { get; set; }
        public required string CustomerAddress { get; set; }
        public required string TaxIdentifier { get; set; }
        public  ICollection<Order> Order { get; set; } 

         
    }
}
