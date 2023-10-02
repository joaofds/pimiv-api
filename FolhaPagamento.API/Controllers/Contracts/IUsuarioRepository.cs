using Models;

namespace Controllers.Contracts
{
    public interface IUsuarioRepository
    {
        void create(Usuario usuario);
        Task<bool> saveAsync();
    }
}
