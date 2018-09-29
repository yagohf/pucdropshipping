using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Yagohf.PUC.Integracoes.Api.Infraestrutura.Extensions
{
    public static class ControllerExtensions
    {
        public static string ObterUsuarioLogado(this Controller controller)
        {
            return controller.HttpContext.User.Claims.Single(c => c.Type.Equals("cognito:username")).Value;
        }
    }
}
