using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using TEST.Data;
using TEST.Models;

namespace TEST.Endpoints.User
{
	[Route("user")]
	public class AddUser : EndpointBaseAsync
		.WithRequest<UserData>
		.WithActionResult<UserData>
	{

		private readonly DapperContext ctx;

		public AddUser(DapperContext ctx)
		{
			this.ctx = ctx;
		}
		[Authorize(Roles = "Admin")]
		[HttpPost("add", Name = "AddUser")]
		public override async Task<ActionResult<UserData>> HandleAsync([FromBody] UserData user, CancellationToken cancellationToken)
		{
			string query = @"INSERT INTO Users 
                    (users_id, u_firstname, u_lastname, email, user_password)
                    VALUES
                    (@users_id, @u_firstname, @u_lastname, @email, @user_password)";

			using var connection = ctx.CreateConnection();

			var res = await connection.QueryAsync<UserData>(query, user);
			return Ok();
		}
	}
}
