namespace Yagohf.PUC.Model.Entidades
{
    public class Usuario : EntidadeBase
    {
        public string Login { get; set; }

        //Relacionamentos
        public Pessoa Pessoa { get; set; }
    }
}
