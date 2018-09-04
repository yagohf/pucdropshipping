using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Threading.Tasks;

namespace Yagohf.PUC.Api.Infraestrutura.Binders.ModelBinders
{
    public class StringArrayModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            string[] result = new string[0];

            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            var modelName = bindingContext.ModelName;
            var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);

            if (valueProviderResult == ValueProviderResult.None)
            {
                bindingContext.Result = ModelBindingResult.Success(result);
                return Task.CompletedTask;
            }

            bindingContext.ModelState.SetModelValue(modelName, valueProviderResult);

            var value = valueProviderResult.FirstValue;

            if (string.IsNullOrEmpty(value))
            {
                bindingContext.Result = ModelBindingResult.Success(result);
                return Task.CompletedTask;
            }

            try
            {
                result = value.Split(',');
            }
            catch
            {
                result = new string[0];
            }

            bindingContext.Result = ModelBindingResult.Success(result);
            return Task.CompletedTask;
        }
    }    
}
