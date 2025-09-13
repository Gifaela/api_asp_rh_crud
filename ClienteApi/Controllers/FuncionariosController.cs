using ClienteApi.Models;
using ClienteApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClienteApi.Controllers
{
    [Route("api/[controller]")] // rotas
    [ApiController]

    public class FuncionariosController : ControllerBase
    {
        private IFuncionarioService _funcionarioService;

        public FuncionariosController(IFuncionarioService funcionarioService)
        {
            _funcionarioService = funcionarioService;
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<funcionario>>> GetFuncionarios() // ActionResult, permite que retorno o tipo do response, ou qualquer outro resultado da action
        {
            try
            {
                var funcionarios = await _funcionarioService.GetFuncionarios();
                return Ok(funcionarios);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao Obter Alunos");
            }
        }

        [HttpGet("FuncionarioByName")]
        public async Task<ActionResult<IAsyncEnumerable<funcionario>>> GetFuncionarioByName([FromQuery] string name)
        {
            try
            {
                var funcionarios = await _funcionarioService.GetFuncionarioByName(name);
                if (name == null) // não está funcionando a validação
                    return NotFound($"Não existem funcionários com o critério {name}");
                return Ok(funcionarios);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao Obter Funcionário");
            }
        }

        [HttpGet("{id:int}", Name = "GetFuncionarioById")]
        public async Task<ActionResult<funcionario>> GetFuncionarioById(int id)
        {
            try
            {
                var funcionarios = await _funcionarioService.GetFuncionarioById(id);
                if (funcionarios == null)
                    return NotFound($"Não existem funcionários com id = {id}");
                return Ok(funcionarios);


            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao Obter Funcionário");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(funcionario funcionario)
        {
            try
            {
                await _funcionarioService.CreateFuncionario(funcionario);
                return CreatedAtRoute(nameof(GetFuncionarioById), new { id = funcionario.Id }, funcionario);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao Obter Funcionário");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Edit(int id, [FromBody] funcionario funcionario)
        {
            try
            {
                if (funcionario.Id == id)
                {
                    await _funcionarioService.UpdateFuncionario(funcionario);
                    //return NoContent();
                    return Ok($"Funcionário com Id = {id} foi atualizado com sucesso");
                }
                else
                {
                    return BadRequest("Dado inconsistentes");
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao Obter Funcionário");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var funcionario = await _funcionarioService.GetFuncionarioById(id);

                if (funcionario == null)
                {
                    return NotFound($"Funcionário com o Id = {id} não foi encontrado");

                }
                else
                {
                    await _funcionarioService.DeleteFuncionario(funcionario);
                    //return NoContent();
                    return Ok($"Funcionário com Id = {id} foi deletado com sucesso");
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao Obter Funcionário");
            }
        }
    }
}
