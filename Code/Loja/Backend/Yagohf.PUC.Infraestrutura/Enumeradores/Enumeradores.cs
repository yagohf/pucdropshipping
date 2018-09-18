namespace Yagohf.PUC.Infraestrutura.Enumeradores
{
    public enum EnumStatusPedidoFornecedor
    {
        RECEBIDO = 0,
        RECUSADO = 1,
        CONFIRMADO = 2,
        EMBALADO = 3,
        EXPEDIDO = 4,
        TRANSPORTANDO = 5,
        ENTREGUE = 6
    }

    public enum EnumStatusPagamento
    {
        PENDENTE = 1,
        CONFIRMADO = 2,
        RECUSADO = 3
    }

    public enum EnumPerfil
    {
        CLIENTE = 1,
        VENDEDOR = 2,
        ATENDENTE = 3
    }
}
