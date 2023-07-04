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
    public class RestaurantController : Controller
    {
        private readonly IRestaurantRepository restaurantRepo;

        public RestaurantController(IRestaurantRepository restaurantRepo)
        {
            this.restaurantRepo = restaurantRepo;
        }

        [HttpGet(Name = "restaurants")]
        public async Task<IActionResult> GetRestaurants()
        {
            try
            {
                var restaurant = await restaurantRepo.GetRestaurants();
                return Ok(restaurant);
            }
            catch
            {
                return Problem();
            }

        }

        [HttpPost("add")]
        public async Task<IActionResult> AddRestaurant(RestaurantModel restaurants)
        {
            try
            {
                var restaurant = await restaurantRepo.AddRestaurant(restaurants);
                return Ok();
            }
            catch
            {
                return Problem();
            }
        }

        [HttpGet("{id}", Name = "GetRestaurantById")]
        public async Task<IActionResult> GetRestaurantById(int id)
        {
            try
            {
                var restaurant = await restaurantRepo.GetRestaurantById(id);
                return Ok(restaurant);
            }
            catch
            {
                return Problem();
            }
        }

        [HttpPut("edit/{id}", Name = "EditRestaurant")]
        public async Task<IActionResult> EditRestaurant(int id, [FromBody] RestaurantData restaurantData)
        {
            try
            {
                var restaurant = await restaurantRepo.EditRestaurant(id, restaurantData);
                return Ok();
            }
            catch
            {
                return Problem();
            }
        }

        [HttpGet("menu/{id}", Name = "GetMenu")]
        public async Task<IActionResult> GetMenu(int id)
        {
            try
            {
                var menu = await restaurantRepo.GetMenu(id);
                return Ok(menu);
            }
            catch
            {
                return Problem();
            }
        }

    }
}
