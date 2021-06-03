using AutoMapper;
using DOTZ.Desafio.DAL;
using DOTZ.Desafio.DAL.Interface.Entities;
using DOTZ.Desafio.Model;
using DOTZ.Desafio.Model.Exceptions;
using DOTZ.Desafio.Model.Request;
using DOTZ.Desafio.Model.Validators;
using DOTZ.Desafio.Service.Interface.Providers;
using DOTZ.Desafio.Service.Interface.Updaters;
using System.Threading.Tasks;

namespace DOTZ.Desafio.Service.Updaters
{
    public class UserUpdater : IUserUpdater
    {
        protected readonly DataBaseContext dataBaseContext;
        private readonly IMapper mapper;
        private readonly UserRequestValidator userRequestValidator;
        private readonly IUserProvider userProvider;
        public UserUpdater(DataBaseContext dataBaseContext, IMapper mapper, UserRequestValidator userRequestValidator, IUserProvider userProvider)
        {
            this.dataBaseContext = dataBaseContext;
            this.mapper = mapper;
            this.userRequestValidator = userRequestValidator;
            this.userProvider = userProvider;
        }
        public async Task<User> SaveAsync(UserRequest dataObject)
        {
            var checkUserExists = await userProvider.GetByUserNameAsync(dataObject.UserName);
            if (checkUserExists?.Id != null)
                throw new BusinessException(ExceptionMessages.UserNFound);

            var entity = mapper.Map<User>(dataObject);
            this.dataBaseContext.Set<User>().Add(entity);
            this.dataBaseContext.SaveChanges();
            return entity;
        }
        public async Task<User> UpdateAsync(UserRequest dataObject)
        {
            var entity = mapper.Map<User>(dataObject);
            dataBaseContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dataBaseContext.SaveChanges();
            return entity;

        }

    }
}
