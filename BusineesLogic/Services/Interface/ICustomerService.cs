using OrderProducts.Domain.DTOs;
using OrderProducts.Domain.DTOs.RequestDto;
using OrderProducts.Domain.DTOs.ResponseDto;


namespace OrderProducts.Bll.Services.Interface
{
    public interface ICustomerService
    {
        Task<List<CustomerResponseDto>> GetAllCustomersAsync();
        Task<CustomerResponseDto> GetCustomerByIdAsync(int custmerid);
        //Task<CustomerDto> GetOrdersCountByCustomer(int customerId);
        Task<CustomerResponseDto> AddCustomerAsync(CustomerRequestDto customer );
        Task<CustomerResponseDto> UpdateCustomerAsync(CustomerRequestDto customer );
        Task DeleteCustomerAsync( int id );

    }
}
