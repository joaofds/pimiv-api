using Contracts;
using Microsoft.EntityFrameworkCore;
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

        public void update(Usuario usuario)
        {
            _context.Entry(usuario).State = EntityState.Modified;
        }

        public void delete(Usuario usuario)
        {
            _context.Remove(usuario);
        }

        public async Task<Usuario> getById(int id)
        {
            var usuario = await _context.Usuario.Where(u => u.Id == id).FirstOrDefaultAsync();
            return usuario!;
        }

        public async Task<IEnumerable<Usuario>> getAll()
        {
            return await _context.Usuario.ToListAsync();
        }

        public async Task<bool> saveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
