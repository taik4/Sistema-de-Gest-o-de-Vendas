using BlazorAppSistemaVendaBCC.Entities;

namespace BlazorAppSistemaVendaBCC.Service.Interface
{
    public interface IProdutoService
    {
        Task AdicionarAsync(Produto produto);
        Task AlterarAsync(Produto produto);
        Task ExcluirAsync(int id);

        Task<IEnumerable<Produto>> ListarTodos();
        Task<Produto> PesquisarPorID(int id);
    }
}
