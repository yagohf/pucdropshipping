namespace Yagohf.PUC.Model.Entidades
{
    public class PedidoItem : EntidadeBase
    {
        public int IdPedido { get; set; }
        public int IdProduto { get; set; }
        public decimal PrecoCusto { get; set; }
        public decimal PrecoVenda { get; set; }
        public int Quantidade { get; set; }
        public decimal Desconto { get; set; }
        public decimal PrecoFinal { get; set; }
    }
}
