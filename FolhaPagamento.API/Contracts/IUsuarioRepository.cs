using Models;

namespace Contracts
{
    public interface IUsuarioRepository
    {
        void create(Usuario usuario);
        void update(Usuario usuario);
        void delete(Usuario usuario);
        Task<Usuario> getById(int id);
        Task<IEnumerable<Usuario>> getAll();
        Task<bool> saveAsync();
    }
}
