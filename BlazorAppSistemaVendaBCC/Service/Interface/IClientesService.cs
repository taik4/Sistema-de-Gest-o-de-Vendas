using BlazorAppSistemaVendaBCC.Entities;

namespace BlazorAppSistemaVendaBCC.Service.Interface
{
    public interface IClientesService
    {
        Task AdicionarAsync(Cliente cliente);
        Task AlterarAsync(Cliente cliente);
        Task ExcluirAsync(int id);
        
        Task<IEnumerable<Cliente>> ListarTodos();
        Task<Cliente> PesquisarPorID(int id);
        Task<(IEnumerable<Cliente> clientes, int TotalRegistros)> ListarPaginado(int numeroPagina, int itensPorPagina);
    }
}
