using Microsoft.AspNetCore.Mvc;
using System;

namespace Yagohf.PUC.Api.Infraestrutura.Extensions
{
    public static class ControllerExtensions
    {
        public static int ObterUsuarioLogado(this Controller controller)
        {
            return Convert.ToInt32(controller.HttpContext.User.Identity.Name);
        }
    }
}
