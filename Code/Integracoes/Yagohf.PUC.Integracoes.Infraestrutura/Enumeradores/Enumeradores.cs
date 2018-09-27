namespace Yagohf.PUC.Integracoes.Infraestrutura.Enumeradores
{
    public enum EnumJob
    {
        ATUALIZAR_ESTOQUE = 1
    }

    public enum EnumPerfil
    {
        FORNECEDOR = 4
    }

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
}
