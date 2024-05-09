using OrderProducts.Domain.DTOs;
using OrderProducts.Domain.DTOs.ResponseDto;
using OrderProducts.Domain.Entities;


namespace OrderProducts.Dal.Repositories.Interface
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        //Task<List<CustomerDto>> GetCustomersWithOrders();
        Task<List<OrderResponseDto>> GetOrderByCustomerId(int customerId);
        Task<List<OrderResponseDto>> GetCountOrdersByCustomerId(int customerId);
        
    }
}
