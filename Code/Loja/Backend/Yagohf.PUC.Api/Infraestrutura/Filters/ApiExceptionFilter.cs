using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Yagohf.PUC.Infraestrutura.Exception;

namespace Yagohf.PUC.Api.Infraestrutura.Filters
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
            if (context.Exception is ValidacaoDTOException)
            {
                ValidacaoDTOException validacaoException = context.Exception as ValidacaoDTOException;
                JsonResult jsonResult = new JsonResult(validacaoException.ResultadoValidacao);
                jsonResult.StatusCode = 422; //Unprocessable entity - utilizado para erros de validação.
                context.Result = jsonResult;
            }
            else if (context.Exception is BusinessException)
            {
                JsonResult jsonResult = new JsonResult(context.Exception.Message);
                jsonResult.StatusCode = 400; //BadRequest - erros tratados.
                context.Result = jsonResult;
            }
            else
            {
                this._logger.LogError(context.Exception, context.Exception.Message);
                context.ExceptionHandled = true;

                JsonResult jsonResult = new JsonResult("Ocorreu um erro interno ao processar a solicitação.");
                jsonResult.StatusCode = 500; //InternalServerError - qualquer erro não tratado.
                context.Result = jsonResult;
            }
        }
    }
}
