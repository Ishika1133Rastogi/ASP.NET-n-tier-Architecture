using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProducts.Domain.DTOs.RequestDto
{
    public class OrderRequestDto
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public decimal OrderAmount { get; set; }
        public string? Comments { get; set; }
        [Required]
        public int CustomerId { get; set; }
    }
}
