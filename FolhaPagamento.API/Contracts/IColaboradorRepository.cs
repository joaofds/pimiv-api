using Models;

namespace Contracts
{
    public interface IColaboradorRepository
    {
        void create(Colaborador colaborador);
        void update(Colaborador colaborador);
        void delete(Colaborador colaborador);
        Task<Colaborador> getById(int id);
        Task<IEnumerable<Colaborador>> getAll();
        Task<bool> saveAsync();
    }
}
