using OrderProducts.Domain.DTOs;
using OrderProducts.Dal.Repositories;
using OrderProducts.Bll.Services.Interface;
using OrderProducts.Dal.Repositories.Interface;
using AutoMapper;
using OrderProducts.Domain.Entities;
using OrderProducts.Domain.DTOs.ResponseDto;
using OrderProducts.Domain.DTOs.RequestDto;



namespace OrderProducts.Bll.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
       
        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<List<OrderResponseDto>> GetAllOrdersAsync()
        {
            var orders = await _orderRepository.GetAsync();
            var makeDtos = _mapper.Map<List<OrderResponseDto>>(orders);

            foreach (var customer in makeDtos)
            {
                var ordersdetail = await _orderRepository.GetOrdersByCustomerId(customer.OrderId);
                customer.OrderDetail = _mapper.Map<List<OrderDetailResponseDto>>(ordersdetail);
            }

            return makeDtos;
        }
        public async Task<int> GetOrderCountByCustomerId(int customerId)
        {
            return await _orderRepository.GetOrderCountByCustomerId(customerId);
        }
        
        public async Task<OrderResponseDto> GetOrderByIdAsync(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            
            return _mapper.Map<OrderResponseDto>(order);
        }

        public async Task<OrderResponseDto> AddOrderAsync(OrderRequestDto orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);
            var addedOrder = await _orderRepository.AddAsync(order);
            return _mapper.Map<OrderResponseDto>(addedOrder);

        }

        public async Task<OrderResponseDto> UpdateOrderAsync(OrderRequestDto orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);
            var updatedOrder = await _orderRepository.UpdateAsync(order);
            return _mapper.Map<OrderResponseDto>(updatedOrder);
        }

        public async Task DeleteOrderAsync(int id)
        {
             await _orderRepository.DeleteAsync(id);
        }
    }
}
