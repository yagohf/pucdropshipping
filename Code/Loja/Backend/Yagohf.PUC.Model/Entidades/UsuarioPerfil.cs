namespace Yagohf.PUC.Model.Entidades
{
    public class UsuarioPerfil
    {
        public int IdUsuario { get; set; }
        public int IdPerfil { get; set; }

        //Relacionamentos
        public Usuario Usuario { get; set; }
        public Perfil Perfil { get; set; }
    }
}
