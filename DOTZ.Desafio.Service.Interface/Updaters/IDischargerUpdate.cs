using DOTZ.Desafio.DAL.Interface.Entities;
using DOTZ.Desafio.Model.Dto;
using System.Threading.Tasks;

namespace DOTZ.Desafio.Service.Interface.Updaters
{
    public interface IDischargeUpdater
    {
        Task<Discharge> SaveAsync(DischargeDto dataObject);
    }
}
