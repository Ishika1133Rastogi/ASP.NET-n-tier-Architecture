
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OrderProducts.Dal.Data;
using OrderProducts.Dal.Repositories.Interface;
using OrderProducts.Domain.DTOs;
using OrderProducts.Domain.DTOs.ResponseDto;
using OrderProducts.Domain.Entities;


namespace OrderProducts.Dal.Repositories
{

    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper _mapper;
        public OrderRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext)
        {
            this.dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<OrderDetailResponseDto>> GetOrdersByCustomerId(int orderId)
        {
            var orders = await dbContext.OrderDetails
                .Where(o => o.OrderId == orderId)
                .ToListAsync();

            return _mapper.Map<List<OrderDetailResponseDto>>(orders);
        }

        public async Task<int> GetOrderCountByCustomerId(int customerId)
        {
            var orders =  await dbContext.Orders
            .Where(o => o.CustomerId == customerId)
            .CountAsync();
            return orders;
        }

        

        //public async Task<List<OrderDetailDto>> GetOrderdetailsByOrderId(int orderdetailId)
        //{
        //    var orderdetails = await dbContext.OrderDetails
        //            .Where(o => o.OrderDetailId == orderdetailId)  // Corrected the property name to OrderId
        //            .ToListAsync();

        //        return _mapper.Map<List<OrderDetailDto>>(orderdetails);
        //    }



    }
}
/*public class OrderRepository : IGenericRepository<Order>
    {
            private readonly ApplicationDbContext dbContext;

            public OrderRepository(ApplicationDbContext dbContext)
            {
                this.dbContext = dbContext;

            }

            public async Task<Order> AddAsync(Order order)
            {
                dbContext.Orders.AddAsync(order);
                await dbContext.SaveChangesAsync();
                return order;
            }

            public async Task<bool> DeleteAsync(int id)
            {
                var order_var = await dbContext.Orders.FindAsync(id);
                if (order_var == null)
                {
                    return false;
                }

                dbContext.Orders.Remove(order_var);
                await dbContext.SaveChangesAsync();
                return true;
            }

            public async Task<List<Order>> GetAsync()
            {
                return await dbContext.Orders.ToListAsync();
            }


            public async Task<Order> GetByIdAsync(int id)
            {
                return await dbContext.Orders.FindAsync(id);
            }


            public async Task<Order> UpdateAsync(Order order)
            {
                dbContext.Update(order);
                await dbContext.SaveChangesAsync();
                return order;

            }
        }
}
*/