using Microsoft.AspNetCore.Mvc.Controllers;
using System.Collections.Generic;
using System.Linq;

namespace Yagohf.PUC.Api.Infraestrutura.Extensions
{
    public static class ControllerActionDescriptorExtensions
    {
        public static IEnumerable<T> GetCustomAttributes<T>(this ControllerActionDescriptor controllerActionDescriptor)
        {
            if (controllerActionDescriptor != null)
            {
                return Enumerable.Cast<T>(controllerActionDescriptor.MethodInfo.GetCustomAttributes(typeof(T), true));
            }

            return Enumerable.Empty<T>();
        }
    }
}
