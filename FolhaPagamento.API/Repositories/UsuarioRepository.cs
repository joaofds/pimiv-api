using Contracts;
using Models;

namespace Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly FolhaPagamentoContext _context;

        public UsuarioRepository(FolhaPagamentoContext context)
        {
            _context = context;
        }

        public void create(Usuario usuario)
        {
            _context.Add(usuario);
        }

        public async Task<bool> saveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
