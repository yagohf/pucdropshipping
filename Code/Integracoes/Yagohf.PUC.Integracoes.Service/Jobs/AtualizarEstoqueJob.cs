using System.Collections.Generic;
using Yagohf.PUC.Integracoes.Data.Interface;
using Yagohf.PUC.Integracoes.Model;
using Yagohf.PUC.Integracoes.Service.Interface.Integracoes;
using Yagohf.PUC.Integracoes.Service.Interface.Jobs;

namespace Yagohf.PUC.Integracoes.Service.Jobs
{
    public class AtualizarEstoqueJob : IAtualizarEstoqueJob
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IConsultarEstoqueIntegracao _consultarEstoqueIntegracao;

        public AtualizarEstoqueJob(IFornecedorRepository fornecedorRepository, IProdutoRepository produtoRepository, IConsultarEstoqueIntegracao consultarEstoqueIntegracao)
        {
            this._fornecedorRepository = fornecedorRepository;
            this._produtoRepository = produtoRepository;
            this._consultarEstoqueIntegracao = consultarEstoqueIntegracao;
        }

        public void Executar()
        {
            IEnumerable<Fornecedor> fornecedores = this._fornecedorRepository.ListarAtivos();
            foreach (var fornecedor in fornecedores)
            {
                IEnumerable<Produto> produtos = this._produtoRepository.ListarAtivosPorFornecedor(fornecedor.Id);
                foreach (var produto in produtos)
                {
                    bool disponivel = this._consultarEstoqueIntegracao.Consultar(
                          fornecedor.EnderecoConsultarEstoque,
                          fornecedor.UsuarioServico,
                          fornecedor.SenhaServico,
                          produto.ChaveProdutoFornecedor);

                    this._produtoRepository.AtualizarDisponibilidade(produto.Id, disponivel);
                }
            }
        }
    }
}
