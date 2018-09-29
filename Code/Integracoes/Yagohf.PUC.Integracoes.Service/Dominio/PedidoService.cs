using System.Collections.Generic;
using System.Threading.Tasks;
using System.Transactions;
using Yagohf.PUC.Integracoes.Data.Interface;
using Yagohf.PUC.Integracoes.Infraestrutura.Exception;
using Yagohf.PUC.Integracoes.Infraestrutura.SMS;
using Yagohf.PUC.Integracoes.Model;
using Yagohf.PUC.Integracoes.Service.Interface.Dominio;

namespace Yagohf.PUC.Integracoes.Service.Dominio
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IPessoaRepository _pessoaRepository;
        private readonly ISmsNotificador _smsNotificador;

        public PedidoService(IPedidoRepository pedidoRepository, IPessoaRepository pessoaRepository, ISmsNotificador smsNotificador)
        {
            this._pedidoRepository = pedidoRepository;
            this._pessoaRepository = pessoaRepository;
            this._smsNotificador = smsNotificador;
        }

        public async Task<EventoPedidoFornecedorRegistrado> RegistrarEvento(string fornecedorAutenticado, RegistroEventoPedidoFornecedor evento)
        {
            //Recuperar o pedido em questão.
            Pedido p = this._pedidoRepository.RecuperarPorChaveFornecedor(fornecedorAutenticado, evento.ChavePedidoFornecedor);

            if (p == null)
                throw new BusinessException("Pedido inválido para registrar evento.");

            if (evento.Status <= p.Status)
                throw new BusinessException("Impossível atualizar o status de um pedido para um status mais antigo.");

            EventoPedidoFornecedorRegistrado eventoRegistrado;
            using (var ts = new TransactionScope())
            {
                //Gerar novo item no histórico de atualizações do pedido.
                int idEventoCriado = this._pedidoRepository.RegistrarEvento(p.Id, (int)evento.Status, evento.InformacoesAdicionais);

                //Atualizar o status.
                this._pedidoRepository.AtualizarStatus(p.Id, (int)evento.Status);

                ts.Complete();

                eventoRegistrado = new EventoPedidoFornecedorRegistrado();
                eventoRegistrado.IdEventoPedidoRegistrado = idEventoCriado;
                eventoRegistrado.ChavePedidoFornecedor = evento.ChavePedidoFornecedor;
            }

            if (eventoRegistrado != null)
                await NotificarEnvolvidosProcesso(evento, p);

            return eventoRegistrado;
        }

        private async Task NotificarEnvolvidosProcesso(RegistroEventoPedidoFornecedor evento, Pedido p)
        {
            List<Pessoa> pessoasNotificar = new List<Pessoa>();
            pessoasNotificar.Add(this._pessoaRepository.RecuperarPorId(p.IdCliente));
            if (p.IdVendedor.HasValue)
                pessoasNotificar.Add(this._pessoaRepository.RecuperarPorId(p.IdFornecedor));

            foreach (var pessoa in pessoasNotificar)
            {
                if (!string.IsNullOrEmpty(pessoa.Telefone))
                {
                    await this._smsNotificador.Notificar($"+{pessoa.Telefone}", 
                        $"PUC Loja Informa - Pedido { p.Id.ToString("00000000") }: {this._pedidoRepository.ObterMensagemStatus((int)evento.Status)}");
                }
            }
        }

        public bool VerificarFornecedorResponsavelPorPedido(string fornecedorLogado, string chavePedidoFornecedor)
        {
            Pedido p = this._pedidoRepository.RecuperarPorChaveFornecedor(fornecedorLogado, chavePedidoFornecedor);
            return p != null;
        }
    }
}
