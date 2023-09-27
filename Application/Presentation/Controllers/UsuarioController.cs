using Application.Application.AppServices;
using Application.Configuration.Utils;
using Application.Data.Repositories;
using Application.Domain.Entities;
using Application.Infra.DTO;
using Application.Models.Requests;
using Application.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Application.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioAppServices _userApp;
        private readonly TokenAppServices _tokenApp;
        public UsuarioController(UsuarioAppServices userApp, TokenAppServices tokenApp)
        {
            _userApp = userApp;
            _tokenApp = tokenApp;
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
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("LoginByToken")]
        public IActionResult Login(TokenLoginRequest tokenLogin)
        {
            try
            {
                // First of all, we're going to check if the token exists and if it's not expired
                TokenManager tokenManager = new TokenManager();
                UserTokenTO userToken = _tokenApp.GetByCode(tokenLogin);
                if (userToken.Id == 0)
                {
                    return BadRequest("Token inválido");
                }

                if (tokenManager.AccessTokenIsExpired(userToken))
                {
                    if(!tokenManager.RefreshTokenIsExpired(userToken))
                    {
                        UserTokenTO newToken = _tokenApp.UpdateToken(userToken.RefreshToken);
                        if (newToken.Id == 0)
                        {
                            return BadRequest("Token inválido");
                        }
                        else
                        {
                            Usuario usuario = _userApp.BuscarPorId(newToken.UserId);
                            if (String.IsNullOrEmpty(usuario.Username))
                            {
                                return BadRequest("Usuário não encontrado");
                            }
                            else
                            {
                                usuario.Token = newToken.AccessToken;
                                usuario.RefreshToken = newToken.RefreshToken;
                                return Ok(usuario);
                            }
                        }
                    }

                    return BadRequest("Token expirado");
                } else
                {
                    Usuario usuario = _userApp.BuscarPorId(userToken.UserId);
                    if (String.IsNullOrEmpty(usuario.Username))
                    {
                        return BadRequest("Usuário não encontrado");
                    }
                    else
                    {
                        usuario.Token = string.Empty;
                        usuario.RefreshToken = string.Empty;
                        return Ok(usuario);
                    }
                }

                
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Registrar")]
        public IActionResult RegistrarUsuario(Usuario usuario)
        {
            try
            {
                _userApp.Cadastrar(usuario);
                AiResponse aiResponse = new AiResponse()
                {
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
