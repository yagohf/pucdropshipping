namespace Yagohf.PUC.Integracoes.Infraestrutura.Configuration
{
    public class ConfiguracoesBanco : IConfiguracoesBanco
    {
        private readonly string _connString;

        public string ConnectionString { get { return this._connString; } }

        public ConfiguracoesBanco(string connString)
        {
            this._connString = connString;
        }
    }
}
