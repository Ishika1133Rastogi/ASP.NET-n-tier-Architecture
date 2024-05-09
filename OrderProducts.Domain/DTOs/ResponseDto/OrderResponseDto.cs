using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProducts.Domain.DTOs.ResponseDto
{
    public class OrderResponseDto
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public decimal OrderAmount { get; set; }
        public string? Comments { get; set; }

        public ICollection<OrderDetailResponseDto> OrderDetail { get; set; } = new Collection<OrderDetailResponseDto>();
    }
}
