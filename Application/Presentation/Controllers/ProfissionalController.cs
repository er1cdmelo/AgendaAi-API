using Application.Application.AppServices;
using Application.Data.Entities;
using Application.Domain.Entities;
using Application.Models.Responses;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Application.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfissionalController : ControllerBase
    {
        private readonly ProfissionalAppServices _profissionalApp;
        public ProfissionalController(ProfissionalAppServices profissionalApp)
        {
            _profissionalApp = profissionalApp;
        }

        [HttpGet("BuscaPorId")]
        public IActionResult BuscaPorId(int idProfissional)
        {
            try
            {
                Profissional profissional = _profissionalApp.BuscaPorId(idProfissional);
                ProfissionalVM profissionalVM = new ProfissionalVM()
                {
                    IdProfissional = profissional.IdProfissional,
                    Nome = profissional.Nome,
                    Sexo = profissional.Sexo,
                    Especialidade = profissional.Especialidade,
                    Cidade = profissional.Cidade,
                    Estado = profissional.Estado,
                    CdIdentificacao = profissional.CdIdentificacao,
                    ImagemPerfil = profissional.ImagemPerfil,
                    Email = profissional.Usuario.Email,
                    Username = profissional.Usuario.Username,
                };
                return Ok(profissionalVM);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("BuscaPorUsuarioId")]
        public IActionResult BuscaPorUsuarioId(int idUsuario)
        {
            try
            {
                Profissional profissional = _profissionalApp.BuscaPorUsuarioId(idUsuario);
                return Ok(profissional);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("BuscarTodos")]
        public IActionResult BuscarTodos()
        {
            try
            {
                List<Profissional> profissionais = _profissionalApp.BuscarTodos();
                return Ok(profissionais);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("BuscarPorCdIdentificacao")]
        public IActionResult BuscaPorCdIdentificacao(int cdIdent)
        {
            try
            {
                Profissional profissional = _profissionalApp.BuscaPorCdIdentificacao(cdIdent);
                return Ok(profissional);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Registrar")]
        public IActionResult RegistrarProfissional(ProfissionalVM profissionalVM)
        {
            try
            {
                var result = _profissionalApp.RegistrarProfissional(profissionalVM);
                AiResponse response = new AiResponse()
                {
                    code = 200,
                    message = String.Format("Profissional cadastrado com sucesso. A senha inicial é {0}.", result),
                    data = JsonConvert.SerializeObject(profissionalVM),
                    errors = new string[0]
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                AiResponse response = new AiResponse() { 
                    errors = new string[1] { ex.Message }, 
                    message = string.Empty, 
                    code = 400
                };
                return BadRequest(response);
            }
        }

        [HttpPut("Atualizar")]
        public IActionResult AtualizarProfissional(ProfissionalVM profissionalVM)
        {
            try
            {
                _profissionalApp.AtualizarProfissional(profissionalVM);

                AiResponse response = new AiResponse()
                {
                    code = 200,
                    message = "Profissional atualizado com sucesso",
                    data = JsonConvert.SerializeObject(profissionalVM),
                    errors = new string[0]
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Deletar")]
        public IActionResult DeletarProfissional(int idProfissional)
        {
            try
            {
                _profissionalApp.DeletarProfissional(idProfissional);
                AiResponse response = new AiResponse()
                {
                    code = 200,
                    message = "Profissional deletado com sucesso",
                    errors = new string[0]
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                AiResponse response = new AiResponse()
                {
                    code = 400,
                    message = ex.Message,
                    errors = new string[1] { "Não foi possível deletar o profissional" }
                };
                return BadRequest(response);
            }
        }
    }
}
