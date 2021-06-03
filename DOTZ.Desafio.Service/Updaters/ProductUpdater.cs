using AutoMapper;
using DOTZ.Desafio.DAL;
using DOTZ.Desafio.DAL.Interface.Entities;
using DOTZ.Desafio.Model;
using DOTZ.Desafio.Model.Dto;
using DOTZ.Desafio.Model.Exceptions;
using DOTZ.Desafio.Model.Validators;
using DOTZ.Desafio.Service.Interface.Providers;
using DOTZ.Desafio.Service.Interface.Updaters;
using System.Threading.Tasks;

namespace DOTZ.Desafio.Service.Updaters
{
    public class ProductUpdater : IProductUpdater
    {
        protected readonly DataBaseContext dataBaseContext;
        private readonly IMapper mapper;
        private readonly ProductDtoValidator productDtoValidator;
        private readonly IProductProvider productProvider;
        public ProductUpdater(DataBaseContext dataBaseContext, IMapper mapper, ProductDtoValidator productDtoValidator, IProductProvider productProvider)
        {
            this.dataBaseContext = dataBaseContext;
            this.mapper = mapper;
            this.productDtoValidator = productDtoValidator;
            this.productProvider = productProvider;
        }
        public async Task<Product> SaveAsync(ProductDto dataObject)
        {
            var checkUserExists = await productProvider.GetByUserIdAsync(dataObject.Id);
            if (checkUserExists?.Id != null)
                throw new BusinessException(ExceptionMessages.LocationFound);

            var entity = mapper.Map<Product>(dataObject);
            this.dataBaseContext.Set<Product>().Add(entity);
            this.dataBaseContext.SaveChanges();
            return entity;
        }
        public async Task<Product> UpdateAsync(ProductDto dataObject)
        {
            var entity = mapper.Map<Product>(dataObject);
            dataBaseContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dataBaseContext.SaveChanges();
            return entity;
        }

    }
}
