using System.Collections.Generic;

namespace Yagohf.PUC.Model.Entidades
{
    public class Perfil : DominioBase
    {
        //Relacionamentos.
        public ICollection<UsuarioPerfil> UsuarioPerfis { get; set; }
    }
}
