using Models;
using Microsoft.AspNetCore.Mvc;
using Contracts;

namespace Controllers
{
    [ApiController]
    [Route("api/folhas-pagamento")]
    public class FolhaPagamentoController : Controller
    {
        private readonly IFolhaPagamentoRepository _folhaPagamentoRepository;

        public FolhaPagamentoController(IFolhaPagamentoRepository folhaPagamentoRepository)
        {
            _folhaPagamentoRepository = folhaPagamentoRepository;
        }

        [HttpPost]
        public async Task<ActionResult> create(FolhaPagamento folhaPagamento)
        {
            _folhaPagamentoRepository.create(folhaPagamento);
            if (await _folhaPagamentoRepository.saveAsync())
            {
                return Ok("Folha de pagamento cadastrada com sucesso.");
            }

            return BadRequest("Oops... Erro ao salvar a folha de pagamento.");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> getById(int id)
        {
            FolhaPagamento folhaPagamento = await _folhaPagamentoRepository.getById(id);
            if (folhaPagamento == null)
            {
                return NotFound("Oops... Folha de pagamento não encontrada.");
            }

            return Ok(folhaPagamento);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> delete(int id)
        {
            FolhaPagamento folhaPagamento = await _folhaPagamentoRepository.getById(id);
            if (folhaPagamento == null)
            {
                return NotFound("Oops... Folha de pagamento não encontrada.");
            }

            _folhaPagamentoRepository.delete(folhaPagamento);
            if(await _folhaPagamentoRepository.saveAsync())
            {
                return Ok("Sucesso! A folha de pagamento foi excluida.");
            }

            return BadRequest("Oops... Erro ao tentar excluir a folha de pagamento.");
        }

        [HttpPatch]
        public async Task<ActionResult> update(FolhaPagamento folhaPagamento)
        {
            _folhaPagamentoRepository.update(folhaPagamento);
            if (await _folhaPagamentoRepository.saveAsync())
            {
                return Ok("Sucesso! Folha de pagamento atualizada.");
            }

            return BadRequest("Oops... Erro ao alterar dados da folha de pagamento.");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FolhaPagamento>>> getAll()
        {
            return Ok(await _folhaPagamentoRepository.getAll());
        }
    }
}
