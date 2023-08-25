using Application.Data.Repositories;
using Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioRepository _repository;
        public UsuarioController(UsuarioRepository usuarioRepository)
        {
            _repository = usuarioRepository;
        }

        [HttpGet("BuscaPorId")]
        public IActionResult BuscaPorId(int idUsuario)
        {
            try
            {
                Usuario usuario = _repository.BuscarPorId(idUsuario);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }   
        }

        [HttpGet("BuscaPorEmail")]
        public IActionResult BuscaPorEmail(string email)
        {
            try
            {
                Usuario usuario = _repository.BuscarPorEmail(email);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }   
        }

        [HttpGet("BuscaPorUsername")]
        public IActionResult BuscaPorUsername(string username)
        {
            try
            {
                Usuario usuario = _repository.BuscarPorUsername(username);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }   
        }

        [HttpGet("Login")]
        public IActionResult Login(string email, string password)
        {
            var usuarioEmail = _repository.BuscarPorEmail(email);
            if (String.IsNullOrEmpty(usuarioEmail.Username))
            {
                return BadRequest("Email não cadastrado");
            }
            bool senhaCorreta = usuarioEmail.Senha == password;
            return senhaCorreta ? Ok(usuarioEmail) : BadRequest("Senha incorreta");
        }

        [HttpPost("Registrar")]
        public IActionResult RegistrarUsuario(Usuario usuario)
        {
            try
            {
                _repository.Cadastrar(usuario);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Atualizar")]
        public IActionResult AtualizarUsuario(Usuario usuario)
        {
            try
            {
                _repository.Atualizar(usuario);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Deletar")]
        public IActionResult DeletarUsuario(Usuario usuario)
        {
            try
            {
                _repository.Deletar(usuario);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
