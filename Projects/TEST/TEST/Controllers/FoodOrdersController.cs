using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using TEST;
using TEST.Repository;
using TEST.Interfaces;
using TEST.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace TEST.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoodOrdersController : Controller
    {
        private readonly IFoodOrdersRepository foodordersRepo;

        public FoodOrdersController(IFoodOrdersRepository foodordersRepo)
        {
            this.foodordersRepo = foodordersRepo;
        }

        [HttpGet(Name = "foodorders")]
        public async Task<IActionResult> GetFoodOrders()
        {
            try
            {
                var foodorder = await foodordersRepo.GetFoodOrders();
                return Ok(foodorder);
            }
            catch
            {
                return Problem();
            }
        }


        [HttpPost("add")]
        public async Task<IActionResult> AddOrder(FoodOrderModel foodorders)
        {
            try
            {
                var foodorder = await foodordersRepo.AddOrder(foodorders);
                return Ok();
            }
            catch
            {
                return Problem();
            }
        }

        [HttpPost("cancel/{id}", Name = "CancelOrder")]
        public async Task<IActionResult> CancelOrder(int id)
        {
            try
            {
                var allOrders = await foodordersRepo.GetFoodOrders();

                var existingOrder = allOrders.FirstOrDefault(order => order.Food_order_id == id);
                if (existingOrder == null)
                {
                    return NotFound();
                }

                var canceledOrder = await foodordersRepo.CancelOrder(id);
                return Ok(canceledOrder);
            }
            catch
            {
                return Problem();
            }
        }

        [HttpPost("setDriver/{id}", Name = "SetDriver")]
        [Authorize(Roles = "Admin,Driver")]
        public async Task<IActionResult> SetDriver(int id, int driver_id)
        {
            try
            {
                var allOrders = await foodordersRepo.GetFoodOrders();

                var existingOrder = allOrders.FirstOrDefault(order => order.Food_order_id == id);
                if (existingOrder == null)
                {
                    return NotFound();
                }

                var canceledOrder = await foodordersRepo.SetDriver(id, driver_id);
                return Ok(canceledOrder);
            }
            catch
            {
                return Problem();
            }
        }




    }
}
