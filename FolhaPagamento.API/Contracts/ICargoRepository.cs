using Models;

namespace Contracts
{
    public interface ICargoRepository
    {
        void create(Cargo cargo);
        void update(Cargo cargo);
        void delete(Cargo cargo);
        Task<Cargo> getById(int id);
        Task<IEnumerable<Cargo>> getAll();
        Task<bool> saveAsync();
    }
}
