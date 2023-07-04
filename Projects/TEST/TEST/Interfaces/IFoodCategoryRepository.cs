using Microsoft.AspNetCore.Mvc;
using TEST.Models;

namespace TEST.Interfaces
{
    public interface IFoodCategoryRepository
    {
        Task<IEnumerable<FoodCategoryModel>> GetFoodCategory();
        Task<IEnumerable<FoodCategoryModel>> GetFoodcategoryByRestaurantId(int id);
        Task<IEnumerable<FoodCategoryData>> AddFoodCategory(int id, [FromBody] FoodCategoryData newcategory);
        Task<IEnumerable<FoodCategoryModel>> EditFoodCategory(int id, [FromBody] string foodName);

    }
}
