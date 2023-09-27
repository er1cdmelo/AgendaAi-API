using Application.Data;
using Application.Data.Entities;
using Application.Data.Repositories;
using Application.Domain.Entities;
using Application.Infra.DTO;
using Application.Models.Requests;

namespace Application.Application.AppServices
{
    public class UsuarioAppServices
    {
        private readonly UsuarioRepository _repository;
        private readonly PreferenciaAppServices _prefApp;
        private readonly TokenRepository _tokenRepository;

        public UsuarioAppServices(UsuarioRepository repository, PreferenciaAppServices prefApp, TokenRepository tokenRepository)
        {
            _repository = repository;
            _prefApp = prefApp;
            _tokenRepository = tokenRepository;
        }

        public UsuarioAppServices()
        {
            _repository = new UsuarioRepository();
            _prefApp = new PreferenciaAppServices();
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
                UserTokenTO userToken = _tokenRepository.CreateToken(usuario);
                usuario.Token = userToken.AccessToken;
                usuario.RefreshToken = userToken.RefreshToken;
            }
            return senhaCorreta ? usuario : null;
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
