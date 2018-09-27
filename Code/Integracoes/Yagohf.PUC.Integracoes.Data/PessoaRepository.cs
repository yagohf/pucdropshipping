using System;
using Yagohf.PUC.Integracoes.Data.Interface;
using Yagohf.PUC.Integracoes.Infraestrutura.Configuration;
using Yagohf.PUC.Integracoes.Model;

namespace Yagohf.PUC.Integracoes.Data
{
    public class PessoaRepository : RepositoryBase, IPessoaRepository
    {
        public PessoaRepository(IConfiguracoesBanco configuracoesBanco) : base(configuracoesBanco)
        {
        }

        public Pessoa RecuperarPorId(int id)
        {
            using (var conn = this.ObterConexao())
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = CMD_RECUPERAR_POR_ID;

                    var paramIdPessoa = cmd.CreateParameter();
                    paramIdPessoa.ParameterName = "@IdPessoa";
                    paramIdPessoa.DbType = System.Data.DbType.Int32;
                    paramIdPessoa.Value = id;
                    cmd.Parameters.Add(paramIdPessoa);

                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Pessoa p = new Pessoa();
                            p.Id = Convert.ToInt32(reader["Id"].ToString());
                            p.Nome = reader["Nome"].ToString();
                            p.Email = reader["Email"].ToString();
                            p.Telefone = reader["Telefone"].ToString();
                            return p;
                        }
                    }
                }
            }

            return null;
        }

        #region [ Comandos ]
        private const string CMD_RECUPERAR_POR_ID = @"
SELECT Id,
Nome,
Email,
Telefone
FROM
[dbo].[Pessoa]
WHERE
Id = @IdPessoa
";
        #endregion
    }
}
