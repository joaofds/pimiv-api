namespace FolhaPagamento.WEB.Service.Interfaces
{
    public interface IApiService
    {
        public Task<string> Get(string Endpoint);
    }
}
