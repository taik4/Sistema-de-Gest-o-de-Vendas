using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorAppSistemaVendaBCC.Entities
{
    [Table("tbPedido")]
    public class Pedido
    {
        [Key]
        public int Id { get; private set; }
        public DateTime DataPedido { get; private set; }
        public int FuncionarioId { get; private set; }
        public Funcionario Funcionario { get; private set; }
        public int ClienteId { get; private set; }
        public Cliente Cliente { get; private set; }
        public decimal ValorTotal { get; private set; }
        public ICollection<ItemVenda> ItensVenda { get; private set; }
        public ICollection<Funcionario> Funcionarios { get; private set; }

    }
}
