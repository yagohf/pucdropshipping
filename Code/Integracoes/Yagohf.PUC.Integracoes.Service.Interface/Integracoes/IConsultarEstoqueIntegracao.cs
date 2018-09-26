namespace Yagohf.PUC.Integracoes.Service.Interface.Integracoes
{
    public interface IConsultarEstoqueIntegracao
    {
        bool Consultar(string urlConsulta, string usuario, string senha, string chaveProduto);
    }
}
