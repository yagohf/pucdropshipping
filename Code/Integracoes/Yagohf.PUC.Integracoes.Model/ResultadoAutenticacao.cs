namespace Yagohf.PUC.Integracoes.Model
{
    public class ResultadoAutenticacao
    {
        public EnumResultadoAutenticacao Status { get; set; }
        public string Token { get; set; }
    }

    public enum EnumResultadoAutenticacao
    {
        SUCESSO = 1,
        FALHA_CREDENCIAIS = 2,
        ERRO_NAO_TRATADO = 3
    }
}
