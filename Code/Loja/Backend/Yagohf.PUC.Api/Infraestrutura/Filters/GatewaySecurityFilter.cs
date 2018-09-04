using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Yagohf.PUC.Api.Infraestrutura.Extensions;
using Yagohf.PUC.Api.Infraestrutura.Model.Autenticacao;
using Yagohf.PUC.Infraestrutura.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading;

namespace Yagohf.PUC.Api.Infraestrutura.Filters
{
    public class GatewaySecurityFilter : IActionFilter
    {
        private const string NOME_HEADER_TOKEN_OWNER = "access_token_owner";
        private const string NOME_HEADER_TOKEN_SCOPE = "access_token_scope";

        //TODO - remover esse logger quando terminar testes.
        private readonly ILogger<GatewaySecurityFilter> _logger;

        public GatewaySecurityFilter(ILogger<GatewaySecurityFilter> logger)
        {
            this._logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var descriptor = ((Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)context.ActionDescriptor);

            if (!this.VerificarRotaPublica(descriptor))
            {
                if (this.Autenticar(context))
                {
                    if (this.Autorizar(context, descriptor.AttributeRouteInfo.Template, context.HttpContext.Request.Method))
                    {
                        this.CriarIdentidade(context);
                    }
                    else
                    {
                        JsonResult jsonResult = new JsonResult("Usuário não autorizado a consumir o recurso");
                        jsonResult.StatusCode = (int)HttpStatusCode.Forbidden;
                        context.Result = jsonResult;
                    }
                }
                else
                {
                    JsonResult jsonResult = new JsonResult("Usuário não autenticado");
                    jsonResult.StatusCode = (int)HttpStatusCode.Unauthorized;
                    context.Result = jsonResult;
                }
            }
        }

        /// <summary>
        /// Método que valida se uma determinada rota é pública, podendo ser acessada sem um token.
        /// </summary>
        /// <param name="descriptor">Descriptor da ação chamada.</param>
        /// <returns>TRUE se a rota é pública.</returns>
        private bool VerificarRotaPublica(Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor descriptor)
        {
            return descriptor.GetCustomAttributes<IAllowAnonymous>().Any();
        }

        /// <summary>
        /// Método que cria a identidade do usuário logado.
        /// </summary>
        /// <param name="context">Contexto de execução do filtro.</param>
        private void CriarIdentidade(ActionExecutingContext context)
        {
            UsuarioLogado usuario = this.RecuperarUsuario(context);
            ClaimsIdentity identity = new ClaimsIdentity();
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, usuario.Login));
            identity.AddClaim(new Claim(ClaimTypes.UserData, JsonConvert.SerializeObject(usuario.Permissoes)));

            //Setar o usuário da thread corrente.
            this.SetarUsuarioThread(context, identity);
        }

        /// <summary>
        /// Método que deserializa os dados enviados pelo gateway e converte em uma estrutura de usuário.
        /// </summary>
        /// <param name="context">Contexto de execução do filtro.</param>
        /// <returns>Usuário logado e suas permissões.</returns>
        private UsuarioLogado RecuperarUsuario(ActionExecutingContext context)
        {
            string login = context.HttpContext.Request.Headers[NOME_HEADER_TOKEN_OWNER]; //Sempre presente se autenticado.

            List<Permission> permissoes = null;
            if (!string.IsNullOrEmpty(context.HttpContext.Request.Headers[NOME_HEADER_TOKEN_SCOPE]))
            {
                var conteudoHeaderScope = JsonConvert.DeserializeObject<dynamic>(context.HttpContext.Request.Headers[NOME_HEADER_TOKEN_SCOPE]);
                permissoes = conteudoHeaderScope == null ? null : (JsonConvert.DeserializeObject<List<Permission>>(conteudoHeaderScope["permissions"].ToString()));
                if (permissoes != null)
                {
                    permissoes.ForEach(p => p.Endpoint = p.Endpoint.TransformarChaves());
                }
            }

            UsuarioLogado usuario = new UsuarioLogado();
            usuario.Login = login;
            usuario.Permissoes = permissoes;
            return usuario;
        }

        /// <summary>
        /// Método que configura o usuário para a thread sendo requisitada.
        /// </summary>
        /// <param name="context">Contexto de exeução do filtro.</param>
        /// <param name="identity">Identidade do usuário logado.</param>
        private void SetarUsuarioThread(ActionExecutingContext context, ClaimsIdentity identity)
        {
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);
            Thread.CurrentPrincipal = principal;
            if (context.HttpContext != null)
                context.HttpContext.User = principal;
        }

        /// <summary>
        /// Método que autoriza um usuário de acordo com as permissões enviadas no token pelo gateway.
        /// </summary>
        /// <param name="context">Contexto de execução do filtro.</param>
        /// <param name="rotaChamada">Rota sendo requisitada pela aplicação.</param>
        /// <param name="metodoHttp">Método HTTP sendo executado na requisição.</param>
        /// <returns>TRUE se o usuário está autorizado a acessar o recurso.</returns>
        private bool Autorizar(ActionExecutingContext context, string rotaChamada, string metodoHttp)
        {
            this._logger.LogInformation("Rota chamada {0}. Método: {1}", rotaChamada, metodoHttp);

            UsuarioLogado usuario = this.RecuperarUsuario(context);

            if (usuario.Permissoes != null && usuario.Permissoes.Any(x => 
                x.Endpoint.Equals(rotaChamada, StringComparison.OrdinalIgnoreCase) && 
                x.Actions.Any(ac => ac.Equals(metodoHttp, StringComparison.OrdinalIgnoreCase))))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Método que valida se o gateway enviou o header de autenticação, e se ele está preenchido.
        /// </summary>
        /// <param name="context">Contexto de execução do filter.</param>
        /// <returns>TRUE se o token foi enviado corretamente.</returns>
        private bool Autenticar(ActionExecutingContext context)
        {
            string headerTokenOwner = context.HttpContext.Request.Headers[NOME_HEADER_TOKEN_OWNER].FirstOrDefault() ?? string.Empty;
            return !string.IsNullOrEmpty(headerTokenOwner);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            //Não executar nada após a ação.
        }
    }
}
