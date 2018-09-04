namespace Yagohf.PUC.Infraestrutura.Validacao
{
    public sealed class ResultadoValidacaoDTO
    {
        public ResultadoValidacaoDTO(string propriedade, string mensagem)
        {
            this.Propriedade = propriedade;
            this.Mensagem = mensagem;
        }

        public string Propriedade { get; }
        public string Mensagem { get; }
    }
}
