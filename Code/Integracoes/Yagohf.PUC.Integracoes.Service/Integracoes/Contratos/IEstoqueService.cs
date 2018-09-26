using System.ServiceModel;

namespace Yagohf.PUC.Integracoes.Service.Integracoes.Contratos
{
    [ServiceContract]
    public interface IEstoqueService
    {
        [OperationContract]
        bool ConsultarDisponibilidade(string chaveProduto);
    }
}
