using Application.Application.AppServices;
using Application.Models.Responses;
using Application.Presentation.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Application.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreferenciaController : ControllerBase
    {
        private readonly PreferenciaAppServices _prefApp;
        public PreferenciaController(PreferenciaAppServices prefApp)
        {
            _prefApp = prefApp;
        }

        [HttpGet("BuscarPorId")]
        public IActionResult BuscarPorId(int preferenciaId)
        {
            try
            {
                var preferencia = _prefApp.BuscarPorId(preferenciaId);
                return Ok(preferencia);
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
                var preferencias = _prefApp.BuscarTodos();
                return Ok(preferencias);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Atualizar")]
        public IActionResult Atualizar(List<PreferenciaVM> prefsVm)
        {
            try
            {
                _prefApp.Atualizar(prefsVm);
                AiResponse response = new AiResponse()
                {
                    code = 200,
                    message = "Preferências atualizadas com sucesso!"
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
