using Application.Application.Global;
using Application.Data.Entities;
using Application.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Data.Repositories
{
    public class AgendamentoRepository
    {
        private readonly AgendaContext _context;
        public AgendamentoRepository(AgendaContext context)
        {
            _context = context;
        }

        public List<Agendamento> BuscarTodos() 
        {
            try
            {
                List<Agendamento> agendamentos = _context.Agendamento.Include(a => a.Cliente).ToList();
                agendamentos.ForEach(a => a.Cliente.Agendamentos.Clear());
                return agendamentos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Agendamento> BuscarAgendamentosProfissional(int idProfissional)
        {
            try
            {
                List<Agendamento> agendamentos = _context.Agendamento.Where(a => a.IdProfissional == idProfissional).Include(a => a.Cliente).ToList().Select(a =>
                {
                    var agendamento = a;
                    a.Cliente.Agendamentos.Clear();
                    return a;
                }).ToList();
                return agendamentos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Agendamento> BuscarAgendamentosCliente(int idCliente)
        {
            try
            {
                List<Agendamento> agendamentos = _context.Agendamento.Where(a => a.IdCliente == idCliente).Include(a => a.Profissional).ToList().Select(a =>
                {
                    var agendamento = a;
                    a.Profissional.Agendamentos.Clear();
                    return a;
                }).ToList();
                return agendamentos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Agendamento> BuscarCancelados(int idProfissional)
        {
            try
            {
                List<Agendamento> agendamentos = _context.Agendamento.Where(a => a.IdProfissional == idProfissional && 
                                a.Status == (int) Enums.StatusAgendamento.Pendente).ToList();
                return agendamentos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Agendamento BuscarAgendamentoProfissional(int idAgendamento, int idProfissional)
        {
            try
            {
                Agendamento agendamento = _context.Agendamento.FirstOrDefault(a => a.IdAgendamento == idAgendamento && 
                               a.IdProfissional == idProfissional) ?? new Agendamento();
                return agendamento;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Agendamento BuscarAgendamentoCliente(int idAgendamento, int idCliente)
        {
            try
            {
                Agendamento agendamento = _context.Agendamento.FirstOrDefault(a => a.IdAgendamento == idAgendamento && 
                                              a.IdCliente == idCliente) ?? new Agendamento();
                return agendamento;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Agendamento CriarAgendamento(Agendamento agendamento)
        {
            try
            {
                _context.Agendamento.Add(agendamento);
                _context.SaveChanges();
                return agendamento;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Agendamento AtualizarAgendamento(Agendamento agendamento)
        {
            try
            {
                _context.Agendamento.Update(agendamento);
                _context.SaveChanges();
                return agendamento;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Agendamento CancelarAgendamento(Agendamento agendamento)
        {
            try
            {
                agendamento.Status = (int) Enums.StatusAgendamento.Cancelado;
                _context.Agendamento.Update(agendamento);
                _context.SaveChanges();
                return agendamento;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #region Horario Disponivel
        public List<HorarioDisponivel> BuscarHorariosDisponiveis(int idProfissional)
        {
            try
            {
                List<HorarioDisponivel> horarios = _context.HorarioDisponivel.Where(h => h.IdProfissional == idProfissional).OrderBy(h => h.DtHora).ToList();
                return horarios;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public HorarioDisponivel BuscarHorarioDisponivel(int idHorarioDisponivel)
        {
            try
            {
                HorarioDisponivel horario = _context.HorarioDisponivel.FirstOrDefault(h => h.Id == idHorarioDisponivel) ?? new HorarioDisponivel();
                return horario;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public HorarioDisponivel? BuscarHorarioPorData(DateTimeOffset data, int idProfissional)
        {
            try
            {
                HorarioDisponivel? horario = _context.HorarioDisponivel
                    .FirstOrDefault(h => h.DtHora == data && h.IdProfissional == idProfissional);
                return horario;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public HorarioDisponivel CriarHorario(HorarioDisponivel horario)
        {
            try
            {
                _context.HorarioDisponivel.Add(horario);
                _context.SaveChanges();
                return horario;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
