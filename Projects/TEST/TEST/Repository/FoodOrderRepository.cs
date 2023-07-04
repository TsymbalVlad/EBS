using TEST.Interfaces;
using TEST.Models;
using Microsoft.AspNetCore.Mvc;
using TEST.Data;
using Dapper;
using Azure.Identity;
using System.Net.Http.Headers;

namespace TEST.Repository
{
    public class FoodOrderRepository : IFoodOrdersRepository
    {
        private readonly DapperContext ctx;

        public FoodOrderRepository(DapperContext ctx)
        {
            this.ctx = ctx;
        }

        public async Task<IEnumerable<FoodOrderModel>> GetFoodOrders()
        {
            string query = @"Select * From Food_order";

            using var connection = ctx.CreateConnection();

            var foodorder = await connection.QueryAsync<FoodOrderModel>(query);
            return foodorder;

        }

        public async Task<IEnumerable<FoodOrderModel>> AddOrder(FoodOrderModel foodorders)
        {
            string query = @"INSERT INTO Food_order 
                    (Food_order_id, customer_id, adress_id, driver_id, status_id, restaurant_id, deliveryfee, totalamount, order_datetime, req_datetime)
                    VALUES
                    (@Food_order_id, @customer_id, @adress_id, @driver_id, @status_id, @restaurant_id, @deliveryfee, @totalamount, @order_datetime, @req_datetime)";

            using var connection = ctx.CreateConnection();

            var affectedRows = await connection.QueryAsync<FoodOrderModel>(query, foodorders);
            return affectedRows;
        }

        public async Task<IEnumerable<FoodOrderModel>> CancelOrder(int id)
        {
            string query = "UPDATE Food_order SET status_id = 4 WHERE Food_order_id = @OrderId";
            var parameters = new { OrderId = id };

            using var connection = ctx.CreateConnection();

            var affectedRows = await connection.QueryAsync<FoodOrderModel>(query, parameters);
            return affectedRows;
        }

        public async Task<IEnumerable<FoodOrderModel>> SetDriver(int id, int driver_id)
        {
            string query = $"UPDATE Food_order SET driver_id = {driver_id}  WHERE Food_order_id = @OrderId";
            var parameters = new { OrderId = id };

            using var connection = ctx.CreateConnection();

            var affectedRows = await connection.QueryAsync<FoodOrderModel>(query, parameters);
            return affectedRows;
        }



    }
}

