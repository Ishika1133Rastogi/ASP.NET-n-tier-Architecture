using OrderProducts.Domain.DTOs;
using OrderProducts.Domain.DTOs.ResponseDto;
using OrderProducts.Domain.Entities;

namespace OrderProducts.Dal.Repositories.Interface
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<List<OrderDetailResponseDto>> GetOrdersByCustomerId(int orderId);
        Task<int> GetOrderCountByCustomerId(int customerId);
        // Task<List<OrderDetailDto>> GetOrderdetailsByOrderId(int orderdetailId);
    }
}
