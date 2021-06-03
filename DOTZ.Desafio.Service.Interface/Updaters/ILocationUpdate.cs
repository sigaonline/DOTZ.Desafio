using DOTZ.Desafio.DAL.Interface.Entities;
using DOTZ.Desafio.Model.Dto;
using System.Threading.Tasks;

namespace DOTZ.Desafio.Service.Interface.Updaters
{
    public interface ILocationUpdater
    {
        Task<Location> SaveAsync(LocationDto dataObject);
        Task<Location> UpdateAsync(LocationDto dataObject);
    }
}
