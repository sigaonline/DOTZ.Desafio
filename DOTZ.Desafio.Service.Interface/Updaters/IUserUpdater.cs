using DOTZ.Desafio.DAL.Interface.Entities;
using DOTZ.Desafio.Model.Request;
using System.Threading.Tasks;

namespace DOTZ.Desafio.Service.Interface.Updaters
{
    public interface IUserUpdater
    {
        Task<User> SaveAsync(UserRequest dataObject);
        Task<User> UpdateAsync(UserRequest dataObject);
    }
}
