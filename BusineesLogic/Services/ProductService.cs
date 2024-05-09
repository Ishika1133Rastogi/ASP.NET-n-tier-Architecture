using AutoMapper;
using OrderProducts.Bll.Services.Interface;
using OrderProducts.Dal.Repositories.Interface;
using OrderProducts.Domain.DTOs;
using OrderProducts.Domain.DTOs.RequestDto;
using OrderProducts.Domain.DTOs.ResponseDto;
using OrderProducts.Domain.Entities;

namespace OrderProducts.Bll.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository, IMapper _mapper)
        {
            _productRepository = productRepository;
            this._mapper = _mapper;
        }
     
        public async Task<List<ProductResponseDto>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAsync();
            var makeDtos = _mapper.Map<List<ProductResponseDto>>(products);

            foreach (var product in makeDtos)
            {
                var orders = await _productRepository.GetOrdersdetailsByProductId(product.ProductId);
                product.Details = _mapper.Map<List<OrderDetailResponseDto>>(orders);
            }

            return makeDtos;
        }

        public async Task<ProductResponseDto> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            return _mapper.Map<ProductResponseDto>(product);
        }

        public async Task<ProductResponseDto> AddProductAsync(ProductRequestDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            var addedProduct = await _productRepository.AddAsync(product);
            return _mapper.Map<ProductResponseDto>(addedProduct);
        }

        public async Task<List<CustomerResponseDto>> GetCustomersByProductIdAsync(int productId)
        {
            var customers = await _productRepository.GetCustomersByProductIdAsync(productId);
            return _mapper.Map<List<CustomerResponseDto>>(customers);
        }

        public async Task<ProductResponseDto> UpdateProductAsync(ProductRequestDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            var updatedProduct = await _productRepository.UpdateAsync(product);
            return _mapper.Map<ProductResponseDto>(updatedProduct);
        }

        public async Task DeleteProductAsync(int id)
        {
             await _productRepository.DeleteAsync(id);
        }
    }

}



   
