using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorAppSistemaVendaBCC.Entities
{
    [Table("tbCliente")]
    public class Cliente
    {
        [Key]
        [Column("IdCliente")]
        public int Id { get;  set; }
        public string? Nome { get;  set; }
        public string? CpfCnpj { get;  set; }
        public string Email { get;  set; }
        public string? Telefone { get;  set; }
        public string? Endereco { get;  set; }

        public ICollection<Pedido> pedidos { get;  set; }
    }
}
