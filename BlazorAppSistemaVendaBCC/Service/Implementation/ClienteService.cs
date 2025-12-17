using BlazorAppSistemaVendaBCC.Data.Context;
using BlazorAppSistemaVendaBCC.Entities;
using BlazorAppSistemaVendaBCC.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace BlazorAppSistemaVendaBCC.Service.Implementation
{
    public class ClienteService : IClientesService
    {
        private readonly SQLServerContext _context;

        public ClienteService(SQLServerContext context)
        {
            _context = context;
        }

        public async Task AdicionarAsync(Cliente cliente)
        {
            _context.clientes.Add(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task AlterarAsync(Cliente cliente)
        {
            _context.clientes.Update(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task ExcluirAsync(int id)
        {
           var cliente = await _context.clientes.FindAsync(id);
            if (cliente != null) 
            { 
                _context.clientes.Remove(cliente);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Cliente>> ListarTodos()
        {
            return await _context.clientes.ToListAsync();
        }

        public async Task<Cliente> PesquisarPorID(int id)
        {
            return await _context.clientes.FindAsync(id);
        }

        public async Task<(IEnumerable<Cliente> clientes, int TotalRegistros)> ListarPaginado(int numeroPagina, int itensPorPagina)
        {
            // 1. Calcula quantos registros pular (offset)
            var pular = (numeroPagina - 1) * itensPorPagina;

            // 2. Consulta o total de registros (para o frontend saber quantas páginas existem)
            var totalRegistros = await _context.clientes.CountAsync();

            // 3. Consulta os dados da página específica
            var clientesPaginados = await _context.clientes
                .OrderBy(c => c.Nome) // Sempre ordene antes de paginar
                .Skip(pular)          // Pula os registros anteriores
                .Take(itensPorPagina) // Pega apenas a quantidade necessária
                .ToListAsync();

            // 4. Retorna a tupla com os dados da página e o total
            return (clientesPaginados, totalRegistros);
        }
    }
}
