using DOTZ.Desafio.API;
using DOTZ.Desafio.DAL;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace DOTZ.Desafio.MStest.Base
{
    public class ApiFixture : WebApplicationFactory<Startup>
    {
        public readonly HttpClient client;
        protected ServiceProvider serviceProvider { get; set; }

        public ApiFixture()
        {
            client = CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
        }

        public StringContent ConvertToRawJson(object obj)
            => new StringContent(JsonConvert.SerializeObject(obj), Encoding.Default, "application/json");

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                UtilizarMySQComoBanco(services);
                serviceProvider = services.BuildServiceProvider();
            });
        }

        private void UtilizarMySQComoBanco(IServiceCollection services)
        {
            //Usar SQLite
            var descriptorContexto = services.SingleOrDefault(
                d => d.ServiceType ==
                     typeof(DbContextOptions<DataBaseContext>));
            services.Remove(descriptorContexto);

            services.AddDbContext<DataBaseContext>(options =>
            {
                options.UseMySql("server=localhost;port=3306;database=dotzdesafio;uid=root;password=dotz", ServerVersion.AutoDetect("server=localhost;port=3306;database=dotzdesafio;uid=root;password=dotz"));
            });

        }

    }
}
