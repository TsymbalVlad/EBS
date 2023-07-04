using Microsoft.AspNetCore.Mvc;
using TEST.Models;

namespace TEST.Interfaces
{
    public interface IRestaurantRepository
    {
        Task<IEnumerable<RestaurantModel>> GetRestaurants();
        Task<IEnumerable<RestaurantModel>> AddRestaurant(RestaurantModel restaurant);
        Task<IEnumerable<RestaurantModel>> GetRestaurantById(int id);
        Task<IEnumerable<RestaurantData>> EditRestaurant(int id, [FromBody] RestaurantData restaurantData);
        Task<IEnumerable<Menu>> GetMenu(int id);
    }
}
