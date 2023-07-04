using TEST.Interfaces;
using TEST.Models;
using Microsoft.AspNetCore.Mvc;
using TEST.Data;
using Dapper;
using Azure.Identity;

namespace TEST.Repository
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly DapperContext ctx;

        public RestaurantRepository(DapperContext ctx)
        {
            this.ctx = ctx;
        }

        public async Task<IEnumerable<RestaurantModel>> GetRestaurants()
        {
            string query = @"Select * From Restaurant";

            using var connection = ctx.CreateConnection();

            var restaurant = await connection.QueryAsync<RestaurantModel>(query);
            return restaurant;

        }

        public async Task<IEnumerable<RestaurantModel>> AddRestaurant(RestaurantModel restaurant)
        {
            string query = "INSERT INTO Restaurant (restaurant_id, restaurant_name, adress_id) VALUES (@restaurant_id, @restaurant_name, @adress_id)";
            using var connection = ctx.CreateConnection();

            await connection.ExecuteAsync(query, restaurant);

            query = "SELECT * FROM Restaurant WHERE restaurant_id = @restaurant_id";

            var insert = await connection.QueryAsync<RestaurantModel>(query, restaurant);
            return insert;
        }

        public async Task<IEnumerable<RestaurantModel>> GetRestaurantById(int id)
        {
            string query = $"Select * From Restaurant Where restaurant_id = {id}";
            using var connection = ctx.CreateConnection();

            var restaurant = await connection.QueryAsync<RestaurantModel>(query);
            return restaurant;
        }
        public async Task<IEnumerable<RestaurantData>> EditRestaurant(int id, [FromBody] RestaurantData restaurantData)
        {
            using var connection = ctx.CreateConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@restaurant_name", restaurantData.restaurant_name);
            parameters.Add("@adress_id", restaurantData.adress_id);
            parameters.Add("@id", id);

            string query = @"UPDATE Restaurant SET
                      restaurant_name = @restaurant_name,
                      adress_id = @adress_id
                      WHERE restaurant_id = @id";

            var restaurant = await connection.QueryAsync<RestaurantData>(query, parameters);
            return restaurant;
        }

        public async Task<IEnumerable<Menu>> GetMenu(int id)
        {
            string query = $"Select * From Menu WHere restaurant_id = {id}";
            using var connection = ctx.CreateConnection();

            var menu = await connection.QueryAsync<Menu>(query);
            return menu;
        }


    }
}

