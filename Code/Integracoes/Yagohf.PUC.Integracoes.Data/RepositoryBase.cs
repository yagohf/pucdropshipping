using System.Data;
using System.Data.SqlClient;
using Yagohf.PUC.Integracoes.Infraestrutura.Configuration;

namespace Yagohf.PUC.Integracoes.Data
{
    public abstract class RepositoryBase
    {
        private readonly IConfiguracoesBanco _configuracoesBanco;

        public RepositoryBase(IConfiguracoesBanco configuracoesBanco)
        {
            this._configuracoesBanco = configuracoesBanco;
        }

        public IDbConnection ObterConexao()
        {
            return new SqlConnection(this._configuracoesBanco.ConnectionString);
        }
    }
}
