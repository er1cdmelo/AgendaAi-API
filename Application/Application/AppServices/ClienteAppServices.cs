using Application.Application.Global;
using Application.Domain.Entities;
using Application.Infra.Data.Repositories;

namespace Application.Application.AppServices
{
    public class ClienteAppServices
    {
        private readonly ClienteRepository _repository;
        public ClienteAppServices(ClienteRepository repository)
        {
            _repository = repository;
        }

        public Cliente BuscarPorUsuario(int idUsuario)
        {
            try
            {
                Cliente cliente = _repository.BuscarPorUsuario(idUsuario);
                return cliente;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Cliente BuscarPorId(int idCliente)
        {
            try
            {
                Cliente cliente = _repository.BuscarPorId(idCliente);
                return cliente;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int Registrar(Cliente cliente)
        {
            try
            {
                cliente.Cpf = FuncoesGerais.TiraPontuacaoCpf(cliente.Cpf);
                int idCliente = _repository.Registrar(cliente);
                return idCliente;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
