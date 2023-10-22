using Contracts;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Repositories
{
    public class BeneficioRepository : IBeneficioRepository
    {
        private readonly FolhaPagamentoContext _context;

        public BeneficioRepository(FolhaPagamentoContext context)
        {
            _context = context;
        }

        public void create(Beneficio beneficio)
        {
            _context.Add(beneficio);
        }

        public void update(Beneficio beneficio)
        {
            _context.Entry(beneficio).State = EntityState.Modified;
        }

        public void delete(Beneficio beneficio)
        {
            _context.Remove(beneficio);
        }

        public async Task<Beneficio> getById(int id)
        {
            var beneficio = await _context.Beneficio.Where(u => u.Id == id).FirstOrDefaultAsync();
            return beneficio!;
        }

        public async Task<IEnumerable<Beneficio>> getAll()
        {
            return await _context.Beneficio.ToListAsync();
        }

        public async Task<bool> saveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
