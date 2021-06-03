using AutoMapper;
using DOTZ.Desafio.DAL;
using DOTZ.Desafio.DAL.Interface.Entities;
using DOTZ.Desafio.Model.Dto;
using DOTZ.Desafio.Service.Interface.Providers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DOTZ.Desafio.Service.Providers
{
    public class ProductProvider : IProductProvider
    {
        protected readonly DataBaseContext dataBaseContext;
        private readonly IMapper mapper;
        public ProductProvider(DataBaseContext dataBaseContext, IMapper mapper)
        {
            this.dataBaseContext = dataBaseContext;
            this.mapper = mapper;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            var result = dataBaseContext.Set<Product>().ToList();
            return result;
        }
        public async Task<ProductDto> GetByIdAsync(int id)
        {
            var result = dataBaseContext.Set<Product>().Find(id);
            return mapper.Map<ProductDto>(result);
        }
        public async Task<ProductDto> GetByUserIdAsync(int UserId)
        {
            var result = dataBaseContext.Locations.Where(x => x.UserId.Equals(UserId)).FirstOrDefault();
            return result == null ? null : mapper.Map<ProductDto>(result);
        }
    }
}
