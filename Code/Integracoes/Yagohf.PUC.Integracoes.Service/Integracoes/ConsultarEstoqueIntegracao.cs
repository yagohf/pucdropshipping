using System;
using System.ServiceModel;
using Yagohf.PUC.Integracoes.Service.Integracoes.Contratos;
using Yagohf.PUC.Integracoes.Service.Interface.Integracoes;

namespace Yagohf.PUC.Integracoes.Service.Integracoes
{
    public class ConsultarEstoqueIntegracao : IConsultarEstoqueIntegracao
    {
        public bool Consultar(string urlConsulta, string usuario, string senha, string chaveProduto)
        {
            return true;
            //var binding = new BasicHttpBinding();
            //var endpoint = new EndpointAddress(new Uri(urlConsulta));
            //using (ChannelFactory<IEstoqueService> factory = new ChannelFactory<IEstoqueService>(binding, endpoint))
            //{
            //    IEstoqueService channel = factory.CreateChannel();
            //    bool disponibilidade = channel.ConsultarDisponibilidade(chaveProduto);
            //    return disponibilidade;
            //}
        }
    }
}
