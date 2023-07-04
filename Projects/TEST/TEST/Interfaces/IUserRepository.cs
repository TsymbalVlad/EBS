using System.Collections.Generic;
using System.Threading.Tasks;
using TEST.Models;

namespace TEST.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserData>> AddUser(UserData user);
    }
}
