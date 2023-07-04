using Microsoft.AspNetCore.Mvc;
using TEST.Models;

namespace TEST.Interfaces
{
    public interface ICustomersRepository
    {
        Task<IEnumerable<CustomersModel>> GetCustomers();
        Task<IEnumerable<CustomersModel>> AddCustomer(CustomersModel customers);
        Task<IEnumerable<CustomersData>> EditCustomers(int id, [FromBody] CustomersData customersData);
        Task<IEnumerable<CustomersModel>> GetCustomerById(int id);
    }
}
