using System;
using System.Transactions;
using Yagohf.PUC.Integracoes.Data.Interface;
using Yagohf.PUC.Integracoes.Infraestrutura.Exception;
using Yagohf.PUC.Integracoes.Model;
using Yagohf.PUC.Integracoes.Service.Interface.Dominio;

namespace Yagohf.PUC.Integracoes.Service.Dominio
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoService(IPedidoRepository pedidoRepository)
        {
            this._pedidoRepository = pedidoRepository;
        }

        public EventoPedidoFornecedorRegistrado RegistrarEvento(int idFornecedorAutenticado, RegistroEventoPedidoFornecedor evento)
        {
            using (var ts = new TransactionScope())
            {
                //Recuperar o pedido em questão.
                Pedido p = this._pedidoRepository.RecuperarPorChaveFornecedor(idFornecedorAutenticado, evento.ChavePedidoFornecedor);

                if (p == null)
                    throw new BusinessException("Pedido inválido para registrar evento.");

                if (evento.Status <= p.Status)
                    throw new BusinessException("Impossível atualizar o status de um pedido para um status mais antigo.");

                //Gerar novo item no histórico de atualizações do pedido.
                int idEventoCriado = this._pedidoRepository.RegistrarEvento(p.Id, (int)evento.Status, evento.InformacoesAdicionais);

                //Atualizar o status.
                this._pedidoRepository.AtualizarStatus(p.Id, (int)evento.Status);

                ts.Complete();

                //TODO - notificar os envolvidos no processo sobre a atualização do status.

                EventoPedidoFornecedorRegistrado eventoRegistrado = new EventoPedidoFornecedorRegistrado();
                eventoRegistrado.IdEventoPedidoRegistrado = idEventoCriado;
                eventoRegistrado.ChavePedidoFornecedor = evento.ChavePedidoFornecedor;
                return eventoRegistrado;
            }
        }

        public bool VerificarFornecedorResponsavelPorPedido(int idFornecedorLogado, string chavePedidoFornecedor)
        {
            Pedido p = this._pedidoRepository.RecuperarPorChaveFornecedor(idFornecedorLogado, chavePedidoFornecedor);
            return p != null;
        }
    }
}
