using System.ServiceModel;

namespace Yagohf.PUC.Fornecedor.Servicos
{
    [ServiceContract]
    public interface IEstoqueService
    {
        [OperationContract]
        bool ConsultarDisponibilidade(string chaveProduto);
    }
}
