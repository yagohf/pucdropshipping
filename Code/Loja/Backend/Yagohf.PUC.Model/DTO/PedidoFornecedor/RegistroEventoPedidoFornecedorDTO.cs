using Yagohf.PUC.Infraestrutura.Enumeradores;

namespace Yagohf.PUC.Model.DTO.PedidoFornecedor
{
    public class RegistroEventoPedidoFornecedorDTO
    {
        public string ChavePedidoFornecedor { get; set; }
        public EnumStatusPedidoFornecedor Status { get; set; }
        public string InformacoesAdicionais { get; set; }
    }
}
