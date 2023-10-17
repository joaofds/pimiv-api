using Models;

namespace Contracts
{
    public interface IUsuarioRepository
    {
        void create(Usuario usuario);
        Task<bool> saveAsync();
    }
}
