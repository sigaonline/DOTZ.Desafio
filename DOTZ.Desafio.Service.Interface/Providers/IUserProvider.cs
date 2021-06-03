using DOTZ.Desafio.DAL.Interface.Entities;
using DOTZ.Desafio.Model.Result;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DOTZ.Desafio.Service.Interface.Providers
{
    public interface IUserProvider
    {
        Task<List<User>> GetAllAsync();
        Task<UserResult> GetByIdAsync(int id);
        Task<UserResult> GetByAuthenticUserAsync(string UserName, string Password);
        Task<UserResult> GetByUserNameAsync(string UserName);
    }
}
