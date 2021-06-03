using DOTZ.Desafio.DAL.Interface.Entities;
using DOTZ.Desafio.Model.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DOTZ.Desafio.Service.Interface.Providers
{
    public interface ILocationProvider
    {
        Task<List<Location>> GetAllAsync();
        Task<LocationDto> GetByIdAsync(int id);
        Task<LocationDto> GetByUserIdAsync(int UserId);

    }
}
