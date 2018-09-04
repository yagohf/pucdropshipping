using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Yagohf.PUC.Api.Infraestrutura.Binders.ModelBinders;
using System;

namespace Yagohf.PUC.Api.Infraestrutura.Binders.Providers
{
    public class StringArrayModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (context.Metadata.ModelType == typeof(string[]))
            {
                return new BinderTypeModelBinder(typeof(StringArrayModelBinder));
            }

            return null;
        }
    }
}
