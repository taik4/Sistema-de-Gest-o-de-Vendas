using BlazorAppSistemaVendaBCC.Data.Context;
using BlazorAppSistemaVendaBCC.Entities;
using BlazorAppSistemaVendaBCC.Service.Interface;
using Microsoft.EntityFrameworkCore;


namespace BlazorAppSistemaVendaBCC.Service.Implementation
{
    public class FuncionarioService : IFuncionarioService
    {
        private readonly SQLServerContext _context;

        public FuncionarioService(SQLServerContext context)
        {
            _context = context;
        }

        public async Task AdicionarAsync(Funcionario funcionario)
        {
            _context.funcionarios.Add(funcionario);
            await _context.SaveChangesAsync();
        }

        public async Task AlterarAsync(Funcionario funcionario)
        {
            _context.funcionarios.Update(funcionario);
            await _context.SaveChangesAsync();
        }

        public async Task ExcluirAsync(int id)
        {
            var funcionario = await _context.funcionarios.FindAsync(id);
            if (funcionario != null)
            {
                _context.funcionarios.Remove(funcionario);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Funcionario>> ListarTodos()
        {
            return await _context.funcionarios.ToListAsync();
        }

        public async Task<Funcionario> PesquisarPorID(int id)
        {
            return await _context.funcionarios.FindAsync(id);
        }
    }
}
