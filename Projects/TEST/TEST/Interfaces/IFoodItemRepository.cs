using Microsoft.AspNetCore.Mvc;
using TEST.Models;

namespace TEST.Interfaces
{
    public interface IFoodItemRepository
    {
        Task<IEnumerable<FoodItemModel>> GetFoodItems();
        Task<IEnumerable<FoodItemModel>> GetFoodItemByCategoryId(int id);
        Task<IEnumerable<FoodItemModel>> SearchFoodItems(string query);
        Task<IEnumerable<FoodItemData>> EditFoodItem(int id, [FromBody] FoodItemData foodItem);
    }
}
