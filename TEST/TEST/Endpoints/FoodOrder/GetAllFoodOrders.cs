using Dapper;
using Microsoft.AspNetCore.Mvc;
using TEST.Data;
using TEST.Models;

namespace TEST.Endpoints.FoodOrder
{
	[Route("foodorders")]
	public class GetAllFoodOrders : EndpointBaseAsync
		.WithoutRequest
		.WithActionResult<IEnumerable<FoodOrderModel>>
	{
		private readonly DapperContext ctx;

		public GetAllFoodOrders(DapperContext ctx)
		{
			this.ctx = ctx;
		}

		[HttpGet(Name = "GetAllFoodOrders")]
		public override async Task<ActionResult<IEnumerable<FoodOrderModel>>> HandleAsync(CancellationToken cancellationToken)
		{
			string query = "SELECT * FROM Food_order";

			using var connection = ctx.CreateConnection();

			IEnumerable<FoodOrderModel> res = await connection.QueryAsync<FoodOrderModel>(query);

			if (res == null || !res.Any())
			{
				return NotFound();
			}

			return Ok(res);
		}
	}
}
