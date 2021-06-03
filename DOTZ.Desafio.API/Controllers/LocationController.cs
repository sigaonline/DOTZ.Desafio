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
    [Route("api/location")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationUpdater locationUpdater;
        private readonly ILocationProvider locationProvider;
        public LocationController(ILocationUpdater locationUpdater, ILocationProvider locationProvider)
        {
            this.locationUpdater = locationUpdater;
            this.locationProvider = locationProvider;
        }

        /// <summary>
        /// Busca todos os endereço
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [Authorize(Roles = "User, Admin")]
        public async Task<List<Location>> GetAll()
        {
            return await locationProvider.GetAllAsync();
        }
        /// <summary>
        /// Busca endereço pelo Id
        /// </summary>
        /// <param name="id">Informe o Id do Endereço</param>
        /// <returns></returns>
        [HttpGet("id/{id}")]
        [Authorize(Roles = "User, Admin")]
        public async Task<ActionResult<dynamic>> GetById([FromRoute] int id)
        {
            return await locationProvider.GetByIdAsync(id);
        }

        /// <summary>
        /// Busca o endereço pelo id do usuário
        /// </summary>
        /// <param name="userid">Id do Usuário</param>
        /// <returns></returns>
        [HttpGet("userid/{userid}")]
        [Authorize(Roles = "User, Admin")]
        public async Task<ActionResult<dynamic>> GetByUserId([FromRoute] int userid)
        {
            return await locationProvider.GetByIdAsync(userid);
        }

        /// <summary>
        ///  Endereço do Usuario
        /// </summary>
        /// <param name="UserId">Id do Usuario</param>
        /// <param name="PostalCode">CEP</param>
        /// <param name="Street">Rua</param>
        /// <param name="Number">Numero</param>
        /// <param name="Complement">Complemento</param>
        /// <param name="District">Bairro</param>
        /// <param name="State">Estado</param>
        /// <param name="City">cidade</param>
        /// <param name="Phone">Telefone</param>
        /// <returns></returns>
        [HttpPost()]
        [Authorize(Roles = "User, Admin")]
        public async Task<ActionResult<dynamic>> Post([FromBody] LocationDto dataObject)
        {
            try
            {
                if (dataObject == null)
                    return NotFound();

                return await locationUpdater.SaveAsync(dataObject);
            }
            catch (Exception e)
            {
                return Ok(new RespostaApi<LocationDto>
                {
                    erro = true,
                    mensagem = e.Message
                });
            }
        }

        /// <summary>
        ///  Endereço do Usuario
        /// </summary>
        /// <param name="UserId">Id do Usuario</param>
        /// <param name="PostalCode">CEP</param>
        /// <param name="Street">Rua</param>
        /// <param name="Number">Numero</param>
        /// <param name="Complement">Complemento</param>
        /// <param name="District">Bairro</param>
        /// <param name="State">Estado</param>
        /// <param name="City">cidade</param>
        /// <param name="Phone">Telefone</param>
        /// <returns></returns>
        [HttpPut()]
        [Authorize(Roles = "User, Admin")]
        public async Task<ActionResult<dynamic>> Put([FromBody] LocationDto dataObject)
        {
            if (dataObject == null)
                return NotFound();

            return await locationUpdater.UpdateAsync(dataObject);
        }

    }
}
