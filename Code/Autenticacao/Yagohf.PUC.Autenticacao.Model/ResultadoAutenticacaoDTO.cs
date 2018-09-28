using Yagohf.PUC.Autenticacao.Infraestrutura.Enumeradores;

namespace Yagohf.PUC.Autenticacao.Model
{
    public class ResultadoAutenticacaoDTO
    {
        public EnumResultadoAutenticacao Status { get; set; }
        public string Token { get; set; }
    }
}
