using DOTZ.Desafio.DAL.Interface.Entities;
using DOTZ.Desafio.Model.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DOTZ.Desafio.Service.Interface.Providers
{
    public interface IProductProvider
    {
        Task<List<Product>> GetAllAsync();
        Task<ProductDto> GetByIdAsync(int id);
        Task<ProductDto> GetByUserIdAsync(int UserId);

    }
}
