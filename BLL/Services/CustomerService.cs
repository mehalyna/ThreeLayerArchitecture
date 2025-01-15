using ThreeLayerArchitecture.DAL.Repositories;

namespace ThreeLayerArchitecture.BLL.Services
{
    public class CustomerService
    {
        private readonly CustomerRepositoryDapper _customerRepository;

        public CustomerService(CustomerRepositoryDapper customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public IEnumerable<Common.DTOs.CustomerDTO> GetAllCustomers()
        {
            var customers = _customerRepository.GetAllCustomers();
            return customers.Select(c => new Common.DTOs.CustomerDTO
            {
                CustomerId = c.CustomerId,
                Name = c.Name,
                Email = c.Email
            });
        }

        public void AddCustomer(string name, string email)
        {
            _customerRepository.AddCustomer(name, email);
        }
    }
}
