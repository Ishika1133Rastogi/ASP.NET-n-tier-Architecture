using OrderProducts.Domain.DTOs.RequestDto;
using OrderProducts.Domain.DTOs.ResponseDto;

namespace OrderProducts.Bll.Services.Interface
{
    public interface IOrderService
    {
        Task<List<OrderResponseDto>> GetAllOrdersAsync();
        Task<OrderResponseDto> GetOrderByIdAsync(int orderid);
        Task<int> GetOrderCountByCustomerId(int id);
        Task<OrderResponseDto> AddOrderAsync(OrderRequestDto order);
        Task<OrderResponseDto> UpdateOrderAsync(OrderRequestDto order);
        Task DeleteOrderAsync(int id);
    }
}
