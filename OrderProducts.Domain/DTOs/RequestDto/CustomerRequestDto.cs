using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProducts.Domain.DTOs.RequestDto
{
    public class CustomerRequestDto
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string TaxIdentifier { get; set; }
    }
}
