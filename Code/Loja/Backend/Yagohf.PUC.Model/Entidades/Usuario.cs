using System.Collections.Generic;

namespace Yagohf.PUC.Model.Entidades
{
    public class Usuario : EntidadeBase
    {
        public string Login { get; set; }
        public string Senha { get; set; }

        //Relacionamentos
        public Pessoa Pessoa { get; set; }
        public ICollection<UsuarioPerfil> UsuarioPerfis { get; set; }
    }
}
