using Microsoft.AspNetCore.Mvc;
using TEST.Models;

namespace TEST.Interfaces
{
    public interface IFoodOrdersRepository
    {
        Task<IEnumerable<FoodOrderModel>> GetFoodOrders();
        Task<IEnumerable<FoodOrderModel>> AddOrder(FoodOrderModel order);
        Task<IEnumerable<FoodOrderModel>> CancelOrder(int id);
        Task<IEnumerable<FoodOrderModel>> SetDriver(int id, int driver_id);
    }
}
