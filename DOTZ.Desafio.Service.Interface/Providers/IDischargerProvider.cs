using DOTZ.Desafio.DAL.Interface.Entities;
using DOTZ.Desafio.Model.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DOTZ.Desafio.Service.Interface.Providers
{
    public interface IDischargeProvider
    {
        Task<DischargeBalanceDto> GetBalanceByUserIdAsync(int UserId);
        Task<List<DischargeListDto>> GetByUserIdAsync(int UserId);

    }
}
