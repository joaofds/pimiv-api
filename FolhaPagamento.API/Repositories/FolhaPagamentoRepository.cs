using Contracts;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Repositories
{
    public class FolhaPagamentoRepository : IFolhaPagamentoRepository
    {
        private readonly FolhaPagamentoContext _context;

        public FolhaPagamentoRepository(FolhaPagamentoContext context)
        {
            _context = context;
        }

        public void create(FolhaPagamento folhaPagamento)
        {
            _context.Add(folhaPagamento);
        }

        public void update(FolhaPagamento folhaPagamento)
        {
            _context.Entry(folhaPagamento).State = EntityState.Modified;
        }

        public void delete(FolhaPagamento folhaPagamento)
        {
            _context.Remove(folhaPagamento);
        }

        public async Task<FolhaPagamento> getById(int id)
        {
            var folhaPagamento = await _context.FolhaPagamento.Where(f => f.Id == id).FirstOrDefaultAsync();
            return folhaPagamento!;
        }

        public async Task<IEnumerable<FolhaPagamento>> getAll()
        {
            return await _context.FolhaPagamento.ToListAsync();
        }

        public async Task<bool> saveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
