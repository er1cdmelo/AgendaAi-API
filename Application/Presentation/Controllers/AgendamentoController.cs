using Application.Application.AppServices;
using Application.Data.Entities;
using Application.Infra.DTO;
using Application.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Application.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentoController : ControllerBase
    {
        private readonly AgendamentoAppServices _agendamentoApp;
        private readonly ProfissionalAppServices _profissionalApp;
        public AgendamentoController(AgendamentoAppServices agendamentoApp, ProfissionalAppServices profissionalApp)
        {
            _agendamentoApp = agendamentoApp;
            _profissionalApp = profissionalApp;
        }

        [HttpGet("BuscarPorProfissional")]
        public IActionResult BuscarPorProfissional(int idPessoa)
        {
            try
            {
                List<AgendamentoTO> agendamentos = _agendamentoApp.BuscarListaProfissional(idPessoa);
                AiResponse response = new AiResponse()
                {
                    data = JsonConvert.SerializeObject(agendamentos),
                    message = "Agendamentos encontrados com sucesso!",
                    code = 200
                };
                return Ok(agendamentos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("BuscarPorCliente")]
        public IActionResult BuscarPorCliente(int idPessoa)
        {
            try
            {
                List<AgendamentoTO> agendamentos = _agendamentoApp.BuscarListaCliente(idPessoa);
                AiResponse response = new AiResponse()
                {
                    data = JsonConvert.SerializeObject(agendamentos),
                    message = "Agendamentos encontrados com sucesso!",
                    code = 200
                };
                return Ok(agendamentos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #region Horario Disponivel
        [HttpGet("HorarioDisponivel")]
        public IActionResult BuscarHorariosDisponiveis(int idProfissional)
        {
            try
            {
                // Pega apenas horários futuros
                List<HorarioDisponivelTO> horariosDisponiveis = _agendamentoApp.BuscarHorariosDisponiveis(idProfissional)
                    .Where(h => h.DtHora > DateTimeOffset.Now).ToList();
                AiResponse response = new AiResponse()
                {
                    data = JsonConvert.SerializeObject(horariosDisponiveis),
                    message = "Horários disponíveis encontrados com sucesso!",
                    code = 200
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                AiResponse response = new AiResponse()
                {
                    message = ex.Message,
                    code = 400
                };
                return BadRequest(response);
            }
        }

        [HttpGet("HorarioDisponivelUsuario")]
        public IActionResult BuscarHorariosDisponiveisUsuario(int idUsuario)
        {
            try
            {
                Profissional profissional = _profissionalApp.BuscaPorUsuarioId(idUsuario);
                DateTimeOffset agora = DateTimeOffset.Now;
                List<HorarioDisponivelTO> horariosDisponiveis = _agendamentoApp.BuscarHorariosDisponiveis(profissional.IdProfissional)
                    .Where(h => h.DtHora > agora).ToList();
                AiResponse response = new AiResponse()
                {
                    data = JsonConvert.SerializeObject(horariosDisponiveis),
                    message = "Horários disponíveis encontrados com sucesso!",
                    code = 200
                };

                return Ok(horariosDisponiveis);
            }
            catch (Exception ex)
            {
                AiResponse response = new AiResponse()
                {
                    message = ex.Message,
                    code = 400
                };
                return BadRequest(response);
            }
        }

        [HttpPost("SalvarHorario")]
        public IActionResult SalvarHorario(HorarioDisponivelTO horarioTO)
        {
            try
            {
                List<string> erros = new List<string>();
                int idProfissional = _profissionalApp.BuscaIdProfissional(horarioTO.IdCriador);
                if (idProfissional <= 0)
                {
                    erros.Add("Profissional não encontrado");
                }
                if (horarioTO.DtHora < DateTimeOffset.Now)
                {
                    erros.Add("Data e hora não podem ser menores que a data e hora atual");
                }
                if (horarioTO.DtHora > DateTimeOffset.Now.AddDays(30))
                {
                    erros.Add("Data e hora não podem ser maiores que 30 dias da data e hora atual");
                }
                if (erros.Any())
                {
                    AiResponse response = new AiResponse()
                    {
                        message = "Erro ao salvar horário",
                        code = 400,
                        errors = erros.ToArray()
                    };
                    return BadRequest(response);
                }
                _agendamentoApp.SalvarHorario(horarioTO, idProfissional);
                AiResponse responseSuccess = new AiResponse()
                {
                    message = "Horário salvo com sucesso!",
                    code = 200
                };
                return Ok(responseSuccess);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
