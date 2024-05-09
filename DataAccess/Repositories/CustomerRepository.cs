using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OrderProducts.Dal.Data;
using OrderProducts.Dal.Repositories.Interface;
using OrderProducts.Domain.DTOs.ResponseDto;
using OrderProducts.Domain.Entities;



namespace OrderProducts.Dal.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository 
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper _mapper;
        public CustomerRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext)
        {
            this.dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<OrderResponseDto>> GetCountOrdersByCustomerId(int customerId)
        {
            var orders = await dbContext.Orders
                 .Where(o => o.CustomerId == customerId)
                 .CountAsync();
            return _mapper.Map<List<OrderResponseDto>>(orders);
        }
        public async Task<List<OrderResponseDto>> GetOrderByCustomerId(int customerId)
        {
            var orders = await dbContext.Orders
                .Where(o => o.CustomerId == customerId)
                .Include(o => o.OrderDetail)
                .ToListAsync();

            return _mapper.Map<List<OrderResponseDto>>(orders);

        }
    }
}
