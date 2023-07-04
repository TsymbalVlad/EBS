using Microsoft.AspNetCore.Mvc;
using TEST.Models;

namespace TEST.Interfaces
{
    public interface IAdressRepository
    {
        Task<IEnumerable<AdressModel>> GetAdresses();
        Task<IEnumerable<AdressModel>> EditAdress(int id, [FromBody] AdressModel adressModel);
        Task<IEnumerable<AdressModel>> GetAdressByID(int id);

    }
}
