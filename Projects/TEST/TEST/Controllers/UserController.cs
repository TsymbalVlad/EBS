using Test.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TEST.Models;
using TEST.Interfaces;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]

    public class UserController : ControllerBase
    {

        private readonly IUserRepository userRepo;

        public UserController(IUserRepository userRepo)
        {
            this.userRepo = userRepo;
        }

        [HttpGet("Admins")]
        public IActionResult AdminsEndpoint()
        {
            var currentUser = GetCurrentUser();
            return Ok(currentUser);
        }

        private UserModel? GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                var userClaims = identity.Claims;

                return new UserModel
                {
                    users_id = int.Parse(userClaims.FirstOrDefault(x => x.Type == "user_id")?.Value),
                    email = userClaims.FirstOrDefault(x => x.Type == "email")?.Value,
                    u_firstname = userClaims.FirstOrDefault(x => x.Type == "u_firstname")?.Value,
                    u_lastname = userClaims.FirstOrDefault(x => x.Type == "u_lastname")?.Value,
                    role_id = int.Parse(userClaims.FirstOrDefault(x => x.Type == "role_id")?.Value),
                    rolename = userClaims.FirstOrDefault(x => x.Type == "rolename")?.Value
                };
            }

            return null;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddUser(UserData user)
        {
            try
            {
                var users = await userRepo.AddUser(user);
                return Ok();
            }
            catch
            {
                return Problem();
            }
        }
    }
}
