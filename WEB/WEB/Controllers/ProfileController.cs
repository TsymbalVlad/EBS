using Microsoft.AspNetCore.Mvc;

namespace WEB.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
