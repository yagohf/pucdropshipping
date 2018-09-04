using Yagohf.PUC.Api.Infraestrutura.Swagger.Attributes;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;

namespace Yagohf.PUC.Api.Infraestrutura.Swagger.Filters
{
    public class SwaggerConsumesOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            var attribute = context.ApiDescription.ActionAttributes().SingleOrDefault(x => x.GetType() == typeof(SwaggerConsumesAttribute));
            if (attribute == null)
            {
                return;
            }
            else
            {
                operation.Consumes.Clear();
                operation.Consumes = (attribute as SwaggerConsumesAttribute).ContentTypes.ToList();
            }
        }
    }
}
