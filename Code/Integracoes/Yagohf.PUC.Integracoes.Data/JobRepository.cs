using System;
using System.Collections.Generic;
using Yagohf.PUC.Integracoes.Data.Interface;
using Yagohf.PUC.Integracoes.Infraestrutura.Configuration;
using Yagohf.PUC.Integracoes.Model;

namespace Yagohf.PUC.Integracoes.Data
{
    public class JobRepository : RepositoryBase, IJobRepository
    {
        public JobRepository(IConfiguracoesBanco configuracoesBanco) : base(configuracoesBanco)
        {
        }

        public void AtualizarUltimaExecucao(int idJob)
        {
            using (var conn = this.ObterConexao())
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = CMD_ATUALIZAR_ULTIMA_EXECUCAO;

                    var paramUltimaExecucao = cmd.CreateParameter();
                    paramUltimaExecucao.ParameterName = "@UltimaExecucao";
                    paramUltimaExecucao.DbType = System.Data.DbType.DateTime;
                    paramUltimaExecucao.Value = DateTime.Now;
                    cmd.Parameters.Add(paramUltimaExecucao);

                    var paramId = cmd.CreateParameter();
                    paramId.ParameterName = "@Id";
                    paramId.DbType = System.Data.DbType.Int32;
                    paramId.Value = idJob;
                    cmd.Parameters.Add(paramId);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<Job> RecuperarAtivos()
        {
            List<Job> jobs = new List<Job>();
            using (var conn = this.ObterConexao())
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = CMD_RECUPERAR_ATIVOS;

                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Job job = new Job();
                            job.Id = Convert.ToInt32(reader["Id"].ToString());
                            job.PeriodicidadeMinutos = Convert.ToInt32(reader["PeriodicidadeMinutos"].ToString());
                            job.UltimaExecucao = !string.IsNullOrEmpty(reader["UltimaExecucao"].ToString()) ? Convert.ToDateTime(reader["UltimaExecucao"].ToString()) : (DateTime?)null;
                            jobs.Add(job);
                        }
                    }
                }
            }

            return jobs;
        }

        #region [ Comandos ]
        private const string CMD_ATUALIZAR_ULTIMA_EXECUCAO = @"
UPDATE [dbo].[Job]
SET UltimaExecucao = @UltimaExecucao
WHERE Id = @Id
";

        private const string CMD_RECUPERAR_ATIVOS = @"
SELECT Id,
UltimaExecucao,
PeriodicidadeMinutos
FROM
[dbo].[Job]
WHERE Ativo = 1
";
        #endregion
    }
}
