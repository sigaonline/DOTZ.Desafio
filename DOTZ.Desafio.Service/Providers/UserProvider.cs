using AutoMapper;
using DOTZ.Desafio.DAL;
using DOTZ.Desafio.DAL.Interface.Entities;
using DOTZ.Desafio.Model.Result;
using DOTZ.Desafio.Service.Interface.Providers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DOTZ.Desafio.Service.Providers
{
    public class UserProvider : IUserProvider
    {
        protected readonly DataBaseContext dataBaseContext;
        private readonly IMapper mapper;
        public UserProvider(DataBaseContext dataBaseContext, IMapper mapper)
        {
            this.dataBaseContext = dataBaseContext;
            this.mapper = mapper;
        }

        public async Task<List<User>> GetAllAsync()
        {
            var result = dataBaseContext.Set<User>().ToList();
            return result;
        }
        public async Task<UserResult> GetByIdAsync(int id)
        {
            var result = dataBaseContext.Set<User>().Find(id);
            return mapper.Map<UserResult>(result);
        }
        public async Task<UserResult> GetByAuthenticUserAsync(string UserName, string Password)
        {
            var result = dataBaseContext.Users.Where(x => x.UserName.Equals(UserName) && x.Password.Equals(Password)).FirstOrDefault();
            return result == null ? null : mapper.Map<UserResult>(result);
        }
        public async Task<UserResult> GetByUserNameAsync(string UserName)
        {
            var result = dataBaseContext.Users.Where(x => x.UserName.Equals(UserName)).FirstOrDefault();
            return result == null ? null : mapper.Map<UserResult>(result);
        }
        
    }
}
