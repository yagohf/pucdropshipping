using System;
using System.Collections.Generic;
using System.Text;
using Yagohf.PUC.Integracoes.Data.Interface;
using Yagohf.PUC.Integracoes.Infraestrutura.Configuration;
using Yagohf.PUC.Integracoes.Model;

namespace Yagohf.PUC.Integracoes.Data
{
    public class FornecedorRepository : RepositoryBase, IFornecedorRepository
    {
        public FornecedorRepository(IConfiguracoesBanco configuracoesBanco) : base(configuracoesBanco)
        {
        }

        public IEnumerable<Fornecedor> ListarAtivos()
        {
            List<Fornecedor> fornecedores = new List<Fornecedor>();
            using (var conn = this.ObterConexao())
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = CMD_LISTAR_ATIVOS;

                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Fornecedor f = new Fornecedor();
                            f.Id = Convert.ToInt32(reader["Id"].ToString());
                            f.EnderecoConsultarEstoque = reader["EnderecoConsultarEstoque"].ToString();
                            f.UsuarioServico = reader["UsuarioServico"].ToString();
                            f.SenhaServico = reader["SenhaServico"].ToString();
                            fornecedores.Add(f);
                        }
                    }
                }
            }

            return fornecedores;
        }

        #region [ Comandos ]
        private const string CMD_LISTAR_ATIVOS = @"
SELECT Id, 
EnderecoConsultarEstoque, 
UsuarioServico, 
SenhaServico 
FROM [dbo].[Fornecedor] 
WHERE 
Ativo = 1
";
        #endregion
    }
}
