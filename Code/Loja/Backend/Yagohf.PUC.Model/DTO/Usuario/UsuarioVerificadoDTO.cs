using System.Collections.Generic;
using Yagohf.PUC.Infraestrutura.Enumeradores;

namespace Yagohf.PUC.Model.DTO.Usuario
{
    public class UsuarioVerificadoDTO
    {
        public UsuarioVerificadoDTO()
        {
            this.Perfis = new List<EnumPerfil>();
        }

        public int Id { get; set; }
        public string Login { get; set; }
        public List<EnumPerfil> Perfis { get; set; }
    }
}
