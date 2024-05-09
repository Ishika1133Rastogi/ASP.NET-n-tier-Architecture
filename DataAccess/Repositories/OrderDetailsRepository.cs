
using OrderProducts.Dal.Data;
using OrderProducts.Dal.Repositories.Interface;
using OrderProducts.Domain.Entities;

 
namespace OrderProducts.Dal.Repositories
{
    public class OrderDetailsRepository : GenericRepository<OrderDetails>, IOrderDetailsRepository
    {
        private readonly ApplicationDbContext dbContext;
        public OrderDetailsRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;

        }
    }
}

    