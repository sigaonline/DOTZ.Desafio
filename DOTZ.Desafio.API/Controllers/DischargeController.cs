using DOTZ.Desafio.DAL.Interface.Entities;
using DOTZ.Desafio.Model.Dto;
using DOTZ.Desafio.Model.Exceptions;
using DOTZ.Desafio.Service.Interface.Providers;
using DOTZ.Desafio.Service.Interface.Updaters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DOTZ.Desafio.API.Controllers
{
    [Route("api/discharge")]
    [ApiController]
    public class DischargeController : ControllerBase
    {
        private readonly IDischargeUpdater dischargeUpdater;
        private readonly IDischargeProvider dischargeProvider;
        public DischargeController(IDischargeUpdater dischargeUpdater, IDischargeProvider dischargeProvider)
        {
            this.dischargeUpdater = dischargeUpdater;
            this.dischargeProvider = dischargeProvider;
        }

        /// <summary>
        /// Saldo de pontos resgatador por IdUsuario
        /// </summary>
        /// <param name="id">Informe o Id do produto</param>
        /// <returns></returns>
        [HttpGet("balance/{userid}")]
        [Authorize(Roles = "User, Admin")]
        public async Task<DischargeBalanceDto> GetByBalanceUserId([FromRoute] int userid)
        {
            return await dischargeProvider.GetBalanceByUserIdAsync(userid);
        }
        /// <summary>
        /// Busca extrato pelo IdUsuario
        /// </summary>
        /// <param name="id">Informe o Id do produto</param>
        /// <returns></returns>
        [HttpGet("extractdischarge/{userid}")]
        [Authorize(Roles = "User, Admin")]
        public async Task<List<DischargeListDto>> GetByUserId([FromRoute] int userid)
        {
            return await dischargeProvider.GetByUserIdAsync(userid);
        }


        /// <summary>
        ///  Resgatar produto
        /// </summary>
        /// <param name="Description">Descrição do Produto</param>
        /// <param name="PointsValue">Valor me pontos do produto</param>
        /// <returns></returns>
        [HttpPost()]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<dynamic>> Post([FromBody] DischargeDto dataObject)
        {
            try
            {
                if (dataObject == null)
                    return NotFound();

                return await dischargeUpdater.SaveAsync(dataObject);
            }
            catch (Exception e)
            {
                return Ok(new RespostaApi<DischargeDto>
                {
                    erro = true,
                    mensagem = e.Message
                });
            }
        }

    }
}
