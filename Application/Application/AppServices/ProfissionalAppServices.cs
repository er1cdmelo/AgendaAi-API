using Application.Data.Global;
using Application.ViewModels;
using Application.Data.Repositories;
using Application.Domain.Entities;
using Application.Data.Entities;

namespace Application.Application.AppServices
{
    public class ProfissionalAppServices
    {
        private readonly ProfissionalRepository _repository;
        private readonly UsuarioAppServices _userApp;
        private readonly PreferenciaAppServices _prefApp;

        public ProfissionalAppServices(ProfissionalRepository repository, UsuarioAppServices userApp,
            PreferenciaAppServices prefApp)
        {
            _repository = repository;
            _userApp = userApp;
            _prefApp = prefApp;
        }

        public Profissional BuscaPorId(int idProfissional)
        {
            try
            {
                return _repository.BuscarPorId(idProfissional);
            }
            catch (Exception ex)
            {
                ex.Source = "ProfissionalAppServices.BuscaPorId";
                throw ex;
            }
        }

        public Profissional BuscaPorUsuarioId(int idUsuario)
        {
            try
            {
                return _repository.BuscarPorUsuarioId(idUsuario);
            }
            catch (Exception ex)
            {
                ex.Source = "ProfissionalAppServices.BuscaPorUsuarioId";
                throw ex;
            }
        }

        public List<Profissional> BuscarTodos()
        {
            try
            {
                return _repository.BuscarTodos();
            }
            catch (Exception ex)
            {
                ex.Source = "ProfissionalAppServices.BuscarTodos";
                throw ex;
            }
        }

        public Profissional BuscaPorCdIdentificacao(int cdIdent)
        {
            try
            {
                return _repository.BuscarPorCdIdentificacao(cdIdent);
            }
            catch (Exception ex)
            {
                ex.Source = "ProfissionalAppServices.BuscaPorCdIdentificacao";
                throw ex;
            }
        }

        // Vou retornar a senha padrão para o usuário
        public string RegistrarProfissional(ProfissionalVM profissionalVM)
        {
            try
            {
                Profissional profissional = new Profissional()
                {
                    Nome = profissionalVM.Nome,
                    Sexo = profissionalVM.Sexo,
                    Especialidade = profissionalVM.Especialidade,
                    Cidade = profissionalVM.Cidade,
                    Estado = profissionalVM.Estado,
                    CdIdentificacao = profissionalVM.CdIdentificacao,
                    ImagemPerfil = profissionalVM.ImagemPerfil,
                };
                // vamos criar um usuário e checar se não há nenhum usuário com o mesmo email ou username
                Usuario usuario = _userApp.CriaUsuarioPadrao
                    (profissionalVM.Email, profissionalVM.Username, (int)Enums.UserRole.Worker);
                if (_userApp.VerificaSeEmailExiste(usuario.Email))
                {
                    throw new Exception("Email já cadastrado");
                }
                else if (_userApp.VerificaSeUsernameExiste(usuario.Username))
                {
                    throw new Exception("Nome de usuário já cadastrado");
                }

                usuario.Nome = profissionalVM.Nome;
                //var usuarioCadastrado = _userApp.Cadastrar(usuario);
                //profissional.Usuario = usuarioCadastrado;
                profissional.Usuario = usuario;
                _repository.Cadastrar(profissional);
                string senhaPadrao = _prefApp.BuscarPorCodigo("SENHA_PADRAO");
                return senhaPadrao;
            }
            catch (Exception ex)
            {
                ex.Source = "ProfissionalAppServices.RegistrarProfissional";
                throw ex;
            }
        }

        public void AtualizarProfissional(ProfissionalVM profissionalVM)
        {
            try
            {
                Profissional profissional = _repository.BuscarPorId(profissionalVM.IdProfissional);
                profissional.Nome = profissionalVM.Nome;
                profissional.Sexo = profissionalVM.Sexo;
                profissional.Especialidade = profissionalVM.Especialidade;
                profissional.Cidade = profissionalVM.Cidade;
                profissional.Estado = profissionalVM.Estado;
                profissional.CdIdentificacao = profissionalVM.CdIdentificacao;
                profissional.ImagemPerfil = profissionalVM.ImagemPerfil;
                profissional.Usuario.Email = profissionalVM.Email;
                profissional.Usuario.Username = profissionalVM.Username;

                _repository.Atualizar(profissional);
            }
            catch (Exception ex)
            {
                ex.Source = "ProfissionalAppServices.AtualizarProfissional";
                throw ex;
            }
        }
        public void DeletarProfissional(int idProfissional)
        {
            try
            {
                _repository.Deletar(idProfissional);
            }
            catch (Exception ex)
            {
                ex.Source = "ProfissionalAppServices.DeletarProfissional";
                throw ex;
            }
        }

        #region UTILS
        public int BuscaIdProfissional(int idUsuario)
        {
            try
            {
                return _repository.BuscaIdProfissional(idUsuario);
            }
            catch (Exception ex)
            {
                ex.Source = "ProfissionalAppServices.BuscaIdProfissionalPorUsuarioId";
                throw ex;
            }
        }
        #endregion
    }
}
