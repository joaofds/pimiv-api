using Models;
using Repositories;
using Microsoft.AspNetCore.Mvc;
using Controllers.Contracts;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
            if(await _usuarioRepository.saveAsync())
            {
                return Ok("Usuário cadastrado com sucesso.");
            }

            return BadRequest("Oops... erro ao salver o usuário.");
        }
    }
}
