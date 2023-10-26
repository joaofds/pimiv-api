using Contracts;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly FolhaPagamentoContext _context;

        public EnderecoRepository(FolhaPagamentoContext context)
        {
            _context = context;
        }

        public void create(Endereco endereco)
        {
            _context.Add(endereco);
        }

        public void update(Endereco endereco)
        {
            _context.Entry(endereco).State = EntityState.Modified;
        }

        public void delete(Endereco endereco)
        {
            _context.Remove(endereco);
        }

        public async Task<Endereco> getById(int id)
        {
            var endereco = await _context.Endereco.Where(e => e.Id == id).FirstOrDefaultAsync();
            return endereco!;
        }

        public async Task<IEnumerable<Endereco>> getAll()
        {
            return await _context.Endereco.ToListAsync();
        }

        public async Task<bool> saveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
