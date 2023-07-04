using TEST.Interfaces;
using TEST.Models;
using Microsoft.AspNetCore.Mvc;
using TEST.Data;
using Dapper;

namespace TEST.Repository
{
    public class AdressRepository : IAdressRepository
    {
        private readonly DapperContext ctx;

        public AdressRepository(DapperContext ctx)
        {
            this.ctx = ctx;
        }

        public async Task <IEnumerable<AdressModel>> GetAdresses()
        {
            string query = @"SELECT * FROM Adres";

            using var connection = ctx.CreateConnection();
            
                var adress = await connection.QueryAsync<AdressModel>(query);
                return adress;
            
        }

        public async Task<IEnumerable<AdressModel>> EditAdress(int id, [FromBody] AdressModel addressData)
        {
            string query = $"SELECT * FROM Adres WHERE adress_id = {id}";
            using var connection = ctx.CreateConnection();

            AdressModel existingAddress = connection.QueryFirstOrDefault<AdressModel>(query);

            existingAddress.house = addressData.house;
            existingAddress.street = addressData.street;
            existingAddress.city = addressData.city;
            existingAddress.postalcode = addressData.postalcode;

            query = $@"UPDATE Adres SET
                  house = @house, street = @street, city = @city, postalcode = @postalcode
                  WHERE adress_id = {id}";

            var parameters = new DynamicParameters();
            parameters.Add("@house", existingAddress.house);
            parameters.Add("@street", existingAddress.street);
            parameters.Add("@city", existingAddress.city);
            parameters.Add("@postalcode", existingAddress.postalcode);

            var adress = await connection.QueryAsync<AdressModel>(query, parameters);
            return adress;
        }

        public async Task<IEnumerable<AdressModel>> GetAdressByID(int id)
        {
            string query = $@"SELECT * FROM Adres Where adress_id = {id}";

            using var connection = ctx.CreateConnection();

            var adress = await connection.QueryAsync<AdressModel>(query);
            return adress;
        }
    }
}
