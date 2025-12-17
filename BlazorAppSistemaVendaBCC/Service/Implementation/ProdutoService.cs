using BlazorAppSistemaVendaBCC.Data.Context;
using BlazorAppSistemaVendaBCC.Entities;
using BlazorAppSistemaVendaBCC.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace BlazorAppSistemaVendaBCC.Service.Implementation
{
    public class ProdutoService : IProdutoService
    {
        private readonly SQLServerContext _context;

        public ProdutoService(SQLServerContext context)
        {
            _context = context;
        }
        public async Task AdicionarAsync(Produto produto)
        {
            _context.produtos.Add(produto);
            await _context.SaveChangesAsync(); ;
        }

        public async Task AlterarAsync(Produto produto)
        {
            _context.produtos.Update(produto);
            await _context.SaveChangesAsync();
        }

        public async Task ExcluirAsync(int id)
        {
            var produto = await _context.produtos.FindAsync(id);
            if (produto != null)
            {
                _context.produtos.Remove(produto);
                await _context.SaveChangesAsync();
            };
        }

        public async Task<IEnumerable<Produto>> ListarTodos()
        {
            return await _context.produtos.ToListAsync();
        }

        public async Task<Produto> PesquisarPorID(int id)
        {
            return await _context.produtos.FindAsync(id);
        }
    }
}
