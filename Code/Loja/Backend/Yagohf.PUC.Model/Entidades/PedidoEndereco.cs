namespace Yagohf.PUC.Model.Entidades
{
    public class PedidoEndereco
    {
        public int IdPedido { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Observacao { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
    }
}
