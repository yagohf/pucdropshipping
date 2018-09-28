using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Yagohf.PUC.Autenticacao.Web.Infraestrutura.Filters
{
    public class ApiExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<ApiExceptionFilter> _logger;

        public ApiExceptionFilter(ILogger<ApiExceptionFilter> logger)
        {
            this._logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            this._logger.LogError(context.Exception, context.Exception.Message);
            context.ExceptionHandled = true;

            JsonResult jsonResult = new JsonResult("Ocorreu um erro interno ao processar a solicitação.");
            jsonResult.StatusCode = 500; //InternalServerError - qualquer erro não tratado.
            context.Result = jsonResult;
        }
    }
}
