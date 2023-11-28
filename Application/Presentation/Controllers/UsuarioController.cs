using Application.Application.AppServices;
using Application.Configuration.Utils;
using Application.Data.Repositories;
using Application.Domain.Entities;
using Application.Infra.DTO;
using Application.Models.Requests;
using Application.Models.Responses;
using Application.Presentation.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Application.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioAppServices _userApp;
        private readonly ClienteAppServices _clienteApp;
        public UsuarioController(UsuarioAppServices userApp, ClienteAppServices clienteApp)
        {
            _userApp = userApp;
            _clienteApp = clienteApp;
        }

        [HttpGet("BuscaPorId")]
        public IActionResult BuscaPorId(int idUsuario)
        {
            try
            {
                Usuario usuario = _userApp.BuscarPorId(idUsuario);
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
                Usuario usuario = _userApp.BuscarPorEmail(email);
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
                Usuario usuario = _userApp.BuscarPorUsername(username);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }   
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginRequest loginReq)
        {
            try
            {
                Usuario? usuario = _userApp.Login(loginReq);
                return usuario != null ? Ok(usuario) : BadRequest("Usuário ou senha incorretos");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("LoginByToken")]
        public IActionResult Login(TokenLoginRequest tokenLogin)
        {
            try
            {
                Usuario? usuario = _userApp.Login(tokenLogin);
                return usuario != null ? Ok(usuario) : BadRequest();
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Registrar")]
        public IActionResult RegistrarUsuario(UsuarioRegistroVM usuario)
        {
            try
            {
                Usuario usuarioCadastrado = _userApp.Cadastrar(usuario);
                AiResponse aiResponse = new AiResponse()
                {
                    data = JsonConvert.SerializeObject(usuarioCadastrado),
                    code = 200,
                    message = "Cadastro realizado com sucesso!"
                };
                return Ok(aiResponse);
            }
            catch (Exception ex)
            {
                AiResponse aiResponse = new AiResponse()
                {
                    code = 400,
                    message = ex.Message
                };
                return BadRequest(aiResponse);
            }
        }

        //[HttpPost("RegistrarAdm")]
        //public IActionResult RegistrarAdm(Usuario usuario)
        //{

        //}

        [HttpPut("Atualizar")]
        public IActionResult AtualizarUsuario(Usuario usuario)
        {
            try
            {
                _userApp.Atualizar(usuario);
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
                _userApp.Deletar(usuario);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
