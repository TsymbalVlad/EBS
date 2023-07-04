using TEST.Interfaces;
using TEST.Models;
using Microsoft.AspNetCore.Mvc;
using TEST.Data;
using Dapper;
using Azure.Identity;
using System.Net.Http.Headers;

namespace TEST.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DapperContext ctx;

        public UserRepository(DapperContext ctx)
        {
            this.ctx = ctx;
        }

        public async Task<IEnumerable<UserData>> AddUser(UserData user)
        {
            string query = @"INSERT INTO Users 
                    (users_id, u_firstname, u_lastname, email, user_password)
                    VALUES
                    (@users_id, @u_firstname, @u_lastname, @email, @user_password)";

            using var connection = ctx.CreateConnection();

            var affectedRows = await connection.QueryAsync<UserData>(query, user);
            return affectedRows;
        }


    }
}

