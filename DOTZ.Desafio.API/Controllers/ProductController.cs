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
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductUpdater productUpdater;
        private readonly IProductProvider productProvider;
        public ProductController(IProductUpdater productUpdater, IProductProvider productProvider)
        {
            this.productUpdater = productUpdater;
            this.productProvider = productProvider;
        }

        /// <summary>
        /// Busca produto pelo Id
        /// </summary>
        /// <param name="id">Informe o Id do produto</param>
        /// <returns></returns>
        [HttpGet()]
        [Authorize(Roles = "User, Admin")]
        public async Task<List<Product>> GetAll()
        {
            return await productProvider.GetAllAsync();
        }

        /// <summary>
        /// Busca produto pelo Id
        /// </summary>
        /// <param name="id">Informe o Id do produto</param>
        /// <returns></returns>
        [HttpGet("id/{id}")]
        [Authorize(Roles = "User, Admin")]
        public async Task<ActionResult<dynamic>> GetById([FromRoute] int id)
        {
            return await productProvider.GetByIdAsync(id);
        }


        /// <summary>
        ///  Cadastrar Produto
        /// </summary>
        /// <param name="Description">Descrição do Produto</param>
        /// <param name="PointsValue">Valor me pontos do produto</param>
        /// <returns></returns>
        [HttpPost()]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<dynamic>> Post([FromBody] ProductDto dataObject)
        {
            try
            {
                if (dataObject == null)
                    return NotFound();

                return await productUpdater.SaveAsync(dataObject);
            }
            catch (Exception e)
            {
                return Ok(new RespostaApi<ProductDto>
                {
                    erro = true,
                    mensagem = e.Message
                });
            }
        }

        /// <summary>
        ///  Alterar Produto
        /// </summary>
        /// <param name="Description">Descrição do Produto</param>
        /// <param name="PointsValue">Valor me pontos do produto</param>
        /// <returns></returns>
        /// <returns></returns>
        [HttpPut()]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<dynamic>> Put([FromBody] ProductDto dataObject)
        {
            if (dataObject == null)
                return NotFound();

            return await productUpdater.UpdateAsync(dataObject);
        }

    }
}
