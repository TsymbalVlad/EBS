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

    public class AdressController : Controller
    {
        private readonly IAdressRepository adressRepo;

        public AdressController(IAdressRepository adressRepo)
        {
            this.adressRepo = adressRepo;
        }

        [HttpGet(Name = "adresses")]
        public async Task<IActionResult> GetAdresses()
        {
            try
            {
                var adress = await adressRepo.GetAdresses();
                return Ok(adress);
            }
            catch
            {
                return Problem();
            }
        }


        [HttpPut("edit/{id}", Name = "EditAdress")]
        public async Task<IActionResult> EditAdress(int id, [FromBody] AdressModel addressData)
        {
            try
            {
                var updatedAdress = await adressRepo.EditAdress(id, addressData);
                return Ok();
            }
            catch
            {
                return NotFound("FAILED");
            }
        }

        [HttpGet("{id}", Name = "GetAdressByID")]
        public async Task<IActionResult> GetAdressByID(int id)
        {
            try
            {
                var adress = await adressRepo.GetAdressByID(id);
                return Ok(adress);
            }
            catch
            {
                return Problem();
            }
        }

    }
}
