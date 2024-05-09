using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProducts.Domain.DTOs.RequestDto
{
    public class OrderDetailRequestDto
    {
        public int OrderDetailId { get; set; }
        public int Quantity { get; set; } = 0;
        public int ProductId { get; set; }
        public int OrderId { get; set; }

    }
}
