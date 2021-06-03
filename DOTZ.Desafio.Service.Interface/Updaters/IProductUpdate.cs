using DOTZ.Desafio.DAL.Interface.Entities;
using DOTZ.Desafio.Model.Dto;
using System.Threading.Tasks;

namespace DOTZ.Desafio.Service.Interface.Updaters
{
    public interface IProductUpdater
    {
        Task<Product> SaveAsync(ProductDto dataObject);
        Task<Product> UpdateAsync(ProductDto dataObject);
    }
}
