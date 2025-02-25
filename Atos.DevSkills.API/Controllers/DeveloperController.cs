﻿using Atos.DevSkills.Domain.InputModel;
using Atos.DevSkills.Domain.IService;
using Microsoft.AspNetCore.Authorization;
using Atos.DevSkills.Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using Atos.DevSkills.Domain.Model;

namespace Atos.DevSkills.API.Controllers
{    
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class DeveloperController : ControllerBase
    {
        private readonly IDesenvolvedorService _desenvolvedorService;

        public DeveloperController(IDesenvolvedorService desenvolvedorService)
        {
            _desenvolvedorService = desenvolvedorService;
        }

        /// <summary>
        /// Retorna lista de desenvolvedores.
        /// </summary>   
        /// <response code="200">lista de desenvolvedores.</response>
        /// <response code="400">Contém erros de validação.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ResponseViewModel<List<DesenvolvedorViewModel>>), 200)]
        [ProducesResponseType(typeof(ErrorsViewModel), 400)]
        [ProducesResponseType(500)]
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var response = await _desenvolvedorService.ListAll();
            return Ok(response);
        }

        /// <summary>
        /// Retorna um desenvolvedor com suas informações detalhadas.
        /// </summary>
        /// <param name="id">Identificador do desenvolvedor.</param>  
        /// <remarks> 
        /// </remarks>
        /// <response code="200">Retorna um desenvolvedor com todas as suas informações.</response>
        /// <response code="400">Contém erros de validação.</response>
        /// <response code="500">Erro interno no servidor.</response>
        [ProducesResponseType(typeof(ResponseViewModel<DesenvolvedorViewModel>), 200)]
        [ProducesResponseType(typeof(ErrorsViewModel), 400)]
        [ProducesResponseType(500)]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var response = await _desenvolvedorService.FindById(id);
            return Ok(response);
        }

        /// <summary>
        /// Retorna um desenvolvedor com suas informações detalhadas filtrado pela skill.
        /// </summary>
        /// <param name="skill">Descrição de skill de um desenvolvedor.</param>  
        /// <remarks> 
        /// </remarks>
        /// <response code="200">Retorna um desenvolvedor com todas as suas informações de acordo com a skill filtrada.</response>
        /// <response code="400">Contém erros de validação.</response>
        /// <response code="500">Erro interno no servidor.</response>
        [ProducesResponseType(typeof(ResponseViewModel<DesenvolvedorViewModel>), 200)]
        [ProducesResponseType(typeof(ErrorsViewModel), 400)]
        [ProducesResponseType(500)]
        [HttpGet("skill")]
        public async Task<IActionResult> GetBySkillAsync([FromQuery] string? skill)
        {
            var response = await _desenvolvedorService.ListAllBySkill(skill);
            return Ok(response);
        }

        /// <summary>
        /// Insere um novo desenvolvedor.
        /// </summary>
        /// <param name="desenvolvedorModel">Objeto mapeado para inserção de um desenvolvedor.</param>  
        /// <remarks> 
        /// </remarks>
        /// <response code="200">Sucesso ao cadastrar o usuário.</response>
        /// <response code="400">Contém erros de validação.</response>
        /// <response code="500">Erro interno no servidor.</response>
        [ProducesResponseType(typeof(ResponseViewModel<DesenvolvedorViewModel>), 200)]
        [ProducesResponseType(typeof(ErrorsViewModel), 400)]
        [ProducesResponseType(500)]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] DesenvolvedorInputModel model)
        {
            var response = await _desenvolvedorService.AddAsync(model);
            return Ok(response);
        }

        /// <summary>
        /// Altera informações de um desenvolvedor.
        /// </summary>
        /// <param name="id">Identificador de um desenvolvedor.</param>  
        /// <remarks> 
        /// </remarks>
        /// <response code="200">Sucesso ao editar os dados de um desenvolvedor.</response>
        /// <response code="400">Contém erros de validação.</response>
        /// <response code="500">Erro interno no servidor.</response>
        [ProducesResponseType(typeof(ResponseViewModel<DesenvolvedorViewModel>), 200)]
        [ProducesResponseType(typeof(ErrorsViewModel), 400)]
        [ProducesResponseType(500)]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] DesenvolvedorUpdateInputModel model)
        {
            var response = await _desenvolvedorService.UpdateById(id, model);
            return Ok(response);
        }

        /// <summary>
        /// Deleta um desenvolvedor.
        /// </summary>
        /// <param name="id">Identificador de um desenvolvedor.</param>  
        /// <remarks> 
        /// </remarks>
        /// <response code="200">Sucesso ao deletar um desenvolvedor.</response>
        /// <response code="400">Contém erros de validação.</response>
        /// <response code="500">Erro interno no servidor.</response>
        [ProducesResponseType(typeof(ResponseViewModel<string>), 200)]
        [ProducesResponseType(typeof(ErrorsViewModel), 400)]
        [ProducesResponseType(500)]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var response = await _desenvolvedorService.Delete(id);
            return Ok(response);
        }
    }
}
