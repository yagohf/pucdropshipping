using System;
using Yagohf.PUC.Integracoes.Data.Interface;
using Yagohf.PUC.Integracoes.Infraestrutura.Configuration;
using Yagohf.PUC.Integracoes.Infraestrutura.Enumeradores;
using Yagohf.PUC.Integracoes.Model;

namespace Yagohf.PUC.Integracoes.Data
{
    public class PedidoRepository : RepositoryBase, IPedidoRepository
    {
        public PedidoRepository(IConfiguracoesBanco configuracoesBanco) : base(configuracoesBanco)
        {
        }

        public Pedido RecuperarPorChaveFornecedor(int idFornecedor, string chavePedido)
        {
            using (var conn = this.ObterConexao())
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = CMD_RECUPERAR_POR_FORNECEDOR_CHAVE;

                    var paramIdFornecedor = cmd.CreateParameter();
                    paramIdFornecedor.ParameterName = "@IdFornecedor";
                    paramIdFornecedor.DbType = System.Data.DbType.Int32;
                    paramIdFornecedor.Value = idFornecedor;
                    cmd.Parameters.Add(paramIdFornecedor);

                    var paramChavePedidoFornecedor = cmd.CreateParameter();
                    paramChavePedidoFornecedor.ParameterName = "@ChavePedidoFornecedor";
                    paramChavePedidoFornecedor.DbType = System.Data.DbType.AnsiString;
                    paramChavePedidoFornecedor.Value = chavePedido;
                    cmd.Parameters.Add(paramChavePedidoFornecedor);

                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Pedido p = new Pedido();
                            p.Id = Convert.ToInt32(reader["Id"].ToString());
                            p.ChavePedidoFornecedor = reader["ChavePedidoFornecedor"].ToString();
                            p.IdFornecedor = Convert.ToInt32(reader["IdFornecedor"].ToString());
                            p.IdCliente = Convert.ToInt32(reader["IdCliente"].ToString());
                            p.IdVendedor = string.IsNullOrEmpty(reader["IdVendedor"].ToString()) ? (int?)null : Convert.ToInt32(reader["IdVendedor"].ToString());
                            p.Status = (EnumStatusPedidoFornecedor)Convert.ToInt32(reader["IdPedidoFornecedorStatus"].ToString());
                            return p;
                        }
                    }
                }
            }

            return null;
        }

        public void AtualizarStatus(int idPedido, int novoStatus)
        {
            using (var conn = this.ObterConexao())
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = CMD_ATUALIZAR_STATUS;

                    var paramNovoStatus = cmd.CreateParameter();
                    paramNovoStatus.ParameterName = "@NovoStatus";
                    paramNovoStatus.DbType = System.Data.DbType.Int32;
                    paramNovoStatus.Value = novoStatus;
                    cmd.Parameters.Add(paramNovoStatus);

                    var paramIdPedidoFornecedor = cmd.CreateParameter();
                    paramIdPedidoFornecedor.ParameterName = "@IdPedidoFornecedor";
                    paramIdPedidoFornecedor.DbType = System.Data.DbType.Int32;
                    paramIdPedidoFornecedor.Value = idPedido;
                    cmd.Parameters.Add(paramIdPedidoFornecedor);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public int RegistrarEvento(int idPedido, int status, string informacoesAdicionais)
        {
            using (var conn = this.ObterConexao())
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = CMD_GERAR_EVENTO;

                    var paramIdPedidoFornecedor = cmd.CreateParameter();
                    paramIdPedidoFornecedor.ParameterName = "@IdPedidoFornecedor";
                    paramIdPedidoFornecedor.DbType = System.Data.DbType.Int32;
                    paramIdPedidoFornecedor.Value = idPedido;
                    cmd.Parameters.Add(paramIdPedidoFornecedor);

                    var paramIdPedidoFornecedorStatus = cmd.CreateParameter();
                    paramIdPedidoFornecedorStatus.ParameterName = "@IdPedidoFornecedorStatus";
                    paramIdPedidoFornecedorStatus.DbType = System.Data.DbType.Int32;
                    paramIdPedidoFornecedorStatus.Value = status;
                    cmd.Parameters.Add(paramIdPedidoFornecedorStatus);

                    var paramDataOcorrencia = cmd.CreateParameter();
                    paramDataOcorrencia.ParameterName = "@DataOcorrencia";
                    paramDataOcorrencia.DbType = System.Data.DbType.DateTime;
                    paramDataOcorrencia.Value = DateTime.Now;
                    cmd.Parameters.Add(paramDataOcorrencia);

                    var paramInformacoesAdicionais = cmd.CreateParameter();
                    paramInformacoesAdicionais.ParameterName = "@InformacoesAdicionais";
                    paramInformacoesAdicionais.DbType = System.Data.DbType.AnsiString;
                    if (string.IsNullOrEmpty(informacoesAdicionais))
                        paramInformacoesAdicionais.Value = DBNull.Value;
                    else
                        paramInformacoesAdicionais.Value = informacoesAdicionais;
                    cmd.Parameters.Add(paramInformacoesAdicionais);

                    var paramIdEventoCriado = cmd.CreateParameter();
                    paramIdEventoCriado.ParameterName = "@IdEventoCriado";
                    paramIdEventoCriado.Direction = System.Data.ParameterDirection.Output;
                    paramIdEventoCriado.DbType = System.Data.DbType.Int32;
                    cmd.Parameters.Add(paramIdEventoCriado);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    return (int)paramIdEventoCriado.Value;
                }
            }
        }

        public string ObterMensagemStatus(int status)
        {
            using (var conn = this.ObterConexao())
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = CMD_OBTER_MENSAGEM_STATUS;

                    var paramStatus = cmd.CreateParameter();
                    paramStatus.ParameterName = "@Status";
                    paramStatus.DbType = System.Data.DbType.Int32;
                    paramStatus.Value = status;
                    cmd.Parameters.Add(paramStatus);

                    conn.Open();
                    return cmd.ExecuteScalar().ToString();
                }
            }
        }

        #region [ Comandos ]
        private const string CMD_RECUPERAR_POR_FORNECEDOR_CHAVE = @"
SELECT PC.Id,
PC.IdFornecedor,
P.IdCliente,
P.IdVendedor,
PC.ChavePedidoFornecedor,
PC.IdPedidoFornecedorStatus
FROM
[dbo].[PedidoFornecedor] PC
INNER JOIN
[dbo].[PedidoItem] PEDI ON PEDI.Id = PC.IdPedidoItem
INNER JOIN
[dbo].[Pedido] P ON P.Id = PEDI.IdPedido
WHERE
PC.IdFornecedor = @IdFornecedor
AND
PC.ChavePedidoFornecedor = @ChavePedidoFornecedor
";

        private const string CMD_ATUALIZAR_STATUS = @"
UPDATE [dbo].[PedidoFornecedor]
SET
IdPedidoFornecedorStatus = @NovoStatus
WHERE
Id = @IdPedidoFornecedor
";

        private const string CMD_GERAR_EVENTO = @"
INSERT INTO [dbo].[PedidoFornecedorEvento](IdPedidoFornecedor, IdPedidoFornecedorStatus, DataOcorrencia, InformacoesAdicionais)
VALUES
(@IdPedidoFornecedor, @IdPedidoFornecedorStatus, @DataOcorrencia, @InformacoesAdicionais);
SET @IdEventoCriado = SCOPE_IDENTITY();
";

        private const string CMD_OBTER_MENSAGEM_STATUS = @"
SELECT Descricao
FROM
[dbo].[PedidoFornecedorStatus]
WHERE
Id = @Status
";
        #endregion
    }
}
