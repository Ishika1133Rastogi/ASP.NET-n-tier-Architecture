
using Microsoft.AspNetCore.Mvc;
using OrderProducts.Bll.Services.Interface;
using OrderProducts.Domain.DTOs.RequestDto;
using OrderProducts.Domain.DTOs.ResponseDto;


namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService OrderService)
        {
            _orderService = OrderService;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderResponseDto>>> GetOrders()
        {
            try
            {
                var Orders = await _orderService.GetAllOrdersAsync();
                return Ok(Orders);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error : {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderResponseDto>> GetOrder(int id)
        {
            try {
                var Order = await _orderService.GetOrderByIdAsync(id);
                if (Order == null)
                {
                    return NotFound();
                }

                return Ok(Order);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
            }

        [HttpGet("{id}/count")]
        public async Task<ActionResult<int>> GetOrderCountByCustomerId(int customerId)
        {
            var orderCount = await _orderService.GetOrderCountByCustomerId(customerId);
            return Ok(orderCount);
        }

        [HttpPost]
        public async Task<ActionResult<OrderResponseDto>> AddOrder(OrderRequestDto Order)
        {
            var addedOrder = await _orderService.AddOrderAsync(Order);
            return CreatedAtAction(nameof(GetOrder), new { id = addedOrder.OrderId }, addedOrder);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<OrderResponseDto>> UpdateOrder(int id, OrderRequestDto Order)
        {
            if (id != Order.OrderId)
            {
                return BadRequest();
            }

            var updatedOrder = await _orderService.UpdateOrderAsync(Order);
            return Ok(updatedOrder);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrder(int id)
        {
            try
            {
                await _orderService.DeleteOrderAsync(id);
                return Ok();
            }
            
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
