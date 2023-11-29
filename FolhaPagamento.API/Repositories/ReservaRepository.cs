using Contracts;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Repositories
{
    public class ReservaRepository : IReservaRepository
    {
        private readonly FolhaPagamentoContext _context;

        public ReservaRepository(FolhaPagamentoContext context)
        {
            _context = context;
        }

        public void create(Reserva reserva)
        {
            _context.Add(reserva);
        }

        public void update(Reserva reserva)
        {
            _context.Entry(reserva).State = EntityState.Modified;
        }

        public void delete(Reserva reserva)
        {
            _context.Remove(reserva);
        }

        public async Task<Reserva> getById(int id)
        {
            var reserva = await _context.Reserva.Where(u => u.Id == id).FirstOrDefaultAsync();
            return reserva!;
        }

        public async Task<IEnumerable<Reserva>> getAll()
        {
            return await _context.Reserva.ToListAsync();
        }

        public async Task<bool> saveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
