using Models;
using Repositories;
using Microsoft.AspNetCore.Mvc;
using Contracts;

namespace Controllers
{
    [ApiController]
    [Route("api/colaborador")]
    public class ColaboradorController : Controller
    {
        private readonly IColaboradorRepository _colaboradorRepository;

        public ColaboradorController(IColaboradorRepository colaboradorRepository)
        {
            _colaboradorRepository = colaboradorRepository;
        }

        [HttpPost]
        public async Task<ActionResult> create(Colaborador colaborador)
        {
            _colaboradorRepository.create(colaborador);
            if (await _colaboradorRepository.saveAsync())
            {
                return Ok("Colaborador cadastrado com sucesso.");
            }

            return BadRequest("Oops... erro ao salver o colaborador.");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> getById(int id)
        {
            Colaborador colaborador = await _colaboradorRepository.getById(id);
            if (colaborador == null)
            {
                return NotFound("Oops... Colaborador não encontrado.");
            }

            return Ok(colaborador);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> delete(int id)
        {
            Colaborador colaborador = await _colaboradorRepository.getById(id);
            if (colaborador == null)
            {
                return NotFound("Oops... Colaborador não encontrado.");
            }

            _colaboradorRepository.delete(colaborador);
            if(await _colaboradorRepository.saveAsync())
            {
                return Ok("Sucesso! O colaborador foi excluido.");
            }

            return BadRequest("Oops... Erro ao tentar excluir colaborador.");
        }

        [HttpPut]
        public async Task<ActionResult> update(Colaborador colaborador)
        {
            _colaboradorRepository.update(colaborador);
            if (await _colaboradorRepository.saveAsync())
            {
                return Ok("Sucesso! Colaborador atualizado.");
            }

            return BadRequest("Oops... erro ao alterar dados do colaborador.");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Colaborador>>> getAll()
        {
            return Ok(await _colaboradorRepository.getAll());
        }
    }
}
