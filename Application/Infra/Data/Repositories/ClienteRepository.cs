using Application.Data;
using Application.Domain.Entities;

namespace Application.Infra.Data.Repositories
{
    public class ClienteRepository
    {
        private readonly AgendaContext _context;
        public ClienteRepository(AgendaContext context)
        {
            _context = context;
        }

        public Cliente BuscarPorUsuario(int idUsuario)
        {
            Cliente cliente = _context.Cliente.FirstOrDefault(c => c.IdUsuario == idUsuario) ?? new Cliente();
            return cliente;
        }

        public Cliente BuscarPorId(int idCliente)
        {

            Cliente cliente = _context.Cliente.FirstOrDefault(c => c.IdCliente == idCliente) ?? new Cliente();
            return cliente;
        }

        public int Registrar(Cliente cliente)
        {
            _context.Cliente.Add(cliente);
            _context.SaveChanges();
            return cliente.IdCliente;
        }
    }
}
