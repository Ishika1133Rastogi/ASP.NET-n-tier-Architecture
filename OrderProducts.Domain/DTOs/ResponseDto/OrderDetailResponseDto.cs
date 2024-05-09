using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProducts.Domain.DTOs.ResponseDto
{
    public class OrderDetailResponseDto
    {
        public int OrderDetailId { get; set; }
        public int Quantity { get; set; } = 0;
    }
}
