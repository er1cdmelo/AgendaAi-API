using Application.Models;

namespace Application.Data.Repositories
{
    public class ProfissionalRepository
    {
        private readonly AgendaContext _context;

        public ProfissionalRepository(AgendaContext context)
        {
            _context = context;
        }

        public List<Profissional> BuscarTodos()
        {
            List<Profissional> profissionais = _context.Profissional.ToList();
            return profissionais;
        } 

        public Profissional BuscarPorCdIdentificacao(int cdIdentificacao)
        {
            Profissional profissional = _context.Profissional.FirstOrDefault(u => u.CdIdentificacao == cdIdentificacao) ?? new Profissional();
            return profissional;
        }
        public Profissional BuscarPorId(int idProfissional)
        {
            // O nome da tabela de Profissionais é Profissional
            Profissional profissional = _context.Profissional.FirstOrDefault(u => u.IdProfissional == idProfissional) ?? new Profissional();
            return profissional;
        }

        public void Cadastrar(Profissional profissional)
        {
            // Verifica se o email e o username já estão cadastrados
            var existeCd = BuscarPorCdIdentificacao(profissional.CdIdentificacao);
            if (!String.IsNullOrEmpty(existeCd.Nome))
            {
                throw new Exception("Código de identificação já cadastrado");
            }

            _context.Profissional.Add(profissional);
            _context.SaveChanges();
        }

        public void Atualizar(Profissional profissional)
        {
            _context.Profissional.Update(profissional);
            _context.SaveChanges();
        }

        public void Deletar(Profissional profissional)
        {
            _context.Profissional.Remove(profissional);
            _context.SaveChanges();
        }
    }
}