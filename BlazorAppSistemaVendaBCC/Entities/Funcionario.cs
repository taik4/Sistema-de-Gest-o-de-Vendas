using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorAppSistemaVendaBCC.Entities
{
    [Table("tbFuncionario")]
    public class Funcionario
    {
        [Key]
        
        public int id { get; private set; }
        public string? Nome { get; private set; }
        public string? Cpf { get; private set; }
        public string? Email { get; private set; }
        public string? Cargo { get; private set; }

        public decimal Salario { get; private set; }
        public DateTime DataAdimissao { get; private set; }
        public ICollection<Pedido> pedidos { get; private set; }


    }
}
