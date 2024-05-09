
using Microsoft.AspNetCore.Mvc;
using OrderProducts.Bll.Services.Interface;
using OrderProducts.Domain.DTOs.RequestDto;
using OrderProducts.Domain.DTOs.ResponseDto;


namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrderDetailsService _orderdetailsService;

        public OrderDetailsController(IOrderDetailsService orderdetailsService)
        {
            _orderdetailsService = orderdetailsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderDetailResponseDto>>> GetOrders()
        {
            var Orders = await _orderdetailsService.GetAllOrderDetailsAsync();
            return Ok(Orders);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDetailResponseDto>> GetOrder(int id)
        {
            var Order = await _orderdetailsService.GetOrderDetailsByIdAsync(id);
            if (Order == null)
            {
                return NotFound();
            }

            return Ok(Order);
        }

        [HttpPost]
        public async Task<ActionResult<OrderDetailResponseDto>> AddOrder(OrderDetailRequestDto Order)
        {
            var addedOrder = await _orderdetailsService.AddOrderDetailsAsync(Order);
            return CreatedAtAction(nameof(GetOrder), new { id = addedOrder.OrderDetailId }, addedOrder);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<OrderDetailResponseDto>> UpdateOrder(int id, OrderDetailRequestDto Order)
        {
            if (id != Order.OrderDetailId)
            {
                return BadRequest();
            }

            var updatedOrder = await _orderdetailsService.UpdateOrderDetailsAsync(Order);
            return Ok(updatedOrder);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrder(int id)
        {
            try
            {
                await _orderdetailsService.DeleteOrderDetailsAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}