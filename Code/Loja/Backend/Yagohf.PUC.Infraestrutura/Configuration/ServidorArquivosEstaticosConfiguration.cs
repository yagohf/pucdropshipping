namespace Yagohf.PUC.Infraestrutura.Configuration
{
    public class ServidorArquivosEstaticosConfiguration : IServidorArquivosEstaticosConfiguration
    {
        public ServidorArquivosEstaticosConfiguration(string caminhoImagensPropagandas, string caminhoImagensPromocoes, string caminhoImagensProdutos)
        {
            this.CaminhoImagensProdutos = caminhoImagensProdutos;
            this.CaminhoImagensPromocoes = caminhoImagensPromocoes;
            this.CaminhoImagensPropagandas = caminhoImagensPropagandas;
        }

        public string CaminhoImagensPropagandas { get; }
        public string CaminhoImagensPromocoes { get; }
        public string CaminhoImagensProdutos { get; }
    }
}
