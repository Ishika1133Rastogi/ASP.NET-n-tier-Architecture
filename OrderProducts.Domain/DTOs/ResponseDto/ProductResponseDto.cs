using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProducts.Domain.DTOs.ResponseDto
{
    public class ProductResponseDto
    {
        public int ProductId { get; set; }
        public required string ProductCode { get; set; }
        public required string ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public ICollection<OrderDetailResponseDto> Details { get; set; } = null!;
    }
}
