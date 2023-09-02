using Application.Configuration.Utils;
using Application.Data.Entities;
using Application.Data.Repositories;
using Application.Models;
using Application.Models.Requests;
using Application.Models.Responses;
using Application.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioRepository _repository;
        private readonly TokenRepository _tokenRepository;
        public UsuarioController(UsuarioRepository usuarioRepository, TokenRepository tokenRepository)
        {
            _repository = usuarioRepository;
            _tokenRepository = tokenRepository;
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

        [HttpPost("Login")]
        public IActionResult Login(LoginRequest loginReq)
        {
            var usuario = _repository.BuscarPorEmail(loginReq.Email);
            if (String.IsNullOrEmpty(usuario.Username))
            {
                return BadRequest("Email não cadastrado");
            }
            bool senhaCorreta = PasswordService.VerifyPassword(loginReq.Password, usuario.Senha);
            if(senhaCorreta)
            {
                UserTokenTO userToken = _tokenRepository.CreateToken(usuario);
                usuario.Token = userToken.AccessToken;
                return Ok(usuario);
            }
            return BadRequest("Senha incorreta");
        }

        [HttpPost("LoginByToken")]
        public IActionResult Login(string token)
        {
            try
            {
                // First of all, we're going to check if the token exists and if it's not expired
                TokenManager tokenManager = new TokenManager();
                UserTokenTO userToken = _tokenRepository.GetTokenByCode(token);
                if (userToken.Id == 0)
                {
                    return BadRequest("Token inválido");
                }

                if (tokenManager.AccessTokenIsExpired(userToken))
                {
                    if(!tokenManager.RefreshTokenIsExpired(userToken))
                    {
                        // If the access token is expired, but the refresh token is not, we're going to generate a new access token
                        UserTokenTO newToken = _tokenRepository.UpdateToken(userToken.RefreshToken);
                        if (newToken.Id == 0)
                        {
                            return BadRequest("Token inválido");
                        }
                        else
                        {
                            Usuario usuario = _repository.BuscarPorId(newToken.UserId);
                            if (String.IsNullOrEmpty(usuario.Username))
                            {
                                return BadRequest("Usuário não encontrado");
                            }
                            else
                            {
                                usuario.Token = newToken.AccessToken;
                                return Ok(usuario);
                            }
                        }
                    }

                    return BadRequest("Token expirado");
                } else
                {
                    Usuario usuario = _repository.BuscarPorId(userToken.UserId);
                    if (String.IsNullOrEmpty(usuario.Username))
                    {
                        return BadRequest("Usuário não encontrado");
                    }
                    else
                    {
                        usuario.Token = "";
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
                _repository.Cadastrar(usuario);
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
