using OrderProducts.Domain.DTOs;
using OrderProducts.Domain.DTOs.ResponseDto;
using OrderProducts.Domain.Entities;


namespace OrderProducts.Dal.Repositories.Interface
{
    public interface IProductRepository :  IGenericRepository<Product>
    {
        Task<List<OrderDetailResponseDto>> GetOrdersdetailsByProductId(int customerId);
        Task<List<CustomerResponseDto>> GetCustomersByProductIdAsync(int productId);
    }
}
