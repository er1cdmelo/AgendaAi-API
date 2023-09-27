using Application.Domain.Entities;

namespace Application.Data.Repositories
{
    public class PreferenciaRepository
    {
        private readonly AgendaContext _context;
        public PreferenciaRepository(AgendaContext context)
        {
            _context = context;
        }
        public PreferenciaRepository()
        {
            _context = new AgendaContext();
        }
        public Preferencia BuscarPorCodigo(string cdPreferencia) 
        {
            try
            {
                // O nome da tabela de Preferencias é Preferencia
                Preferencia preferencia = _context.Preferencia.FirstOrDefault(p => p.CdPreferencia == cdPreferencia) ?? new Preferencia();
                return preferencia;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Preferencia BuscarPorId(int idPreferencia)
        {
            try
            {
                // O nome da tabela de Preferencias é Preferencia
                Preferencia preferencia = _context.Preferencia.FirstOrDefault(p => p.IdPreferencia == idPreferencia) ?? new Preferencia();
                return preferencia;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(Preferencia preferencia)
        {
            try
            {
                _context.Preferencia.Add(preferencia);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Atualizar(Preferencia preferencia)
        {
            try
            {
                _context.Preferencia.Update(preferencia);
                _context.SaveChanges();
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
                _context.Preferencia.Remove(preferencia);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Preferencia> Listar()
        {
            try
            {
                List<Preferencia> preferencias = _context.Preferencia.ToList();
                return preferencias;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
