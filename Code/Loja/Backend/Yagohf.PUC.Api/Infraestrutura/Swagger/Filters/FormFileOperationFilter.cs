using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;

namespace Yagohf.PUC.Api.Infraestrutura.Swagger.Filters
{
    public class FormFileOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                return;

            var paramFormFile = context.ApiDescription.ActionDescriptor.Parameters
                                    .SingleOrDefault(x => x.ParameterType.IsAssignableFrom(typeof(IFormFile)));

            if (paramFormFile == null)
            {
                return;
            }

            var propsParamFormFile = paramFormFile.ParameterType.GetProperties().Select(x => x.Name);
            if (!propsParamFormFile.Any())
            {
                return;
            }

            var parametrosParaRemoverOperacao = new List<IParameter>();
            foreach (var param in operation.Parameters)
            {
                if (propsParamFormFile.Contains(param.Name))
                {
                    parametrosParaRemoverOperacao.Add(param);
                }
            }

            parametrosParaRemoverOperacao.ForEach(x=> operation.Parameters.Remove(x));

            var fileParam = new NonBodyParameter
            {
                Type = "file",
                Name = paramFormFile.Name,
                In = "formData"
            };
            operation.Parameters.Add(fileParam);

            foreach (IParameter param in operation.Parameters)
            {
                param.In = "formData";
            }
        }
    }
}
