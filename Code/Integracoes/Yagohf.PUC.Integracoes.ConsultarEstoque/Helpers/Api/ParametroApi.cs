namespace Yagohf.PUC.Integracoes.ConsultarEstoque.Helpers.Api
{
    public class ParametroApi
    {
        public ParametroApi(string nome, string valor, EnumApiParametroTipo tipo)
        {
            this.Nome = nome;
            this.Valor = valor;
            this.Tipo = tipo;
        }

        public string Nome { get; }
        public string Valor { get; }
        public EnumApiParametroTipo Tipo { get; }
    }

    public enum EnumApiParametroTipo
    {
        QUERY_STRING = 1,
        PATH = 2,
        BODY = 3
    }
}
