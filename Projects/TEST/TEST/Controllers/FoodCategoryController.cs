using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using TEST;
using TEST.Repository;
using TEST.Interfaces;
using TEST.Models;
using Microsoft.AspNetCore.Authorization;

namespace TEST.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoodCategoryController : Controller
    {
        private readonly IFoodCategoryRepository categoryRepo;

        public FoodCategoryController(IFoodCategoryRepository categoryRepo)
        {
            this.categoryRepo = categoryRepo;
        }

        [HttpGet(Name = "foodcategory")]
        public async Task<IActionResult> GetFoodCategory()
        {
            try
            {
                var foodcategory = await categoryRepo.GetFoodCategory();
                return Ok(foodcategory);
            }
            catch
            {
                return Problem();
            }
        }

        [HttpGet("{id}", Name = "GetFoodcategoryByRestaurantId")]
        public async Task<IActionResult> GetFoodcategoryByRestaurantId(int id)
        {
            try
            {
                var foodcategory = await categoryRepo.GetFoodcategoryByRestaurantId(id);
                return Ok(foodcategory);
            }
            catch
            {
                return Problem();
            }
        }

        [HttpPost("add/{id}")]
        [Authorize]
        public async Task<IActionResult> AddFoodCategory(int id, [FromBody] FoodCategoryData newcategory)
        {
            try
            {
                var foodcategory = await categoryRepo.AddFoodCategory(id, newcategory);
                return Ok();
            }
            catch
            {
                return Problem();
            }
        }

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> EditFoodCategory(int id, [FromBody] string foodName)
        {
            try
            {
                var foodcategory = await categoryRepo.EditFoodCategory(id, foodName);
                return Ok();
            }
            catch
            {
                return Problem();
            }
        }
    }
}
