using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WEB.Entity;
using WEB.Models;
using System.Security.Claims;

namespace WEB.Controllers
{
    public class CarController : Controller
    {
        private readonly AppDBContext _context;

        public CarController(AppDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Car()
        {
            return View();
        }

        public async Task<IActionResult> Cars()
        {
            var cars = await _context.Set<Cars>().FromSqlRaw("SELECT * FROM CarView").ToListAsync();
            return View(cars);
        }

        public async Task<IActionResult> Rent(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            var rent = await _context.Set<Cars>().FromSqlRaw($"SELECT * FROM CarView Where car_id = {id}").FirstOrDefaultAsync();
            return View(rent);
        }

        public IActionResult PlaceOrder(DateTime startDateTime, DateTime endDateTime, short carId, short price)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var order = new Order
            {
                status_id = 1,
                AppUserId = userId,
                start_day = startDateTime,
                end_day = endDateTime,
                car_id = carId,
                total_price = (endDateTime.Date - startDateTime.Date).Days * price 
            };
           
            _context.Order.Add(order);
            _context.SaveChanges();

            return RedirectToAction("Profile", "Account");
        }
    }
}

