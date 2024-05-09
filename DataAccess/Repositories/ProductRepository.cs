
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OrderProducts.Dal.Data;
using OrderProducts.Dal.Repositories.Interface;
using OrderProducts.Domain.DTOs.ResponseDto;
using OrderProducts.Domain.Entities;


namespace OrderProducts.Dal.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper _mapper;
        public ProductRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext)
        {
            this.dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<OrderDetailResponseDto>> GetOrdersdetailsByProductId(int productId)
        {
            var orders = await dbContext.OrderDetails
                .Where(o => o.ProductId == productId)
                .ToListAsync();
             
            return _mapper.Map<List<OrderDetailResponseDto>>(orders);
        }

        public async Task<List<CustomerResponseDto>> GetCustomersByProductIdAsync(int productId)
        {
            return await dbContext.Orders
                .Where(o => o.OrderDetail.Any(od => od.ProductId == productId))
                .Select(o => new CustomerResponseDto
                {
                    CustomerId = o.CustomerId,
                    CustomerName = o.Customers.CustomerName,
                    CustomerAddress = o.Customers.CustomerAddress,
                    TaxIdentifier = o.Customers.TaxIdentifier
               })
                .Distinct()
                .ToListAsync();
        }


    }
}
/*public class ProductRepository : IGenericRepository<Product>
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _dbContext.Products.FindAsync(id);
        }

        public async Task<List<Product>> GetAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<Product> AddAsync(Product product)
        {
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            _dbContext.Entry(product).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return product;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _dbContext.Products.FindAsync(id);
            if (product == null)
            {
                return false;
            }

            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
   */
