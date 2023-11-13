using Application.Application.Global;
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
    }
}
