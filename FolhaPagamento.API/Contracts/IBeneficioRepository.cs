using Models;

namespace Contracts
{
    public interface IBeneficioRepository
    {
        void create(Beneficio beneficio);
        void update(Beneficio beneficio);
        void delete(Beneficio beneficio);
        Task<Beneficio> getById(int id);
        Task<IEnumerable<Beneficio>> getAll();
        Task<bool> saveAsync();
    }
}
