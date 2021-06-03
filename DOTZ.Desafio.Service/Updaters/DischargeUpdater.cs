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
    public class DischargeUpdater : IDischargeUpdater
    {
        protected readonly DataBaseContext dataBaseContext;
        private readonly IMapper mapper;
        private readonly DischargeDtoValidator dischargeDtoValidator;
        private readonly IDischargeProvider dischargeProvider;
        private readonly IUserProvider userProvider;
        private readonly IProductProvider userProduct;

        public DischargeUpdater(DataBaseContext dataBaseContext, IMapper mapper, DischargeDtoValidator dischargeDtoValidator, IDischargeProvider dischargeProvider, IUserProvider userProvider, IProductProvider userProduct)
        {
            this.dataBaseContext = dataBaseContext;
            this.mapper = mapper;
            this.dischargeDtoValidator = dischargeDtoValidator;
            this.dischargeProvider = dischargeProvider;
            this.userProvider = userProvider;
            this.userProduct = userProduct;
        }
        public async Task<Discharge> SaveAsync(DischargeDto dataObject)
        {
            var checkUserExists = await userProvider.GetByIdAsync(dataObject.UserId);
            if (checkUserExists?.Id == null)
                throw new BusinessException(ExceptionMessages.UserNotFound);

            var checkProductExists = await userProduct.GetByIdAsync(dataObject.ProductId);
            if (checkProductExists?.Id == null)
                throw new BusinessException(ExceptionMessages.ProductNotFound);

            var entity = mapper.Map<Discharge>(dataObject);
            this.dataBaseContext.Set<Discharge>().Add(entity);
            this.dataBaseContext.SaveChanges();
            return entity;
        }
    }
}
