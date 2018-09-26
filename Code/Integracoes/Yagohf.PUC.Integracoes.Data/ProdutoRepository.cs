using System;
using System.Collections.Generic;
using Yagohf.PUC.Integracoes.Data.Interface;
using Yagohf.PUC.Integracoes.Infraestrutura.Configuration;
using Yagohf.PUC.Integracoes.Model;

namespace Yagohf.PUC.Integracoes.Data
{
    public class ProdutoRepository : RepositoryBase, IProdutoRepository
    {
        public ProdutoRepository(IConfiguracoesBanco configuracoesBanco) : base(configuracoesBanco)
        {
        }

        public IEnumerable<Produto> ListarAtivosPorFornecedor(int idFornecedor)
        {
            List<Produto> produtos = new List<Produto>();
            using (var conn = this.ObterConexao())
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = CMD_LISTAR_ATIVOS_POR_FORNECEDOR;

                    var paramIdFornecedor = cmd.CreateParameter();
                    paramIdFornecedor.ParameterName = "@IdFornecedor";
                    paramIdFornecedor.DbType = System.Data.DbType.Int32;
                    paramIdFornecedor.Value = idFornecedor;
                    cmd.Parameters.Add(paramIdFornecedor);

                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Produto p = new Produto();
                            p.Id = Convert.ToInt32(reader["Id"].ToString());
                            p.IdFornecedor = Convert.ToInt32(reader["IdFornecedor"].ToString());
                            p.ChaveProdutoFornecedor = reader["ChaveProdutoFornecedor"].ToString();
                            produtos.Add(p);
                        }
                    }
                }
            }

            return produtos;
        }

        public void AtualizarDisponibilidade(int idProduto, bool disponibilidade)
        {
            using (var conn = this.ObterConexao())
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = CMD_ATUALIZAR_DISPONIBILIDADE;

                    var paramDisponibilidade = cmd.CreateParameter();
                    paramDisponibilidade.ParameterName = "@Disponibilidade";
                    paramDisponibilidade.DbType = System.Data.DbType.Boolean;
                    paramDisponibilidade.Value = disponibilidade;
                    cmd.Parameters.Add(paramDisponibilidade);

                    var paramId = cmd.CreateParameter();
                    paramId.ParameterName = "@Id";
                    paramId.DbType = System.Data.DbType.Int32;
                    paramId.Value = idProduto;
                    cmd.Parameters.Add(paramId);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        #region [ Comandos ]
        private const string CMD_LISTAR_ATIVOS_POR_FORNECEDOR = @"
SELECT Id,
IdFornecedor,
ChaveProdutoFornecedor
FROM
[dbo].[Produto]
WHERE
IdFornecedor = @IdFornecedor
AND
Ativo = 1
";

        private const string CMD_ATUALIZAR_DISPONIBILIDADE = @"
UPDATE [dbo].[Produto]
SET Disponivel = @Disponibilidade
WHERE Id = @Id
";
        #endregion
    }
}
