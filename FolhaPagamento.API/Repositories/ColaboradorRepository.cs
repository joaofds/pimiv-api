using Contracts;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Repositories
{
    public class ColaboradorRepository : IColaboradorRepository
    {
        private readonly FolhaPagamentoContext _context;

        public ColaboradorRepository(FolhaPagamentoContext context)
        {
            _context = context;
        }

        public void create(Colaborador colaborador)
        {
            _context.Add(colaborador);
        }

        public void update(Colaborador colaborador)
        {
            _context.Entry(colaborador).State = EntityState.Modified;
        }

        public void delete(Colaborador colaborador)
        {
            _context.Remove(colaborador);
        }

        public async Task<Colaborador> getById(int id)
        {
            var colaborador = await _context.Colaborador.Where(u => u.Id == id).FirstOrDefaultAsync();
            return colaborador!;
        }

        public async Task<IEnumerable<Colaborador>> getAll()
        {
            return await _context.Colaborador.ToListAsync();
        }

        public async Task<bool> saveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
