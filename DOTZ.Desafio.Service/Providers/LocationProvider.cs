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
    public class LocationProvider : ILocationProvider
    {
        protected readonly DataBaseContext dataBaseContext;
        private readonly IMapper mapper;
        public LocationProvider(DataBaseContext dataBaseContext, IMapper mapper)
        {
            this.dataBaseContext = dataBaseContext;
            this.mapper = mapper;
        }

        public async Task<List<Location>> GetAllAsync()
        {
            var result = dataBaseContext.Set<Location>().ToList();
            return result;
        }
        public async Task<LocationDto> GetByIdAsync(int id)
        {
            var result = dataBaseContext.Set<Location>().Find(id);
            return mapper.Map<LocationDto>(result);
        }
        public async Task<LocationDto> GetByUserIdAsync(int UserId)
        {
            var result = dataBaseContext.Locations.Where(x => x.UserId.Equals(UserId)).FirstOrDefault();
            return result == null ? null : mapper.Map<LocationDto>(result);
        }
    }
}
