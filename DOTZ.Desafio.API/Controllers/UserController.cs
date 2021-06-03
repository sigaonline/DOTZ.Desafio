using DOTZ.Desafio.DAL.Interface.Entities;
using DOTZ.Desafio.Model.Exceptions;
using DOTZ.Desafio.Model.Request;
using DOTZ.Desafio.Model.Result;
using DOTZ.Desafio.Service.Interface.Providers;
using DOTZ.Desafio.Service.Interface.Services;
using DOTZ.Desafio.Service.Interface.Updaters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DOTZ.Desafio.API.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserUpdater userUpdater;
        private readonly IUserProvider userProvider;
        public UserController(IUserUpdater userUpdater, IUserProvider userProvider)
        {
            this.userUpdater = userUpdater;
            this.userProvider = userProvider;
        }


        /// <summary>
        /// Busca todos osUsuários
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet()]
        [Authorize(Roles = "User, Admin")]
        public async Task<List<User>> GetAll()
        {
            return await userProvider.GetAllAsync();
        }
        /// <summary>
        /// Busca Usuário pelo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("id/{id}")]
        [Authorize(Roles = "User, Admin")]
        public async Task<UserResult> GetById([FromRoute] int id)
        {
            return await userProvider.GetByIdAsync(id);
        }

        /// <summary>
        /// Cadastra usuário
        /// </summary>
        /// <param name="UserName">Nome de login do usuário</param>
        /// <param name="Password">Senhado usuário</param>
        /// <param name="Password">Role do usuário (1 - User / 2 Admin)</param>
        /// <returns></returns>
        [HttpPost()]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Post([FromBody] UserRequest dataObject)
        {
            try
            {
                if (dataObject == null)
                    return NotFound();

                return await userUpdater.SaveAsync(dataObject);
            }
            catch (Exception e)
            {
                return Ok(new RespostaApi<UserRequest>
                {
                    erro = true,
                    mensagem = e.Message
                });
            }
        }

        /// <summary>
        /// Altera usuário
        /// </summary>
        /// <param name="UserName">Nome de login do usuário</param>
        /// <param name="Password">Senhado usuário</param>
        /// <param name="Password">Role do usuário (1 - User / 2 Admin)</param>
        /// <returns></returns>
        [HttpPut()]
        [Authorize(Roles = "User, Admin")]
        public async Task<ActionResult<dynamic>> Put([FromBody] UserRequest dataObject)
        {
            if (dataObject == null)
                return NotFound();

            return ("",await userUpdater.UpdateAsync(dataObject));
        }

    }
}
