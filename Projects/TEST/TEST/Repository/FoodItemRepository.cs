using TEST.Interfaces;
using TEST.Models;
using Microsoft.AspNetCore.Mvc;
using TEST.Data;
using Dapper;
using Azure.Identity;
using System.Net.Http.Headers;

namespace TEST.Repository
{
    public class FoodItemRepository : IFoodItemRepository
    {
        private readonly DapperContext ctx;

        public FoodItemRepository(DapperContext ctx)
        {
            this.ctx = ctx;
        }

        public async Task<IEnumerable<FoodItemModel>> GetFoodItems()
        {
            string query = @"Select * From Fooditem";

            using var connection = ctx.CreateConnection();

            var fooditem = await connection.QueryAsync<FoodItemModel>(query);
            return fooditem;

        }

        public async Task<IEnumerable<FoodItemModel>> GetFoodItemByCategoryId(int id)
        {
            string query = $"Select * From Fooditem Where category_id = {id}";

            using var connection = ctx.CreateConnection();

            var fooditem = await connection.QueryAsync<FoodItemModel>(query);
            return fooditem;
        }

        public async Task<IEnumerable<FoodItemModel>> SearchFoodItems(string query)
        {
            string sqlquery = "SELECT * FROM Fooditem WHERE item_name LIKE '%' + @Query + '%'";
            var parameters = new { Query = query };

            using var connection = ctx.CreateConnection();
            var fooditem = await connection.QueryAsync<FoodItemModel>(sqlquery, parameters);
            return fooditem;
        }

        public async Task<IEnumerable<FoodItemData>> EditFoodItem(int id, [FromBody] FoodItemData foodItem)
        {
            string query = $"SELECT * FROM Fooditem WHERE item_id = {id}";
            using var connection = ctx.CreateConnection();

            FoodItemData existingAddress = connection.QueryFirstOrDefault<FoodItemData>(query);

            existingAddress.item_name = foodItem.item_name;
            existingAddress.item_price = foodItem.item_price;
            existingAddress.category_id = foodItem.category_id;

            query = $@"UPDATE Fooditem SET item_name = @item_name, item_price = @item_price, category_id = @category_id
                  WHERE item_id = {id}";

            var parameters = new DynamicParameters();
            parameters.Add("@item_name", existingAddress.item_name);
            parameters.Add("@item_price", existingAddress.item_price);
            parameters.Add("@category_id", existingAddress.category_id);

            var food = await connection.QueryAsync<FoodItemData>(query, parameters);
            return food;
        }


    }
}

