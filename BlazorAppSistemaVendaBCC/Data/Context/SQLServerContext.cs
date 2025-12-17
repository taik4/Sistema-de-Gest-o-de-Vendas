using BlazorAppSistemaVendaBCC.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorAppSistemaVendaBCC.Data.Context
{
    public class SQLServerContext : DbContext
    {
        public SQLServerContext(DbContextOptions<SQLServerContext> options) : base(options)
        {

        }
        public DbSet<Cliente> clientes {  get; set; }
        public DbSet<Funcionario> funcionarios { get; set; }
        public DbSet<ItemVenda> ItensVenda { get; set; }
        public DbSet<Pedido> pedidos { get; set; }
        public DbSet<Produto> produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurar chave primária composta para ItemVenda
            modelBuilder.Entity<ItemVenda>()
                .HasKey(iv => new { iv.ProdutoId, iv.PedidoId });

            // Configurar relacionamento ItemVenda -> Produto
            modelBuilder.Entity<ItemVenda>()
                .HasOne(iv => iv.Produto)
                .WithMany(p => p.ItensVenda)
                .HasForeignKey(iv => iv.ProdutoId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configurar relacionamento ItemVenda -> Pedido
            modelBuilder.Entity<ItemVenda>()
                .HasOne(iv => iv.Pedido)
                .WithMany(p => p.ItensVenda)
                .HasForeignKey(iv => iv.PedidoId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configurar relacionamento Pedido -> Cliente
            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.Cliente)
                .WithMany(c => c.pedidos)
                .HasForeignKey(p => p.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configurar relacionamento Pedido -> Funcionario
            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.Funcionario)
                .WithMany(f => f.pedidos)
                .HasForeignKey(p => p.FuncionarioId)
                .OnDelete(DeleteBehavior.Restrict);
        }



    }
}
