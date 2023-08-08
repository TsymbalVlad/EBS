using Dapper;
using Microsoft.AspNetCore.Mvc;
using TEST.Data;
using TEST.Models;

namespace TEST.Endpoints.FoodItem
{
	[Route("fooditems")]
	public class GetAllFodItems : EndpointBaseAsync
		.WithoutRequest
		.WithActionResult<IEnumerable<FoodItemModel>>
	{
		private readonly DapperContext ctx;

		public GetAllFodItems(DapperContext ctx)
		{
			this.ctx = ctx;
		}

		[HttpGet(Name = "GetAllFoodItems")]
		public override async Task<ActionResult<IEnumerable<FoodItemModel>>> HandleAsync(CancellationToken cancellationToken)
		{
			string query = "SELECT * FROM Fooditem";

			using var connection = ctx.CreateConnection();

			IEnumerable<FoodItemModel> res = await connection.QueryAsync<FoodItemModel>(query);

			if (res == null || !res.Any())
			{
				return NotFound();
			}

			return Ok(res);
		}
	}
}
