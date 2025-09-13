using ClienteApi.Models.Ponto;
using ClienteApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClienteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PontoController : Controller
    {
        private Ipontoservice _pontoService;

        public PontoController(Ipontoservice pontoService)
        {
            _pontoService = pontoService;
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<ponto>>> GetPonto()
        {
            try
            {
                var ponto = await _pontoService.GetPonto();
                return Ok(ponto);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao Obter Ponto");

            }
        }

        [HttpGet("{id}", Name = "GetPontoById")]
        public async Task<ActionResult<ponto>> GetPontoById(string id)
        {
            try
            {
                var ponto = await _pontoService.GetPontoById(id);
                if (ponto == null)
                {
                    return NotFound($"Não existem pontos com id = {id}");
                }
                return Ok(ponto);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao Obter Funcionário");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(ponto ponto)
        {
            try
            {
                await _pontoService.CreatePonto(ponto);
                return CreatedAtRoute(nameof(GetPontoById), new { id = ponto.Email }, ponto);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao Obter ponto");
            }
        }



        [HttpPut("{id}")]
        public async Task<ActionResult> Edit(string id, [FromBody] ponto ponto)
        {
            try
            {
                if (ponto.Email == id)
                {
                    await _pontoService.UpdatePonto(ponto);
                    //return NoContent();
                    return Ok($"Ponto com Id = {id} foi atualizado com sucesso");
                }
                else
                {
                    return BadRequest("Dado inconsistentes");
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao Obter Ponto");
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                var ponto = await _pontoService.GetPontoById(id); ///

                if (ponto == null)
                {
                    return NotFound($"Ponto com o email = {id} não foi encontrado");

                }
                else
                {
                    await _pontoService.DeletePonto(ponto);
                    //return NoContent();
                    return Ok($"Ponto com Email = {id} foi deletado com sucesso");
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao Obter Ponto");
            }
        }
    }
}
