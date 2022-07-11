using CiaArea.Services.Interfaces;
using CiaArea.ViewModels.Piloto;
using Microsoft.AspNetCore.Mvc;

namespace CiaArea.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PilotoController : ControllerBase
    {
        private readonly IPilotoService _service;

        public PilotoController(IPilotoService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Add([FromBody] IncluirPilotoVM dados)
        {
            var piloto = _service.Add(dados);

            return CreatedAtAction(nameof(GetById), new { id = piloto.Id }, piloto);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] EditarPilotoVM dados)
        {
            if (id != dados.Id)
                return BadRequest("O id informado na url é diferente do id informado no corpo da requisição");

            var piloto = _service.Update(dados);

            if (piloto == null)
                return NotFound();

            return Ok(piloto);
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(Guid id)
        {
            var piloto = _service.Remove(id);

            if (!piloto)
                return NotFound();

            return NoContent();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _service.Get();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var piloto = _service.GetById(id);

            if (piloto == null)
                return NotFound();

            return Ok(piloto);
        }
    }
}
