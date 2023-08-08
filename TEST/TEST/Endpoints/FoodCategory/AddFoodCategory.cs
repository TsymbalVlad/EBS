using Dapper;
using Microsoft.AspNetCore.Mvc;
using TEST.Data;
using TEST.Models;

namespace TEST.Endpoints.FoodCategory
{
	[Route("foodcategory")]
	public class AddFoodategory : EndpointBaseAsync
		.WithRequest<FoodCategoryModel>
		.WithActionResult<FoodCategoryModel>
	{

		private readonly DapperContext ctx;

		public AddFoodategory(DapperContext ctx)
		{
			this.ctx = ctx;
		}

		[HttpPost("add", Name = "AddNewFoodCategory")]
		public override async Task<ActionResult<FoodCategoryModel>> HandleAsync([FromBody] FoodCategoryModel newcategory, CancellationToken cancellationToken)
		{
			string query = $"INSERT INTO FoodCategory VALUES (@category_id, @food_name, @restaurant_id)";
			using var connection = ctx.CreateConnection();

			var foodcategory = await connection.QueryAsync<FoodCategoryData>(query, newcategory);
			return Ok();
		}
	}
}
