namespace Yagohf.PUC.Integracoes.Infraestrutura.Configuration
{
    public class ConfiguracoesApp
    {
        public string ChaveCriptografiaToken { get; set; }
        public ConfiguracoesAws AWS { get; set; }
    }

    public class ConfiguracoesAws
    {
        public ConfiguracoesAwsSMS SMS { get; set; }
    }

    public class ConfiguracoesAwsSMS
    {
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public string Region { get; set; }
    }
}
