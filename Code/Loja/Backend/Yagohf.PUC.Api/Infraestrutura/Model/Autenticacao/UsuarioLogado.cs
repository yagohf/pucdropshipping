using System.Collections.Generic;

namespace Yagohf.PUC.Api.Infraestrutura.Model.Autenticacao
{
    public class UsuarioLogado
    {
        public string Login { get; set; }
        public List<Permission> Permissoes { get; set; }
    }
}
