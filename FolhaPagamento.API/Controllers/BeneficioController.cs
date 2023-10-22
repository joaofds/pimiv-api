using Models;
using Microsoft.AspNetCore.Mvc;
using Contracts;

namespace Controllers
{
    [ApiController]
    [Route("api/beneficios")]
    public class BeneficioController : Controller
    {
        private readonly IBeneficioRepository _beneficioRepository;

        public BeneficioController(IBeneficioRepository beneficioRepository)
        {
            _beneficioRepository = beneficioRepository;
        }

        [HttpPost]
        public async Task<ActionResult> create(Beneficio beneficio)
        {
            _beneficioRepository.create(beneficio);
            if (await _beneficioRepository.saveAsync())
            {
                return Ok("Benefício cadastrado com sucesso.");
            }

            return BadRequest("Oops... erro ao salvar o benefício.");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> getById(int id)
        {
            Beneficio beneficio = await _beneficioRepository.getById(id);
            if (beneficio == null)
            {
                return NotFound("Oops... Benefício não encontrado.");
            }

            return Ok(beneficio);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> delete(int id)
        {
            Beneficio beneficio = await _beneficioRepository.getById(id);
            if (beneficio == null)
            {
                return NotFound("Oops... Benefício não encontrado.");
            }

            _beneficioRepository.delete(beneficio);
            if(await _beneficioRepository.saveAsync())
            {
                return Ok("Sucesso! O benefício foi excluido.");
            }

            return BadRequest("Oops... Erro ao tentar excluir benefício.");
        }

        [HttpPatch]
        public async Task<ActionResult> update(Beneficio beneficio)
        {
            _beneficioRepository.update(beneficio);
            if (await _beneficioRepository.saveAsync())
            {
                return Ok("Sucesso! Benefício atualizado.");
            }

            return BadRequest("Oops... erro ao alterar dados do benefício.");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Beneficio>>> getAll()
        {
            return Ok(await _beneficioRepository.getAll());
        }
    }
}
