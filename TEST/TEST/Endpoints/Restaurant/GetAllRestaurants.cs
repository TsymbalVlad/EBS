using Dapper;
using Microsoft.AspNetCore.Mvc;
using TEST.Data;
using TEST.Models;

namespace TEST.Endpoints.Restaurant
{
	[Route("restaurants")]
	public class GetAllRestaurants : EndpointBaseAsync
		.WithoutRequest
		.WithActionResult<IEnumerable<RestaurantModel>>
	{
		private readonly DapperContext ctx;

		public GetAllRestaurants(DapperContext ctx)
		{
			this.ctx = ctx;
		}

		[HttpGet(Name = "GetAllRestaurants")]
		public override async Task<ActionResult<IEnumerable<RestaurantModel>>> HandleAsync(CancellationToken cancellationToken)
		{
			string query = "SELECT * FROM Restaurant";

			using var connection = ctx.CreateConnection();

			IEnumerable<RestaurantModel> res = await connection.QueryAsync<RestaurantModel>(query);

			if (res == null || !res.Any())
			{
				return NotFound();
			}

			return Ok(res);
		}
	}
}
