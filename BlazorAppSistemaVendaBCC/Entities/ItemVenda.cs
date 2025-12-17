using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorAppSistemaVendaBCC.Entities
{
    [Table("tbItemVenda")]
    public class ItemVenda
    {
        
        [Column("ProdutoId")]
        public int ProdutoId { get; private set; }
        public Produto Produto { get; private set; }
        
        [Column("PedidoId")]
        public int PedidoId { get; private set; }
        public Pedido Pedido { get; private set; }
        
        [Column("QuantidadeProduto")]
        public int QuantidadeProduto { get; private set; }

        [Column("PrecoUnitario")]
        public decimal PrecoUnitario { get; private set; }
        public ICollection<Pedido> pedidos { get; private set; }
       
    }
}
