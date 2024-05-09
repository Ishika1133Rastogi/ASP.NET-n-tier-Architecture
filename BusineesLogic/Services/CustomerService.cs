using AutoMapper;
using OrderProducts.Bll.Services.Interface;
using OrderProducts.Dal.Repositories;
using OrderProducts.Dal.Repositories.Interface;
using OrderProducts.Domain.DTOs;
using OrderProducts.Domain.DTOs.RequestDto;
using OrderProducts.Domain.DTOs.ResponseDto;
using OrderProducts.Domain.Entities;



namespace OrderProducts.Bll.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<List<CustomerResponseDto>> GetAllCustomersAsync()
        {
            var customers = await _customerRepository.GetAsync();
            var customerDtos = _mapper.Map<List<CustomerResponseDto>>(customers);

            foreach (var customer in customerDtos)
            {
                var orders = await _customerRepository.GetOrderByCustomerId(customer.CustomerId);
                customer.Order = _mapper.Map<List<OrderResponseDto>>(orders);
            }
            
            return customerDtos;
        }

        public async Task<CustomerResponseDto> GetCustomerByIdAsync(int id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            return _mapper.Map<CustomerResponseDto>(customer);
        }

        public async Task<CustomerResponseDto> AddCustomerAsync(CustomerRequestDto customer)
        {
            var entity = _mapper.Map<Customer>(customer);
            var addedCustomer = await _customerRepository.AddAsync(entity);
            return _mapper.Map<CustomerResponseDto>(addedCustomer);
        }

        public async Task<CustomerResponseDto> UpdateCustomerAsync(CustomerRequestDto customer)
        {
            var entity = _mapper.Map<Customer>(customer);
            var updatedCustomer = await _customerRepository.UpdateAsync(entity);
            return _mapper.Map<CustomerResponseDto>(updatedCustomer);
        }

        public async Task DeleteCustomerAsync(int id)
        {
            await _customerRepository.DeleteAsync(id);
        }

       
    }
}
//    public class CustomerService : ICustomerService
//    {
//        private readonly ICustomerRepository _CustomerRepository;

//        public CustomerService(ICustomerRepository CustomerRepository)
//        {
//            _CustomerRepository = CustomerRepository;
//        }

//        public async Task<List<CustomerDto>> GetAllCustomersAsync()
//        {
//            var customer =  await _CustomerRepository.GetAsync();
//            return customer.ConvertAll(customer => customer.ToDto());
//        }

//        public async Task<CustomerDto> GetCustomerByIdAsync(int id)
//        {
//            var customer =  await _CustomerRepository.GetByIdAsync(id);
//            if(customer == null)
//            {
//                return null;
//            }
//            return customer.ToDto();

//        }

//        public async Task<CustomerDto> AddCustomerAsync(CustomerDto Customer)
//        {
//            var customer = Customer.ToEntity();
//            var addedCustomer = await _CustomerRepository.AddAsync(customer);
//            return addedCustomer.ToDto();
//        }

//        public async Task<CustomerDto> UpdateCustomerAsync(CustomerDto Customer)
//        {
//            var customer = Customer.ToEntity();
//            var updatedCustomer = await _CustomerRepository.UpdateAsync(customer);
//            return updatedCustomer.ToDto();
//        }

//            public async Task DeleteCustomerAsync(int id)
//        {
//             await _CustomerRepository.DeleteAsync(id);
//        }       
//    }
//}




