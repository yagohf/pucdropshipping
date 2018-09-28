namespace Yagohf.PUC.Autenticacao.Infraestrutura.Configuracoes
{
    public class AwsConfigAdapter
    {
        public CognitoAwsConfigAdapter Cognito { get; set; }
    }

    public class CognitoAwsConfigAdapter
    {
        public string PoolID { get; set; }
        public string PoolRegion { get; set; }
        public string ClientID { get; set; }
        public string ClientSecret { get; set; }
    }
}
