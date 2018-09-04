using System.Collections.Generic;

namespace Yagohf.PUC.Api.Infraestrutura.Model.Autenticacao
{
    public class Permission
    {
        public int Id { get; set; }

        public string Endpoint { get; set; }

        public List<string> Actions { get; set; }
    }
}
