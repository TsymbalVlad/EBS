using Dapper;
using Microsoft.AspNetCore.Mvc;
using TEST.Data;
using TEST.Models;

namespace TEST.Endpoints.FoodCategory
{
	[Route("foodcategory")]
	public class GetAllFoddCategory : EndpointBaseAsync
		.WithoutRequest
		.WithActionResult<IEnumerable<FoodCategoryModel>>
	{
		private readonly DapperContext ctx;

		public GetAllFoddCategory(DapperContext ctx)
		{
			this.ctx = ctx;
		}

		[HttpGet(Name = "GetAllFoddCategory")]
		public override async Task<ActionResult<IEnumerable<FoodCategoryModel>>> HandleAsync(CancellationToken cancellationToken)
		{
			string query = "SELECT * FROM FoodCategory";

			using var connection = ctx.CreateConnection();

			IEnumerable<FoodCategoryModel> res = await connection.QueryAsync<FoodCategoryModel>(query);

			if (res == null || !res.Any())
			{
				return NotFound();
			}

			return Ok(res);
		}
	}
}
