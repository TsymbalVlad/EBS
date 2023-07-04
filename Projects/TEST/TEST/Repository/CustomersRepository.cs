using TEST.Interfaces;
using TEST.Models;
using Microsoft.AspNetCore.Mvc;
using TEST.Data;
using Dapper;
using Azure.Identity;

namespace TEST.Repository
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly DapperContext ctx;

        public CustomersRepository(DapperContext ctx)
        {
            this.ctx = ctx;
        }

        public async Task<IEnumerable<CustomersModel>> GetCustomers()
        {
            string query = @"SELECT * FROM Customer";

            using var connection = ctx.CreateConnection();

            var customer = await connection.QueryAsync<CustomersModel>(query);
            return customer;

        }

        public async Task<IEnumerable<CustomersModel>> AddCustomer(CustomersModel customers)
        {
            string query = "INSERT INTO Customer VALUES (@customer_id, @c_firstname, @c_lastname)";
            using var connection = ctx.CreateConnection();

            var customer = await connection.QueryAsync<CustomersModel>(query, customers);
           return customer;
        }

        public async Task<IEnumerable<CustomersData>> EditCustomers(int id, [FromBody] CustomersData customersData)
        {
                using var connection = ctx.CreateConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@c_firstname", customersData.c_firstname);
            parameters.Add("@c_lastname", customersData.c_lastname);
            parameters.Add("@id", id);

            string query = @"UPDATE Customer SET
                          c_firstname = @c_firstname,
                          c_lastname = @c_lastname
                          Where customer_id = @id";

                var customer = await connection.QueryAsync<CustomersData>(query, parameters);
                return customer;
        }

        
        public async Task<IEnumerable<CustomersModel>> GetCustomerById(int id)
        {
            string query = $"SELECT * FROM Customer Where customer_id = {id}";
            using var connection = ctx.CreateConnection();

            var customer = await connection.QueryAsync<CustomersModel>(query);
            return customer;
        }
    }
    
}

