using Application.Data;
using Application.Data.Repositories;
using Application.Domain.Entities;
using Application.Presentation.ViewModels;

namespace Application.Application.AppServices
{
    public class PreferenciaAppServices
    {
        private readonly PreferenciaRepository _repository;
        public PreferenciaAppServices(PreferenciaRepository repository)
        {
            _repository = repository;
        }

        public PreferenciaAppServices()
        {
            _repository = new PreferenciaRepository();
        }

        public List<Preferencia> BuscarTodos()
        {
            List<Preferencia> preferencias = _repository.BuscarTodos();
            return preferencias;
        }

        public string BuscarPorCodigo(string cdPrefencia)
        {
            Preferencia preferencia = _repository.BuscarPorCodigo(cdPrefencia);
            return preferencia.ValorPreferencia;
        }

        public Preferencia BuscarPorId(int idPreferencia)
        {
            // O nome da tabela de Preferencias é Preferencia
            Preferencia preferencia = _repository.BuscarPorId(idPreferencia);
            return preferencia;
        }

        public void Cadastrar(Preferencia preferencia)
        {
            try
            {
                _repository.Cadastrar(preferencia);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Atualizar(List<PreferenciaVM> prefsVm)
        {
            try
            {
                _repository.Atualizar(prefsVm);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Deletar(Preferencia preferencia)
        {
            try
            {
                _repository.Deletar(preferencia);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
