
using ClienteApi.Models.Login;
using ClienteApi.Services.Login;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClienteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class LoginController : ControllerBase
    {
        private ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }
        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<login>>> GetLogin()
        {
            try
            {
                var login = await _loginService.GetLogin();
                return Ok(login);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao Obter Login");
            }
        }
    

        [HttpGet("{id}", Name = "GetLoginById")]
        public async Task<ActionResult<login>> GetLoginById(string id)
        {
            try
            {
                var login = await _loginService.GetLoginById(id);
                if (login == null)
                    return NotFound($"Não existem login com id = {id}");
                return Ok(login);


            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao Obter Login");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(login login)
        {
            try
            {
                await _loginService.CreateLogin(login);
                return CreatedAtRoute(nameof(GetLoginById), new { id = login.Email }, login);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao Obter Login");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Edit(string id, [FromBody] login login)
        {
            try
            {
                if (login.Email == id)
                {
                    await _loginService.UpdateLogin(login);
                    //return NoContent();
                    return Ok($"Login com Id = {id} foi atualizado com sucesso");
                }
                else
                {
                    return BadRequest("Dado inconsistentes");
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao Obter Login");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                var login = await _loginService.GetLoginById(id);

                if (login == null)
                {
                    return NotFound($"Login com o Id = {id} não foi encontrado");

                }
                else
                {
                    await _loginService.DeleteLogin(login);
                    //return NoContent();
                    return Ok($"Login com Id = {id} foi deletado com sucesso");
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao Obter Login");
            }
        }
    }

}
