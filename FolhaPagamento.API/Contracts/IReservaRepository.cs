using Models;

namespace Contracts
{
    public interface IReservaRepository
    {
        void create(Reserva reserva);
        void update(Reserva reserva);
        void delete(Reserva reserva);
        Task<Reserva> getById(int id);
        Task<IEnumerable<Reserva>> getAll();
        Task<bool> saveAsync();
    }
}
