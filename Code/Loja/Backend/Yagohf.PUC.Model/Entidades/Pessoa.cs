namespace Yagohf.PUC.Model.Entidades
{
    public class Pessoa : EntidadeBase
    {
        public int? IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Documento { get; set; }
    }
}
