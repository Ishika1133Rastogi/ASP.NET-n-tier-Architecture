using OrderProducts.Domain.DTOs;
using OrderProducts.Domain.DTOs.RequestDto;
using OrderProducts.Domain.DTOs.ResponseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProducts.Bll.Services.Interface
{
    public interface IProductService
    {
        Task<List<ProductResponseDto>> GetAllProductsAsync();
        Task<ProductResponseDto> GetProductByIdAsync(int productid);
        Task<ProductResponseDto> AddProductAsync(ProductRequestDto product);
        Task<ProductResponseDto> UpdateProductAsync(ProductRequestDto product);
        Task<List<CustomerResponseDto>> GetCustomersByProductIdAsync(int productId);
        Task DeleteProductAsync(int id);
    }
}
