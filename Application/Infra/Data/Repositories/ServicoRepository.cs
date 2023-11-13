using Application.Data;
using Application.Domain.Entities;

namespace Application.Infra.Data.Repositories
{
    public class ServicoRepository
    {
        private readonly AgendaContext _context;
        public ServicoRepository(AgendaContext context)
        {
            _context = context;
        }

        public ServicoRepository()
        {
            _context = new AgendaContext();
        }

        public List<Servico> BuscarTodos()
        {
            List<Servico> servicos = _context.Servico.ToList() ?? new List<Servico>();
            return servicos;
        }

        public Servico BuscarPorId(int idServico)
        {
            Servico servico = _context.Servico.Find(idServico) ?? new Servico();
            return servico;
        }

        public int Registrar(Servico servico)
        {
            _context.Servico.Add(servico);
            _context.SaveChanges();
            return servico.IdServico;
        }

        public Servico Atualizar(Servico servico)
        {
            _context.Servico.Update(servico);
            _context.SaveChanges();
            return servico;
        }

        public void Deletar(int idServico)
        {
            Servico servico = BuscarPorId(idServico);
            _context.Servico.Remove(servico);
            _context.SaveChanges();
        }
    }
}
