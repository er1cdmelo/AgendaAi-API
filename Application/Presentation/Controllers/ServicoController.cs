using Application.Application.AppServices;
using Application.Domain.Entities;
using Application.Infra.DTO;
using Application.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Application.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicoController : ControllerBase
    {
        private readonly ServicoAppServices _servicoApp;
        public ServicoController(ServicoAppServices servicoApp)
        {
            _servicoApp = servicoApp;
        }

        [HttpGet("BuscarPorId")]
        public IActionResult BuscarPorId(int idServico)
        {
            try
            {
                Servico servico = _servicoApp.BuscarPorId(idServico);
                return Ok(servico);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("BuscarTodos")]
        public IActionResult BuscarTodos()
        {
            try
            {
                List<Servico> servicos = _servicoApp.BuscarTodos();
                return Ok(servicos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Registrar")]
        public IActionResult Registrar(ServicoTO servicoTO)
        {
            try
            {
                int idServico = _servicoApp.Registrar(servicoTO);
                return Ok(idServico);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Atualizar")]
        public IActionResult Atualizar(ServicoTO servicoTO)
        {
            try
            {
                Servico servico = _servicoApp.Atualizar(servicoTO);
                return Ok(servico);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Deletar")]
        public IActionResult Deletar(int idServico)
        {
            try
            {
                _servicoApp.Deletar(idServico);
                AiResponse aiResponse = new AiResponse()
                {
                    code = 200,
                    message = "Serviço deletado com sucesso!"
                };
                return Ok(aiResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
