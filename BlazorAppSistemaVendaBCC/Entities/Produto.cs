using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorAppSistemaVendaBCC.Entities
{
    [Table("tbProduto")]
    public class Produto
    {   
        [Key]
        public int Id { get; private set; }
        public String? Nome { get; private set; }
        public String? Descricao { get; private set; }
        public int QuantidadeEstoque { get; private set; }
        public String? UnidadeMedida { get; private set; }
        public decimal PrecoUnitario { get; private set; }
        public String? ImagemProduto { get; private set; }
        public ICollection<ItemVenda> ItensVenda { get; private set; }
    }
}
