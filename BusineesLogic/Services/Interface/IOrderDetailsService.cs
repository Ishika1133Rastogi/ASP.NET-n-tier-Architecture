using OrderProducts.Domain.DTOs;
using OrderProducts.Domain.DTOs.RequestDto;
using OrderProducts.Domain.DTOs.ResponseDto;

namespace OrderProducts.Bll.Services.Interface
{
    public interface IOrderDetailsService
    {
        Task<List<OrderDetailResponseDto>> GetAllOrderDetailsAsync();
        Task<OrderDetailResponseDto> GetOrderDetailsByIdAsync(int orderDetailsid);
        Task<OrderDetailResponseDto> AddOrderDetailsAsync(OrderDetailRequestDto orderDetails);
        Task<OrderDetailResponseDto> UpdateOrderDetailsAsync(OrderDetailRequestDto orderDetails);
        Task DeleteOrderDetailsAsync(int id);
    }
}
