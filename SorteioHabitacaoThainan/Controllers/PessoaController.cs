using SorteioHabitacaoThainan.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace SorteioHabitacaoThainan.Controllers
{
    [Route("api/v1/pessoa")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaService _pessoaService;

        public PessoaController(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        [HttpGet("sorteio/participante/lista")]
        public IActionResult RetornaListaParticipante()
        {
            var result = _pessoaService.ListaParticipante();
            return Ok(result);
        }

        [HttpGet("sorteio/participante/sortear")]
        public IActionResult RealizaSorteio()
        {
            var result = _pessoaService.Sortear();
            return Ok(result);
        }
    }
}
