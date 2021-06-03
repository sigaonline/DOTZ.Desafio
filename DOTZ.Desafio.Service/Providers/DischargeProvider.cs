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
    public class DischargeProvider : IDischargeProvider
    {
        protected readonly DataBaseContext dataBaseContext;
        private readonly IMapper mapper;
        public DischargeProvider(DataBaseContext dataBaseContext, IMapper mapper)
        {
            this.dataBaseContext = dataBaseContext;
            this.mapper = mapper;
        }
        public async Task<DischargeBalanceDto> GetBalanceByUserIdAsync(int UserId)
        {
            var listRescue = (from op in dataBaseContext.Discharges
                              join pg in dataBaseContext.Users on op.UserId equals pg.Id
                              join pd in dataBaseContext.Products on op.ProductId equals pd.Id
                              select new { op.PointsValue, pg.UserName, pd.Description });

            int rescueBalance = 0;
            foreach (var item in listRescue)
            {
                rescueBalance += item.PointsValue;
            }

            return new DischargeBalanceDto {  PointsBalance = rescueBalance };
        }

        public async Task<List<DischargeListDto>> GetByUserIdAsync(int UserId)
        {
            var listRescue = (from op in dataBaseContext.Discharges
                              join pg in dataBaseContext.Users on op.UserId equals pg.Id
                              join pd in dataBaseContext.Products on op.ProductId equals pd.Id
                              select new { op.PointsValue, pg.UserName, pd.Description });

            var listDischarge = new List<DischargeListDto>();
            foreach (var item in listRescue)
            {
                listDischarge.Add(new DischargeListDto
                {
                    UserName = item.UserName,
                    ProductDescripton = item.Description,
                    PointsRescue = item.PointsValue
                });
            }

            return listDischarge;
        }
    }
}
