using Application.Data.Repositories;
using Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfissionalController : ControllerBase
    {
        private readonly ProfissionalRepository _repository;
        public ProfissionalController(ProfissionalRepository profissionalRepository)
        {
            _repository = profissionalRepository;
        }

        [HttpGet("BuscaPorId")]
        public IActionResult BuscaPorId(int idPessoa)
        {
            try
            {
                Profissional profissional = _repository.BuscarPorId(idPessoa);
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
                List<Profissional> profissionais = _repository.BuscarTodos();
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
                Profissional profissional = _repository.BuscarPorCdIdentificacao(cdIdent);
                return Ok(profissional);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Registrar")]
        public IActionResult RegistrarProfissional(Profissional profissional)
        {
            try
            {
                _repository.Cadastrar(profissional);
                Console.WriteLine("Cadastrado com sucesso!");
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Atualizar")]
        public IActionResult AtualizarProfissional(Profissional profissional)
        {
            try
            {
                _repository.Atualizar(profissional);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Deletar")]
        public IActionResult DeletarProfissional(Profissional profissional)
        {
            try
            {
                _repository.Deletar(profissional);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
