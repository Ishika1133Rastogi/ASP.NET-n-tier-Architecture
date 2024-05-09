using Microsoft.AspNetCore.Mvc;
using OrderProducts.Bll.Services.Interface;
using OrderProducts.Domain.DTOs.RequestDto;
using OrderProducts.Domain.DTOs.ResponseDto;


namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductResponseDto>>> GetProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductResponseDto>> GetProduct(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpGet("{id}/customers")]
        public async Task<ActionResult<List<CustomerResponseDto>>> GetCustomersByProductId(int productId)
        {
            var customers = await _productService.GetCustomersByProductIdAsync(productId);
            return Ok(customers);
        }

        [HttpPost]
        public async Task<ActionResult<ProductResponseDto>> AddProduct(ProductRequestDto productDto)
        {
            var addedProduct = await _productService.AddProductAsync(productDto);
            return CreatedAtAction(nameof(GetProduct), new { id = addedProduct.ProductId }, addedProduct);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductResponseDto>> UpdateProduct(int id, ProductRequestDto productDto)
        {
            if (id != productDto.ProductId)
            {
                return BadRequest();
            }

            var updatedProduct = await _productService.UpdateProductAsync(productDto);
            return Ok(updatedProduct);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            try
            {
                await _productService.DeleteProductAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Something went wrong : {ex.Message}");
            }
        }
    }

}