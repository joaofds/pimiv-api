using Models;

namespace Contracts
{
    public interface IFolhaPagamentoRepository
    {
        void create(FolhaPagamento folhaPagamento);
        void update(FolhaPagamento folhaPagamento);
        void delete(FolhaPagamento folhaPagamento);
        Task<FolhaPagamento> getById(int id);
        Task<IEnumerable<FolhaPagamento>> getAll();
        Task<bool> saveAsync();
    }
}
