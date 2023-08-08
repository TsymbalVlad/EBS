using Dapper;
using Microsoft.AspNetCore.Mvc;
using TEST.Data;
using TEST.Models;

namespace TEST.Endpoints.Restaurant
{
	[Route("restaurants")]
	public class GetMenu : EndpointBaseAsync
	.WithRequest<int>
	.WithActionResult<IEnumerable<Menu>>
	{
		private readonly DapperContext ctx;

		public GetMenu(DapperContext ctx)
		{
			this.ctx = ctx;
		}

		[HttpGet("menu/{id}", Name = "GetMenuByRestaurantId")]
		public override async Task<ActionResult<IEnumerable<Menu>>> HandleAsync(int id, CancellationToken cancellationToken)
		{
			string query = $"SELECT * FROM Menu Where restaurant_id = {id}";

			using var connection = ctx.CreateConnection();

			IEnumerable<Menu> res = await connection.QueryAsync<Menu>(query);

			if (res == null || !res.Any())
			{
				return NotFound();
			}

			return Ok(res);
		}
	}

}
