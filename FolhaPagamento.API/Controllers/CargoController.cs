using Models;
using Microsoft.AspNetCore.Mvc;
using Contracts;

namespace Controllers
{
    [ApiController]
    [Route("api/cargos")]
    public class CargoController : Controller
    {
        private readonly ICargoRepository _cargoRepository;

        public CargoController(ICargoRepository cargoRepository)
        {
            _cargoRepository = cargoRepository;
        }

        [HttpPost]
        public async Task<ActionResult> create(Cargo cargo)
        {
            _cargoRepository.create(cargo);
            if (await _cargoRepository.saveAsync())
            {
                return Ok("Cargo cadastrado com sucesso.");
            }

            return BadRequest("Oops... erro ao salvar o cargo.");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> getById(int id)
        {
            Cargo cargo = await _cargoRepository.getById(id);
            if (cargo == null)
            {
                return NotFound("Oops... Cargo não encontrado.");
            }

            return Ok(cargo);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> delete(int id)
        {
            Cargo cargo = await _cargoRepository.getById(id);
            if (cargo == null)
            {
                return NotFound("Oops... Cargo não encontrado.");
            }

            _cargoRepository.delete(cargo);
            if(await _cargoRepository.saveAsync())
            {
                return Ok("Sucesso! O cargo foi excluido.");
            }

            return BadRequest("Oops... Erro ao tentar excluir cargo.");
        }

        [HttpPatch]
        public async Task<ActionResult> update(Cargo cargo)
        {
            _cargoRepository.update(cargo);
            if (await _cargoRepository.saveAsync())
            {
                return Ok("Sucesso! Cargo atualizado.");
            }

            return BadRequest("Oops... erro ao alterar dados do cargo.");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cargo>>> getAll()
        {
            return Ok(await _cargoRepository.getAll());
        }
    }
}
