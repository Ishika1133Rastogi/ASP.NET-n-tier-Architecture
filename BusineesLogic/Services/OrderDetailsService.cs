
using OrderProducts.Domain.DTOs;
using OrderProducts.Dal.Repositories.Interface;
using OrderProducts.Bll.Services.Interface;
using AutoMapper;
using OrderProducts.Domain.Entities;
using OrderProducts.Domain.DTOs.ResponseDto;
using OrderProducts.Domain.DTOs.RequestDto;



namespace OrderProducts.Bll.Services
{
    public class OrderDetailsService : IOrderDetailsService
    {
        private readonly IOrderDetailsRepository _orderdetailsRepository;
        private readonly IMapper _mapper;

        public OrderDetailsService(IOrderDetailsRepository orderdetailsRepository, IMapper mapper)
        {
            _orderdetailsRepository = orderdetailsRepository;
            _mapper = mapper;
        }

        public async Task<List<OrderDetailResponseDto>> GetAllOrderDetailsAsync()
        {
            var orderDetails = await _orderdetailsRepository.GetAsync();
            return _mapper.Map<List<OrderDetailResponseDto>>(orderDetails); 
        }

        public async Task<OrderDetailResponseDto> GetOrderDetailsByIdAsync(int id)
        {
            var orderDetails = await _orderdetailsRepository.GetByIdAsync(id);
            return _mapper.Map<OrderDetailResponseDto>(orderDetails);
        }

        public async Task<OrderDetailResponseDto> AddOrderDetailsAsync(OrderDetailRequestDto orderDetailsDto)
        {
            var orderDetails = _mapper.Map<OrderDetails>(orderDetailsDto);
            var addedOrderDetails = await _orderdetailsRepository.AddAsync(orderDetails);
            return _mapper.Map<OrderDetailResponseDto>(addedOrderDetails);
        }

        public async Task<OrderDetailResponseDto> UpdateOrderDetailsAsync(OrderDetailRequestDto orderDetailsDto)
        {
            var orderDetails = _mapper.Map<OrderDetails>(orderDetailsDto); 
            var updatedOrderDetails = await _orderdetailsRepository.UpdateAsync(orderDetails);
            return _mapper.Map<OrderDetailResponseDto>(updatedOrderDetails);
        }

        public async Task DeleteOrderDetailsAsync(int id)
        {
             await _orderdetailsRepository.DeleteAsync(id);
        }
    }
}
