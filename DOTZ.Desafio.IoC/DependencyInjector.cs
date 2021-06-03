using AutoMapper;
using DOTZ.Desafio.DAL.Interface.Entities;
using DOTZ.Desafio.DAL.Interface.Loaders;
using DOTZ.Desafio.DAL.Loaders;
using DOTZ.Desafio.Model.Dto;
using DOTZ.Desafio.Model.Request;
using DOTZ.Desafio.Model.Result;
using DOTZ.Desafio.Model.Validators;
using DOTZ.Desafio.Service.Interface.Providers;
using DOTZ.Desafio.Service.Interface.Services;
using DOTZ.Desafio.Service.Interface.Updaters;
using DOTZ.Desafio.Service.Providers;
using DOTZ.Desafio.Service.Services;
using DOTZ.Desafio.Service.Updaters;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace DOTZ.Desafio.IoC
{
    public static class DependencyInjector
    {
        public static void Register(IServiceCollection services)
        {
            RegisterLogin(services);
        }

        public static void RegisterLogin(IServiceCollection services)
        {
            RegisterAuthenticationServices(services);
            RegisterUpdaters(services);
            RegisterProviders(services);
            RegisterServices(services);
            RegisterValidators(services);
        }
        private static void RegisterValidators(IServiceCollection services)
        {
            services.TryAddTransient<IValidator<UserRequest>, UserRequestValidator >();
            services.AddSingleton(typeof(UserRequestValidator));

            services.TryAddTransient<IValidator<LocationDto>, LocationDtoValidator>();
            services.AddSingleton(typeof(LocationDtoValidator));

            services.TryAddTransient<IValidator<ProductDto>, ProductDtoValidator>();
            services.AddSingleton(typeof(ProductDtoValidator));

            services.TryAddTransient<IValidator<DischargeDto>, DischargeDtoValidator>();
            services.AddSingleton(typeof(DischargeDtoValidator));
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.TryAddScoped<IEqualizeDatabase, EqualizeDatabase>();
        }

        
        private static void RegisterProviders(IServiceCollection services)
        {
            services.TryAddScoped<IUserProvider, UserProvider>();
            services.TryAddScoped<ILocationProvider, LocationProvider>();
            services.TryAddScoped<IProductProvider, ProductProvider>();
            services.TryAddScoped<IDischargeProvider, DischargeProvider>();
        }

        private static void RegisterUpdaters(IServiceCollection services)
        {

            services.TryAddScoped<IUserUpdater, UserUpdater>();
            services.TryAddScoped<ILocationUpdater, LocationUpdater>();
            services.TryAddScoped<IProductUpdater, ProductUpdater>();
            services.TryAddScoped<IDischargeUpdater, DischargeUpdater>();


            services.AddSingleton(new MapperConfiguration(config =>
            {
                config.CreateMap<UserRequest, User>();
                config.CreateMap<UserResult, User>();
                config.CreateMap<User, UserResult>();
                config.CreateMap<User, UserRequest>();
                config.CreateMap<LocationDto, Location>();
                config.CreateMap<Location, LocationDto>();
                config.CreateMap<ProductDto, Product>();
                config.CreateMap<Product, ProductDto>();
                config.CreateMap<DischargeDto, Discharge>();
                config.CreateMap<Discharge, DischargeDto>();
            }).CreateMapper());

        }

        private static void RegisterAuthenticationServices(IServiceCollection services)
        {
            services.TryAddScoped<IAccessTokenService, AccessTokenService>();
        }
    }
}
