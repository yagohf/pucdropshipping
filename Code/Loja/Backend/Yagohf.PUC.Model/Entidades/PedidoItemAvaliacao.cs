namespace Yagohf.PUC.Model.Entidades
{
    public class PedidoItemAvaliacao : EntidadeBase
    {
        public int Classificacao { get; set; }
        public string DescricaoAvaliacao { get; set; }
        public int IdPedidoItem { get; set; }

        //Relacionamentos
        public PedidoItem PedidoItem { get; set; }
    }
}
