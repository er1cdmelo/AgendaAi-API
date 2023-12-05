using Application.Domain.Entities;
using Application.Presentation.ViewModels;

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

        public List<Preferencia> BuscarTodos()
        {
            try
            {
                var preferencias = _context.Preferencia.ToList();
                return preferencias;
            }
            catch (Exception)
            {
                throw;
            }
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

        public void Atualizar(List<PreferenciaVM> prefsVm)
        {
            try
            {
                List<int> idsPreferencia = prefsVm.Select(p => p.IdPreferencia).ToList();
                List<Preferencia> preferencias = _context.Preferencia.Where(p => idsPreferencia.Contains(p.IdPreferencia)).ToList();
                foreach (Preferencia pref in preferencias)
                {
                    PreferenciaVM prefVm = prefsVm.FirstOrDefault(p => p.IdPreferencia == pref.IdPreferencia) ?? new PreferenciaVM();
                    pref.ValorPreferencia = prefVm.ValorPreferencia;
                }
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
