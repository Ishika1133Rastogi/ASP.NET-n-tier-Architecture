using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProducts.Domain.DTOs.ResponseDto
{
    public class CustomerResponseDto
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public required string CustomerAddress { get; set; }
        public required string TaxIdentifier { get; set; }
        public ICollection<OrderResponseDto> Order { get; set; } = new Collection<OrderResponseDto>();
    }
}
