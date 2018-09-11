namespace Yagohf.PUC.Model.Entidades
{
    public class ProdutoPromocao
    {
        public int IdProduto { get; set; }
        public int IdPromocao { get; set; }
        public decimal PrecoVenda { get; set; }

        //Relacionamentos.
        public Promocao Promocao { get; set; }
        public Produto Produto { get; set; }
    }
}
