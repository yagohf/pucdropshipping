namespace Yagohf.PUC.Model.Entidades
{
    public class Propaganda : EntidadeBase
    {
        public int Posicao { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Url { get; set; }
        public bool Ativo { get; set; }
    }
}
