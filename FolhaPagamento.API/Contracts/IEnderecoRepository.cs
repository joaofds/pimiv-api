using Models;

namespace Contracts
{
    public interface IEnderecoRepository
    {
        void create(Endereco endereco);
        void update(Endereco endereco);
        void delete(Endereco endereco);
        Task<Endereco> getById(int id);
        Task<IEnumerable<Endereco>> getAll();
        Task<bool> saveAsync();
    }
}
