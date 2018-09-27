using Yagohf.PUC.Integracoes.Infraestrutura.Enumeradores;

namespace Yagohf.PUC.Integracoes.Model
{
    public class RegistroEventoPedidoFornecedor
    {
        public string ChavePedidoFornecedor { get; set; }
        public EnumStatusPedidoFornecedor Status { get; set; }
        public string InformacoesAdicionais { get; set; }
    }
}
