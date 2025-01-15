using Microsoft.AspNetCore.Mvc;
using ThreeLayerArchitecture.BLL.Services;
using ThreeLayerArchitecture.Common.DTOs;

namespace ThreeLayerArchitecture.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly CustomerService _customerService;

        public CustomersController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = _customerService.GetAllCustomers();
            return Ok(customers);
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer([FromBody] CustomerDTO customerDto)
        {
            _customerService.AddCustomer(customerDto.Name, customerDto.Email);
            return Ok();
        }
    }

}
