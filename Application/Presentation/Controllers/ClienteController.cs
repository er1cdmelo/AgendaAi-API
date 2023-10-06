using Application.Application.AppServices;
using Application.Domain.Entities;
using Application.Models.Responses;
using Application.Presentation.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Application.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteAppServices _clienteApp;
        private readonly IMapper _mapper;
        public ClienteController(ClienteAppServices clienteApp, IMapper mapper)
        {
            _clienteApp = clienteApp;
            _mapper = mapper;
        }

        [HttpGet("BuscarPorUsuario")]
        public IActionResult BuscarPorUsuario(int idUsuario)
        {
            try
            {
                Cliente cliente = _clienteApp.BuscarPorUsuario(idUsuario);
                return cliente.IdUsuario > 0 ? Ok(cliente) : Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("BuscarPorId")]
        public IActionResult BuscarPorId(int idCliente)
        {
            try
            {
                Cliente cliente = _clienteApp.BuscarPorId(idCliente);
                return cliente.IdCliente > 0 ? Ok(cliente) : BadRequest("Não foi encontrado um cliente.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Registrar")]
        public IActionResult Registrar(ClienteVM clienteVM)
        {
            try
            {
                Cliente cliente = _mapper.Map<Cliente>(clienteVM);
                int idCliente = _clienteApp.Registrar(cliente);
                if (idCliente > 0)
                {
                    cliente.IdCliente = idCliente;
                    AiResponse response = new AiResponse()
                    {
                        data = JsonConvert.SerializeObject(cliente),
                        message = "Cliente registrado com sucesso!",
                        code = 200
                    };
                    return Ok(response);
                } else
                    return BadRequest("Não foi possível registrar o cliente.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
