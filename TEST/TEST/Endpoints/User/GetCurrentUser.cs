using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TEST.Data;
using TEST.Models;

namespace TEST.Endpoints.User
{
	[Route("user")]
	public class GetCurrentUser : EndpointBaseAsync
		.WithoutRequest
		.WithResult<UserModel>
	{
		private readonly DapperContext ctx;

		public GetCurrentUser(DapperContext ctx)
		{
			this.ctx = ctx;
		}

		[HttpGet(Name = "GetCurrentUser")]
		public override async Task<UserModel> HandleAsync(CancellationToken cancellationToken)
		{
			var identity = HttpContext.User.Identity as ClaimsIdentity;

			if (identity != null)
			{
				var userClaims = identity.Claims;

				var id = int.Parse(userClaims.FirstOrDefault(x => x.Type == "user_id")?.Value);

				string query = $"Select * From UsersData Where users_id = {id}";
				using var connection = ctx.CreateConnection();
				var res = await connection.QueryFirstOrDefaultAsync<UserModel>(query); // Здесь используем QueryFirstOrDefaultAsync
				return res;
			}

			return null;
		}
	}
}
