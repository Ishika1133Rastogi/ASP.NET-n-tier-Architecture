using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderProducts.Bll.Services.Interface;
using OrderProducts.Domain.DTOs.RequestDto;
using OrderProducts.Domain.DTOs.ResponseDto;


namespace WebAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper mapper;

        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
              _customerService = customerService;
            this.mapper = mapper;
            
        }

        [HttpGet]
        public async Task<ActionResult<List<CustomerResponseDto>>> GetCustomers()
        {
            try
            {
                var Customers = await _customerService.GetAllCustomersAsync();
                return Ok(Customers);
            }
            catch(Exception ex)
            {
                return BadRequest($"Something went wrong : {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerResponseDto>> GetCustomer(int id)
        {
            try
            {
                return Ok( await _customerService.GetCustomerByIdAsync(id));
            }
           catch(Exception ex)
            {
                return BadRequest($"Something went wrong : {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<CustomerResponseDto>> AddCustomer(CustomerRequestDto customer)
        {
            try
            {
                var addedCustomer = await _customerService.AddCustomerAsync(customer);
                return Ok(CreatedAtAction(nameof(GetCustomer), new { id = addedCustomer.CustomerId }, addedCustomer));
            }
            catch(Exception ex)
            {
                return BadRequest($"Something went wrong : {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CustomerResponseDto>> UpdateCustomer(int id, CustomerRequestDto Customer)
        {
            if (id != Customer.CustomerId)
            {
                return BadRequest();
            }

            try
            {
                var updatedCustomer = await _customerService.UpdateCustomerAsync(Customer);
                return Ok(updatedCustomer);
            }
            catch (Exception ex)
            {
                return BadRequest($"Something went wrong : {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCustomer(int id)
        {
            try
            {
                await _customerService.DeleteCustomerAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Something went wrong : {ex.Message}");
            }            
            
        }
    }
}
        

