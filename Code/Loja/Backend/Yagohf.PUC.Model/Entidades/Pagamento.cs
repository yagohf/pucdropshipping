namespace Yagohf.PUC.Model.Entidades
{
    public class Pagamento : EntidadeBase
    {
        public int IdProduto { get; set; }
        public int IdPagamentoStatus { get; set; }
        public string ChaveTransacao { get; set; }
        public string DescricaoPagamento { get; set; }
        public string XMLTransacao { get; set; }
    }
}
