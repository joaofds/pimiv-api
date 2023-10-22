using Contracts;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Repositories
{
    public class CargoRepository : ICargoRepository
    {
        private readonly FolhaPagamentoContext _context;

        public CargoRepository(FolhaPagamentoContext context)
        {
            _context = context;
        }

        public void create(Cargo cargo)
        {
            _context.Add(cargo);
        }

        public void update(Cargo cargo)
        {
            _context.Entry(cargo).State = EntityState.Modified;
        }

        public void delete(Cargo cargo)
        {
            _context.Remove(cargo);
        }

        public async Task<Cargo> getById(int id)
        {
            var cargo = await _context.Cargo.Where(u => u.Id == id).FirstOrDefaultAsync();
            return cargo!;
        }

        public async Task<IEnumerable<Cargo>> getAll()
        {
            return await _context.Cargo.ToListAsync();
        }

        public async Task<bool> saveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
