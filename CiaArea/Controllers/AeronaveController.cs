using CiaArea.Services.Interfaces;
using CiaArea.ViewModels.Aeronave;
using Microsoft.AspNetCore.Mvc;

namespace CiaArea.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AeronaveController : ControllerBase
    {
        private readonly IAeronaveService _service;

        public AeronaveController(IAeronaveService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Add([FromBody] IncluirAeronaveVM data)
        {
            var aeronave = _service.Add(data);

            return CreatedAtAction(nameof(GetById), new { id = aeronave.Id }, aeronave);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] EditarAeronaveVM data)
        {
            if (id != data.Id)
                return BadRequest("O id informado na url é diferente do id informado no corpo da requisição.");

            var aeronave = _service.Update(data);

            if (aeronave == null)
                return NotFound();

            return Ok(aeronave);
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(Guid id)
        {
            var aeronave = _service.Remove(id);

            if (!aeronave)
                return NotFound();

            return NoContent();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var dados = _service.Get();

            return Ok(dados);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var aeronave = _service.GetById(id);

            if (aeronave == null)
                return NotFound();

            return Ok(aeronave);
        }
    }
}
