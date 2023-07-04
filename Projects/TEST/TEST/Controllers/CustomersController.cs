using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using TEST;
using TEST.Repository;
using TEST.Interfaces;
using TEST.Models;

namespace TEST.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private readonly ICustomersRepository customerRepo;

        public CustomersController(ICustomersRepository customerRepo)
        {
            this.customerRepo = customerRepo;
        }

        [HttpGet(Name = "customers")]
        public async Task<IActionResult> GetCustomers()
        {
            try
            {
                var customer = await customerRepo.GetCustomers();
                return Ok(customer);
            }
            catch
            {
                return Problem();
            }
        }
        
        [HttpPost("add")]
        public async Task<IActionResult> AddCustomer(CustomersModel customers)
        {
            try
            {
                var customer = await customerRepo.AddCustomer(customers);
                    return Ok();
            }
            catch
            {
                return Problem();
            }
        }

        [HttpPut("edit/{id}", Name = "EditCustomers")]
        public async Task<IActionResult> EditCustomers(int id, [FromBody] CustomersData customersData)
        {
            try
            {
                var customer = await customerRepo.EditCustomers(id, customersData);
                return Ok();
            }
            catch
            {
                return Problem();
            }
        }

        [HttpGet("{id}", Name = "GetCustomerById")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            try
            {
                var customer = await customerRepo.GetCustomerById(id);
                return Ok(customer);
            }
            catch
            {
                return Problem();
            }
        }

    }
}
