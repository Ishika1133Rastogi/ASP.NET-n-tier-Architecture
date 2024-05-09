using AutoMapper;
using OrderProducts.Domain.DTOs.RequestDto;
using OrderProducts.Domain.DTOs.ResponseDto;
using OrderProducts.Domain.Entities;


namespace OrderProducts.Bll
{

    // Create a mapping profile for your mappings.
    
    public  class MappingExtensions :Profile
    {

        public MappingExtensions() 
        {
            CreateMap<CustomerRequestDto, Customer>();
            CreateMap<Customer, CustomerResponseDto>();
            CreateMap<OrderRequestDto, Order>();
            CreateMap<Order, OrderResponseDto>();
            CreateMap<OrderDetailRequestDto, OrderDetails>();
            CreateMap<OrderDetails, OrderDetailResponseDto>();
            CreateMap<ProductRequestDto, Product>();
            CreateMap<Product, ProductResponseDto>();
            //CreateMap<Order , OrderDto>().ReverseMap(); ;
            //CreateMap<Product , ProductDto>().ReverseMap();
            ////CreateMap<Customer , CustomerDto>().ReverseMap();
            //CreateMap<OrderDetails, OrderDetailDto>().ReverseMap();
        }
        
        //public static OrderDto ToDto(this Order order)
        //{
        //    return new OrderDto
        //    {
        //        OrderId = order.OrderId,
        //      // CustomerId = order.CustomerId,
        //        OrderDate = order.OrderDate,
        //        OrederAmount = order.OrederAmount,
        //        Comments = order.Comments
        //    };
        //}

        //public static Order ToEntity(this OrderDto orderDto)
        //{
        //    return new Order
        //    {
        //        OrderId = orderDto.OrderId,
        //       // CustomerId = orderDto.CustomerId,
        //        OrderDate = orderDto.OrderDate,
        //        OrederAmount = orderDto.OrederAmount,
        //        Comments = orderDto.Comments
        //    };
        //}

        //public static ProductDto ToDto(this Product product)
        //{
        //    return new ProductDto
        //    {
        //        ProductId = product.ProductId,
        //        ProductCode = product.ProductCode,
        //        ProductName = product.ProductName,
        //        ProductDescription = product.ProductDescription,
        //        ProductPrice = product.ProductPrice
        //    };
        //}

        //public static Product ToEntity(this ProductDto productDto)
        //{
        //    return new Product
        //    {
        //        ProductId = productDto.ProductId,
        //        ProductCode = productDto.ProductCode,
        //        ProductName = productDto.ProductName,
        //        ProductDescription = productDto.ProductDescription,
        //        ProductPrice = productDto.ProductPrice
        //    };
        //}

        //public static OrderDetailDto ToDto(this OrderDetails orderDetails)
        //{
        //    return new OrderDetailDto
        //    {
        //      //  OrderDetailId = orderDetails.OrderDetailId,
        //        OrderId = orderDetails.OrderId,
        //        ProductId = orderDetails.ProductId,
        //        Quantity = orderDetails.Quantity
        //    };
        //}

        //public static OrderDetails ToEntity(this OrderDetailDto orderDetailsDto)
        //{
        //    return new OrderDetails
        //    {
        //      //  OrderDetailId = orderDetailsDto.OrderDetailId,
        //        OrderId = orderDetailsDto.OrderId,
        //        ProductId = orderDetailsDto.ProductId,
        //        Quantity = orderDetailsDto.Quantity
        //    };
        //}

        //public static CustomerDto ToDto(this Customer customer)
        //{
        //    return new CustomerDto
        //    {
        //        CustomerId = customer.CustomerId,
        //        CustomerName = customer.CustomerName,
        //        CustomerAddress = customer.CustomerAddress,
        //        TaxIdentifier = customer.TaxIdentifier
        //    };
        //}

        //public static Customer ToEntity(this CustomerDto customerDto)
        //{
        //    return new Customer
        //    {
        //        CustomerId = customerDto.CustomerId,
        //        CustomerName = customerDto.CustomerName,
        //        CustomerAddress = customerDto.CustomerAddress,
        //        TaxIdentifier = customerDto.TaxIdentifier
        //    };
        //}
    }
   
}


  

