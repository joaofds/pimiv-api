using Models;
using Microsoft.AspNetCore.Mvc;
using Contracts;

namespace Controllers
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost]
        public async Task<ActionResult> create(Usuario usuario)
        {
            _usuarioRepository.create(usuario);
            if (await _usuarioRepository.saveAsync())
            {
                return Ok("Usuário cadastrado com sucesso.");
            }

            return BadRequest("Oops... erro ao salvar o usuário.");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> getById(int id)
        {
            Usuario usuario = await _usuarioRepository.getById(id);
            if (usuario == null)
            {
                return NotFound("Oops... Usuário não encontrado.");
            }

            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> delete(int id)
        {
            Usuario usuario = await _usuarioRepository.getById(id);
            if (usuario == null)
            {
                return NotFound("Oops... Usuário não encontrado.");
            }

            _usuarioRepository.delete(usuario);
            if(await _usuarioRepository.saveAsync())
            {
                return Ok("Sucesso! O usuário foi excluido.");
            }

            return BadRequest("Oops... Erro ao tentar excluir usuário.");
        }

        [HttpPatch]
        public async Task<ActionResult> update(Usuario usuario)
        {
            _usuarioRepository.update(usuario);
            if (await _usuarioRepository.saveAsync())
            {
                return Ok("Sucesso! Usuário atualizado.");
            }

            return BadRequest("Oops... erro ao alterar dados do usuário.");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> getAll()
        {
            return Ok(await _usuarioRepository.getAll());
        }
    }
}
