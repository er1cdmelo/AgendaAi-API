using Application.Data.Global;
using Application.Data.Repositories;
using Application.Domain.Entities;
using Application.Infra.DTO;
using AutoMapper;

namespace Application.Application.AppServices
{
    public class AgendamentoAppServices
    {
        private readonly AgendamentoRepository _repository;
        private readonly PreferenciaAppServices _prefApp;
        private readonly IMapper _mapper;
        public AgendamentoAppServices(AgendamentoRepository repository, PreferenciaAppServices prefApp, IMapper mapper)
        {
            _repository = repository;
            _prefApp = prefApp;
            _mapper = mapper;
        }

        public List<AgendamentoTO> BuscarListaProfissional(int idProfissional)
        {
            List<Agendamento> agendamentos = _repository.BuscarAgendamentosProfissional(idProfissional);
            List<AgendamentoTO> agendamentosTO = new List<AgendamentoTO>();
            if(agendamentos != null && agendamentos.Any())
            {
                agendamentosTO = _mapper.Map<List<AgendamentoTO>>(agendamentos);
            }

            return agendamentosTO;
        }

        public List<AgendamentoTO> BuscarListaCliente(int idCliente)
        {
            List<Agendamento> agendamentos = _repository.BuscarAgendamentosCliente(idCliente);
            List<AgendamentoTO> agendamentosTO = new List<AgendamentoTO>();
            if (agendamentos != null && agendamentos.Any())
            {
                agendamentosTO = _mapper.Map<List<AgendamentoTO>>(agendamentos);
            }

            return agendamentosTO;
        }

        public List<AgendamentoTO> BuscarCancelados(int idProfissional)
        {
            List<Agendamento> agendamentos = _repository.BuscarCancelados(idProfissional);
            List<AgendamentoTO> agendamentosTO = new List<AgendamentoTO>();
            if (agendamentos != null && agendamentos.Any())
            {
                agendamentosTO = _mapper.Map<List<AgendamentoTO>>(agendamentos);
            }

            return agendamentosTO;
        }

        public AgendamentoTO BuscarPorProfissional(int idAgendamento, int idProfissional)
        {
            Agendamento agendamento = _repository.BuscarAgendamentoProfissional(idAgendamento, idProfissional);
            AgendamentoTO agendamentoTO = new AgendamentoTO();
            if (agendamento != null)
            {
                agendamentoTO = _mapper.Map<AgendamentoTO>(agendamento);
            }

            return agendamentoTO;
        }

        public AgendamentoTO BuscarPorCliente(int idAgendamento, int idCliente)
        {
            Agendamento agendamento = _repository.BuscarAgendamentoCliente(idAgendamento, idCliente);
            AgendamentoTO agendamentoTO = new AgendamentoTO();
            if (agendamento != null)
            {
                agendamentoTO = _mapper.Map<AgendamentoTO>(agendamento);
            }

            return agendamentoTO;
        }

        public List<string> Salvar(AgendamentoTO agendamentoTO)
        {
            List<string> erros = new List<string>();
            try
            {
                Agendamento agendamento = _mapper.Map<Agendamento>(agendamentoTO);
                HorarioDisponivel? horario = _repository.BuscarHorarioPorData
                    (agendamentoTO.DtAgendamento, agendamentoTO.IdProfissional);

                if(horario != null)
                {
                    agendamento.IdDataHora = horario.Id;
                    agendamento.DtRegistro = DateTimeOffset.Now;
                    agendamento.Status = _prefApp.BuscarPorCodigo("INICIA_ATENDIMENTO_CONFIRMADO").Equals("1") ?
                        (int) Enums.StatusAgendamento.Confirmado : (int) Enums.StatusAgendamento.Pendente;
                    agendamento = _repository.CriarAgendamento(agendamento);
                } else
                {
                    erros.Add("Horário não disponível");
                }
            }
            catch (ArgumentException ex)
            {
                ex.HelpLink = "Erro ao criar agendamento";
                ex.Source = "AgendamentoAppServices";
                erros.Add(ex.Message);
                throw ex;
            }
            return erros;
        }

        #region Horario Disponivel
        public List<HorarioDisponivelTO> BuscarHorariosDisponiveis(int idProfissional)
        {
            List<HorarioDisponivelTO> horariosTO = new List<HorarioDisponivelTO>();
            try
            {
                List<HorarioDisponivel> horarios = _repository.BuscarHorariosDisponiveis(idProfissional);
                if (horarios != null && horarios.Any())
                {
                    horariosTO = _mapper.Map<List<HorarioDisponivelTO>>(horarios);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return horariosTO;
        }

        public void SalvarHorario(HorarioDisponivelTO horarioTO, int idProfissional)
        {
            try
            {
                HorarioDisponivel horario = _mapper.Map<HorarioDisponivel>(horarioTO);
                horario.IdProfissional = idProfissional;
                _repository.CriarHorario(horario);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
