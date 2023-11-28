using Application.Data;
using Application.Data.Entities;
using Application.Domain.Entities;
using Microsoft.EntityFrameworkCore;

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
            List<Servico> servicos = _context.Servico.Where(s => s.FlAtivo).ToList() ?? new List<Servico>();
            return servicos;
        }

        public Servico BuscarPorId(int idServico)
        {
            var result = _context.Servico
                .AsNoTracking()
                .Include(s => s.ProfissionalServicos)
                .ThenInclude(ps => ps.Profissional)
                .FirstOrDefault(s => s.IdServico == idServico) ?? new Servico();

            Servico servico = new Servico()
            {
                IdServico = result.IdServico,
                NmServico = result.NmServico,
                DsServico = result.DsServico,
                VlServico = result.VlServico,

                ProfissionalServicos = result.ProfissionalServicos.Select(ps => new ProfissionalServico()
                {
                    Profissional = new Profissional()
                    {
                        IdProfissional = ps.Profissional.IdProfissional,
                        Nome = ps.Profissional.Nome,
                    }
                }).ToList()
            };

            return servico;
        }

        public List<Profissional> BuscarProfissionais(int idServico)
        {
            List<Profissional> profissionais = _context.ProfissionalServico
                .Where(ps => ps.IdServico == idServico)
                .Select(ps => ps.Profissional)
                .ToList() ?? new List<Profissional>();

            return profissionais;
        }

        public int Registrar(Servico servico)
        {
            _context.Servico.Add(servico);
            _context.SaveChanges();
            return servico.IdServico;
        }

        public Servico Atualizar(Servico servicoAtt)
        {
            Servico servico = BuscarPorId(servicoAtt.IdServico);
            servico.NmServico = servicoAtt.NmServico;
            servico.DsServico = servicoAtt.DsServico;
            servico.VlServico = servicoAtt.VlServico;
            servico.ProfissionalServicos = servicoAtt.ProfissionalServicos;

            _context.Servico.Update(servico);
            _context.SaveChanges();
            return servico;
        }

        public void Deletar(int idServico)
        {
            Servico servico = BuscarPorId(idServico);
            servico.FlAtivo = false;
            _context.SaveChanges();
        }
    }
}
