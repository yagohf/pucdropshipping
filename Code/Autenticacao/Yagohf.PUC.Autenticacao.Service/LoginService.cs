using Amazon;
using Amazon.CognitoIdentityProvider;
using Amazon.Extensions.CognitoAuthentication;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Yagohf.PUC.Autenticacao.Infraestrutura.Configuracoes;
using Yagohf.PUC.Autenticacao.Infraestrutura.Enumeradores;
using Yagohf.PUC.Autenticacao.Model;
using Yagohf.PUC.Autenticacao.Service.Interface;

namespace Yagohf.PUC.Autenticacao.Service
{
    public class LoginService : ILoginService
    {
        private readonly AwsConfigAdapter _awsConfigAdapter;
        private readonly ILogger<LoginService> _logger;

        public LoginService(AwsConfigAdapter awsConfigAdapter, ILogger<LoginService> logger)
        {
            this._awsConfigAdapter = awsConfigAdapter;
            this._logger = logger;
        }

        public async Task<ResultadoAutenticacaoDTO> Autenticar(AutenticacaoDTO autenticacao)
        {
            ResultadoAutenticacaoDTO resultado = new ResultadoAutenticacaoDTO();
            if (autenticacao == null || string.IsNullOrEmpty(autenticacao.Usuario) || string.IsNullOrEmpty(autenticacao.Senha))
            {
                resultado.Status = EnumResultadoAutenticacao.FALHA_CREDENCIAIS;
            }
            else
            {
                try
                {
                    using (AmazonCognitoIdentityProviderClient provider = new AmazonCognitoIdentityProviderClient(
                        new Amazon.Runtime.AnonymousAWSCredentials(),
                        RegionEndpoint.GetBySystemName(this._awsConfigAdapter.Cognito.PoolRegion)))
                    {

                        CognitoUserPool userPool = new CognitoUserPool(
                            this._awsConfigAdapter.Cognito.PoolID,
                            this._awsConfigAdapter.Cognito.ClientID,
                            provider,
                            this._awsConfigAdapter.Cognito.ClientSecret);

                        CognitoUser user = new CognitoUser(
                            autenticacao.Usuario,
                            this._awsConfigAdapter.Cognito.ClientID,
                            userPool,
                            provider,
                            this._awsConfigAdapter.Cognito.ClientSecret);

                        InitiateSrpAuthRequest authRequest = new InitiateSrpAuthRequest()
                        {
                            Password = autenticacao.Senha
                        };

                        AuthFlowResponse authResponse = await user.StartWithSrpAuthAsync(authRequest);
                        resultado.Status = EnumResultadoAutenticacao.SUCESSO;
                        resultado.Token = authResponse.AuthenticationResult.IdToken;
                    }
                }
                catch (Amazon.CognitoIdentityProvider.Model.NotAuthorizedException naEx)
                {
                    this._logger.LogError(naEx, "Tentativa de login bloqueada. Usuario: {0} / Senha: {1}", autenticacao.Usuario, autenticacao.Senha);
                    resultado.Status = EnumResultadoAutenticacao.FALHA_CREDENCIAIS;
                }
                catch (Exception ex)
                {
                    this._logger.LogError(ex, "Erro no processo de autenticação");
                    resultado.Status = EnumResultadoAutenticacao.ERRO_NAO_TRATADO;
                }
            }

            return resultado;
        }
    }
}
