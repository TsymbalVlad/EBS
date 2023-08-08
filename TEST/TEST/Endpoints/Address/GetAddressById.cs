using Microsoft.AspNetCore.Mvc;
using TEST.Models;
using TEST.Data;
using Dapper;

namespace TEST.Endpoints.Address
{
    [Route("adresses")]
    public class GetAddressById : EndpointBaseAsync
        .WithRequest<int>
        .WithActionResult<AdressModel>
    {
        private readonly DapperContext ctx;

        public GetAddressById(DapperContext ctx)
        {
            this.ctx = ctx;
        }

        [HttpGet("{id}", Name = "GetAddressById")]
        public override async Task<ActionResult<AdressModel>> HandleAsync(int id, CancellationToken cancellationToken)
        {
            string query = $"SELECT * FROM Adres Where adress_id = {id}";

            using var connection = ctx.CreateConnection();

            var address = await connection.QueryFirstOrDefaultAsync<AdressModel>(query);

            if (address is null) return NotFound();

            return address;
        }
    }
}
