using Microsoft.Extensions.DependencyInjection;
using OrderProducts.Bll.Services.Interface;
using OrderProducts.Bll.Services;


namespace OrderProducts.Bll
{
    public static class ServicesDependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IOrderDetailsService, OrderDetailsService>();

            return services;
        }
    }
}
