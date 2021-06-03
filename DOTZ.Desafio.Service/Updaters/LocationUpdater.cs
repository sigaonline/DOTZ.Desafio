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
    public class LocationUpdater : ILocationUpdater
    {
        protected readonly DataBaseContext dataBaseContext;
        private readonly IMapper mapper;
        private readonly LocationDtoValidator locationDtoValidator;
        private readonly ILocationProvider locationProvider;
        public LocationUpdater(DataBaseContext dataBaseContext, IMapper mapper, LocationDtoValidator locationDtoValidator, ILocationProvider locationProvider)
        {
            this.dataBaseContext = dataBaseContext;
            this.mapper = mapper;
            this.locationDtoValidator = locationDtoValidator;
            this.locationProvider = locationProvider;
        }
        public async Task<Location> SaveAsync(LocationDto dataObject)
        {
            var checkUserExists = await locationProvider.GetByUserIdAsync(dataObject.UserId);
            if (checkUserExists?.Id != null)
                throw new BusinessException(ExceptionMessages.LocationFound);

            var entity = mapper.Map<Location>(dataObject);
            this.dataBaseContext.Set<Location>().Add(entity);
            this.dataBaseContext.SaveChanges();
            return entity;
        }
        public async Task<Location> UpdateAsync(LocationDto dataObject)
        {
            var entity = mapper.Map<Location>(dataObject);
            dataBaseContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dataBaseContext.SaveChanges();
            return entity;
        }

    }
}
