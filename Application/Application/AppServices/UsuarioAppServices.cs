using Application.Configuration.Utils;
using Application.Data;
using Application.Data.Entities;
using Application.Data.Repositories;
using Application.Domain.Entities;
using Application.Infra.DTO;
using Application.Models.Requests;
using Application.Presentation.ViewModels;
using AutoMapper;

namespace Application.Application.AppServices
{
    public class UsuarioAppServices
    {
        private readonly UsuarioRepository _repository;
        private readonly PreferenciaAppServices _prefApp;
        private readonly TokenAppServices _tokenApp;
        private readonly IMapper _mapper;
        public UsuarioAppServices(
            UsuarioRepository repository, 
            PreferenciaAppServices prefApp,
            TokenAppServices tokenApp,
            IMapper mapper)
        {
            _repository = repository;
            _prefApp = prefApp;
            _tokenApp = tokenApp;
            _mapper = mapper;
        }

        public Usuario? Login(LoginRequest loginReq)
        {
            var usuario = _repository.BuscarPorEmail(loginReq.Email);
            if (string.IsNullOrEmpty(usuario.Username))
            {
                return null;
            }
            bool senhaCorreta = PasswordAppServices.VerifyPassword(loginReq.Password, usuario.Senha);
            if (senhaCorreta)
            {
                UserTokenTO userToken = _tokenApp.CreateToken(usuario);
                usuario.Token = userToken.AccessToken;
                usuario.RefreshToken = userToken.RefreshToken;
            }
            return senhaCorreta ? usuario : null;
        }

        public Usuario? Login(TokenLoginRequest tokenLogin)
        {
            try
            {
                TokenManager tokenManager = new TokenManager();
                UserTokenTO userToken = _tokenApp.GetByCode(tokenLogin);
                if (userToken.Id == 0)
                {
                    throw new Exception("Token inválido");
                }

                if (tokenManager.AccessTokenIsExpired(userToken))
                {
                    if (!tokenManager.RefreshTokenIsExpired(userToken))
                    {
                        UserTokenTO newToken = _tokenApp.UpdateToken(userToken.RefreshToken);
                        if (newToken.Id == 0)
                        {
                            throw new Exception("Token inválido");
                        }
                        else
                        {
                            Usuario usuario = _repository.BuscarPorId(newToken.UserId);
                            if (String.IsNullOrEmpty(usuario.Username))
                            {
                                throw new Exception("Usuário não encontrado");
                            }
                            else
                            {
                                usuario.Token = newToken.AccessToken;
                                usuario.RefreshToken = newToken.RefreshToken;
                                return usuario;
                            }
                        }
                    }

                    throw new Exception("Token expirado");
                }
                else
                {
                    Usuario usuario = _repository.BuscarPorId(userToken.UserId);
                    if (String.IsNullOrEmpty(usuario.Username))
                    {
                        throw new Exception("Usuário não encontrado");
                    }
                    else
                    {
                        usuario.Token = string.Empty;
                        usuario.RefreshToken = string.Empty;
                        return usuario;
                    }
                }


            }
            catch (Exception)
            {
                throw;
            }
        }

        public Usuario BuscarPorId(int idUsuario)
        {
            // O nome da tabela de Usuarios é Usuario
            Usuario usuario = _repository.BuscarPorId(idUsuario);
            return usuario;
        }

        public Usuario BuscarPorEmail(string email)
        {
            Usuario usuario = _repository.BuscarPorEmail(email);
            return usuario;
        }

        public Usuario BuscarPorUsername(string username)
        {
            Usuario usuario = _repository.BuscarPorUsername(username);
            return usuario;
        }

        public Usuario Cadastrar(Usuario usuario)
        {
            try
            {
                _repository.Cadastrar(usuario);
                return usuario;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Usuario Cadastrar(UsuarioRegistroVM usuarioVM)
        {
            try
            {
                if (VerificaSeEmailExiste(usuarioVM.Email))
                {
                    throw new Exception("Email já cadastrado");
                }
                else if (VerificaSeUsernameExiste(usuarioVM.Username))
                {
                    throw new Exception("Nome de usuário já cadastrado");
                }

                Usuario usuario = new Usuario()
                {
                    Nome = usuarioVM.Nome,
                    Email = usuarioVM.Email,
                    Username = usuarioVM.Username,
                    Senha = PasswordAppServices.HashPassword(usuarioVM.Senha),
                    IdRole = 3,
                };
                _repository.Cadastrar(usuario);
                return usuario;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Atualizar(Usuario usuario)
        {
            try
            {
                _repository.Atualizar(usuario);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Deletar(Usuario usuario)
        {
            try
            {
                _repository.Deletar(usuario);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #region Utils
        public bool VerificaSeEmailExiste(string email)
        {
            Usuario usuario = BuscarPorEmail(email);
            return usuario.IdUsuario != 0;
        }

        public bool VerificaSeUsernameExiste(string username)
        {
            Usuario usuario = BuscarPorUsername(username);
            return usuario.IdUsuario != 0;
        }

        public Usuario CriaUsuarioPadrao(string email, string username, int role)
        {
            string senhaPadrao;
            Usuario usuario = new Usuario();
            usuario.Email = email;
            usuario.Username = username;
            usuario.IdRole = role;

            try
            {
                senhaPadrao = _prefApp.BuscarPorCodigo("SENHA_PADRAO");
                usuario.Senha = PasswordAppServices.HashPassword(senhaPadrao);
            }
            catch (Exception)
            {
                // ok
            }

            return usuario;
        }
        #endregion

        // Cria um disposable
        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
