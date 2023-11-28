using Application.Application.Global;
using Application.Data.Entities;
using Application.Domain.Entities;
using Application.Infra.Data.Repositories;
using Application.Infra.DTO;
using Application.Presentation.ViewModels;
using AutoMapper;

namespace Application.Application.AppServices
{
    public class ServicoAppServices
    {
        private readonly ServicoRepository _repository;
        private readonly IMapper _mapper;
        public ServicoAppServices(ServicoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public List<Servico> BuscarTodos()
        {
            try
            {
                return _repository.BuscarTodos();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Servico BuscarPorId(int idServico)
        {
            try
            {
                return _repository.BuscarPorId(idServico);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int Registrar(ServicoTO servicoTO)
        {
            try
            {
                Servico servico = _mapper.Map<Servico>(servicoTO);
                int idServico = _repository.Registrar(servico);
                return idServico;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Servico Atualizar(ServicoTO servicoTO)
        {
            try
            {
                Servico servico = _mapper.Map<Servico>(servicoTO);
                servico.ProfissionalServicos = servicoTO.Profissionais.Select(p => new ProfissionalServico
                {
                    IdProfissional = p,
                    IdServico = servicoTO.IdServico
                }).ToList();

                return _repository.Atualizar(servico);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Deletar(int idServico)
        {
            try
            {
                _repository.Deletar(idServico);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #region Profissional
        public List<Profissional> BuscarProfissionais(int idServico)
        {
            try
            {
                return _repository.BuscarProfissionais(idServico);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
