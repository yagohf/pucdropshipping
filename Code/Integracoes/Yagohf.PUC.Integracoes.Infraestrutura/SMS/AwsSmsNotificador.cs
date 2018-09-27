using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Yagohf.PUC.Integracoes.Infraestrutura.Configuration;

namespace Yagohf.PUC.Integracoes.Infraestrutura.SMS
{
    public class AwsSmsNotificador : ISmsNotificador
    {
        private readonly ILogger<AwsSmsNotificador> _logger;
        private readonly ConfiguracoesApp _configuracoesApp;

        public AwsSmsNotificador(ILogger<AwsSmsNotificador> logger, ConfiguracoesApp configuracoesApp)
        {
            this._logger = logger;
            this._configuracoesApp = configuracoesApp;
        }

        public async Task Notificar(string nroTelefone, string texto)
        {
            using (AmazonSimpleNotificationServiceClient snsClient = new AmazonSimpleNotificationServiceClient(this._configuracoesApp.AWS.SMS.Usuario, this._configuracoesApp.AWS.SMS.Senha, Amazon.RegionEndpoint.GetBySystemName(this._configuracoesApp.AWS.SMS.Region)))
            {
                PublishRequest requisicaoNovaMensagem = new PublishRequest();
                requisicaoNovaMensagem.Message = texto;
                requisicaoNovaMensagem.PhoneNumber = nroTelefone;

                PublishResponse resposta = await snsClient.PublishAsync(requisicaoNovaMensagem);
                if (resposta.HttpStatusCode == System.Net.HttpStatusCode.OK)
                {
                    this._logger.LogInformation($"SMS enviado com sucesso para o número {nroTelefone} com o texto { texto}");
                }
                else
                {
                    this._logger.LogError($"Erro ao enviar SMS para o número { nroTelefone } com o texto { texto }.");
                }
            }
        }
    }
}
