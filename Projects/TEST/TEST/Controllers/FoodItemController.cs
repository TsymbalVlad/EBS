using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using TEST;
using TEST.Repository;
using TEST.Interfaces;
using TEST.Models;

namespace TEST.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoodItemController : Controller
    {
        private readonly IFoodItemRepository fooditemRepo;

        public FoodItemController(IFoodItemRepository fooditemRepo)
        {
            this.fooditemRepo = fooditemRepo;
        }

        [HttpGet(Name = "fooditems")]
        public async Task<IActionResult> GetFoodItems()
        {
            try
            {
                var fooditem = await fooditemRepo.GetFoodItems();
                return Ok(fooditem);
            }
            catch
            {
                return Problem();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFoodItemByCategoryId(int id)
        {
            try
            {
                var fooditem = await fooditemRepo.GetFoodItemByCategoryId(id);
                return Ok(fooditem);
            }
            catch
            {
                return Problem();
            }
        }

        [HttpGet("search", Name = "Search")]
        public async Task<IActionResult> SearchFoodItems(string query)
        {
            try
            {
                var fooditem = await fooditemRepo.SearchFoodItems(query);
                return Ok(fooditem);
            }
            catch
            {
                return Problem();
            }
        }

        [HttpPut("edit/{id}", Name = "EditFoodItem")]
        public async Task<IActionResult> EditFoodItem(int id, [FromBody] FoodItemData foodItem)
        {
            try
            {
                var fooditem = await fooditemRepo.EditFoodItem(id, foodItem);
                return Ok();
            }
            catch
            {
                return Problem();
            }
        }

    }
}
