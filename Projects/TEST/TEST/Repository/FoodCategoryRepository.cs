using TEST.Interfaces;
using TEST.Models;
using Microsoft.AspNetCore.Mvc;
using TEST.Data;
using Dapper;
using Azure.Identity;
using System.Net.Http.Headers;

namespace TEST.Repository
{
    public class FoodCategoryRepository : IFoodCategoryRepository
    {
        private readonly DapperContext ctx;

        public FoodCategoryRepository(DapperContext ctx)
        {
            this.ctx = ctx;
        }

        public async Task<IEnumerable<FoodCategoryModel>> GetFoodCategory()
        {
            string query = @"Select * From FoodCategory";

            using var connection = ctx.CreateConnection();

            var foodcategory = await connection.QueryAsync<FoodCategoryModel>(query);
            return foodcategory;

        }

        public async Task<IEnumerable<FoodCategoryModel>> GetFoodcategoryByRestaurantId(int id)
        {
            string query = $@"Select * From FoodCategory Where restaurant_id = {id}";

            using var connection = ctx.CreateConnection();

            var foodcategory = await connection.QueryAsync<FoodCategoryModel>(query);
            return foodcategory;
        }

        public async Task<IEnumerable<FoodCategoryData>> AddFoodCategory(int id, [FromBody] FoodCategoryData newcategory)
        {
            string query = $"INSERT INTO FoodCategory VALUES (@category_id, @food_name, {id})";
            using var connection = ctx.CreateConnection();

            var foodcategory = await connection.QueryAsync<FoodCategoryData>(query, newcategory);
            return foodcategory;
        }

        public async Task<IEnumerable<FoodCategoryModel>> EditFoodCategory(int id, [FromBody] string foodName)
        {
            string query = $"UPDATE FoodCategory SET food_name = '{foodName}' WHERE category_id = {id}";
            using var connection = ctx.CreateConnection();

            var foodcategory = await connection.QueryAsync<FoodCategoryModel>(query);
            return foodcategory;
        }


    }
}

