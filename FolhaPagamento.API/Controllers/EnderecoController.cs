using Models;
using Microsoft.AspNetCore.Mvc;
using Contracts;

namespace Controllers
{
    [ApiController]
    [Route("api/enderecos")]
    public class EnderecoController : Controller
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoController(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        [HttpPost]
        public async Task<ActionResult> create(Endereco endereco)
        {
            _enderecoRepository.create(endereco);
            if (await _enderecoRepository.saveAsync())
            {
                return Ok("Endereço cadastrado com sucesso.");
            }

            return BadRequest("Oops... erro ao salvar o endereço.");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> getById(int id)
        {
            Endereco endereco = await _enderecoRepository.getById(id);
            if (endereco == null)
            {
                return NotFound("Oops... Endereço não encontrado.");
            }

            return Ok(endereco);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> delete(int id)
        {
            Endereco endereco = await _enderecoRepository.getById(id);
            if (endereco == null)
            {
                return NotFound("Oops... Endereço não encontrado.");
            }

            _enderecoRepository.delete(endereco);
            if(await _enderecoRepository.saveAsync())
            {
                return Ok("Sucesso! O endereço foi excluido.");
            }

            return BadRequest("Oops... Erro ao tentar excluir endereço.");
        }

        [HttpPatch]
        public async Task<ActionResult> update(Endereco endereco)
        {
            _enderecoRepository.update(endereco);
            if (await _enderecoRepository.saveAsync())
            {
                return Ok("Sucesso! Endereço atualizado.");
            }

            return BadRequest("Oops... erro ao alterar dados do endereço.");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Endereco>>> getAll()
        {
            return Ok(await _enderecoRepository.getAll());
        }
    }
}
