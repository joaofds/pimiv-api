using Models;
using Microsoft.AspNetCore.Mvc;
using Contracts;

namespace Controllers
{
    [ApiController]
    [Route("api/reservas")]
    public class ReservaController : Controller
    {
        private readonly IReservaRepository _reservaRepository;

        public ReservaController(IReservaRepository reservaRepository)
        {
            _reservaRepository = reservaRepository;
        }

        [HttpPost]
        public async Task<ActionResult> create(Reserva reserva)
        {
            _reservaRepository.create(reserva);
            if (await _reservaRepository.saveAsync())
            {
                return Ok("Reserva cadastrada com sucesso.");
            }

            return BadRequest("Oops... erro ao salvar a reserva.");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> getById(int id)
        {
            Reserva reserva = await _reservaRepository.getById(id);
            if (reserva == null)
            {
                return NotFound("Oops... Reserva não encontrada.");
            }

            return Ok(reserva);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> delete(int id)
        {
            Reserva reserva = await _reservaRepository.getById(id);
            if (reserva == null)
            {
                return NotFound("Oops... Reserva não encontrada.");
            }

            _reservaRepository.delete(reserva);
            if(await _reservaRepository.saveAsync())
            {
                return Ok("Sucesso! A reserva foi excluida.");
            }

            return BadRequest("Oops... erro ao tentar excluir reserva.");
        }

        [HttpPatch]
        public async Task<ActionResult> update(Reserva reserva)
        {
            _reservaRepository.update(reserva);
            if (await _reservaRepository.saveAsync())
            {
                return Ok("Sucesso! Reserva atualizada.");
            }

            return BadRequest("Oops... erro ao alterar dados da reserva.");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reserva>>> getAll()
        {
            return Ok(await _reservaRepository.getAll());
        }
    }
}
