using System.Collections.Generic;
using Yagohf.PUC.Integracoes.Infraestrutura.Enumeradores;

namespace Yagohf.PUC.Integracoes.Model
{
    public class Usuario
    {
        public Usuario()
        {
            this.Perfis = new List<EnumPerfil>();
        }

        public int Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public IEnumerable<EnumPerfil> Perfis { get; set; }
    }
}
