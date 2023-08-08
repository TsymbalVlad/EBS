﻿using Dapper;
using Microsoft.AspNetCore.Mvc;
using TEST.Data;
using TEST.Models;

namespace TEST.Endpoints.FoodOrder
{
	[Route("foodorders")]
	public class AddOrder : EndpointBaseAsync
		.WithRequest<FoodOrderModel>
		.WithActionResult<FoodOrderModel>
	{

		private readonly DapperContext ctx;

		public AddOrder(DapperContext ctx)
		{
			this.ctx = ctx;
		}

		[HttpPost("add", Name = "AddNewOrder")]
		public override async Task<ActionResult<FoodOrderModel>> HandleAsync([FromBody] FoodOrderModel foodorders, CancellationToken cancellationToken)
		{
			string query = @"INSERT INTO Food_order 
                    (Food_order_id, customer_id, adress_id, driver_id, status_id, restaurant_id, deliveryfee, totalamount, order_datetime, req_datetime)
                    VALUES
                    (@Food_order_id, @customer_id, @adress_id, @driver_id, @status_id, @restaurant_id, @deliveryfee, @totalamount, @order_datetime, @req_datetime)";

			using var connection = ctx.CreateConnection();

			var res = await connection.QueryAsync<FoodOrderModel>(query, foodorders);
			return Ok();
		}
	}
}
