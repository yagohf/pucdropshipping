# Integrações

Este projeto consiste em: 

## [API para notificações de mudança de status dos pedidos](./Integracoes/Yagohf.PUC.Integracoes.Api)

Uma API escrita em .NET Core para integração entre fornecedor e loja (atualização de status de pedidos).

Antes de executar, **é necessário** ter configurado um [usuário](https://docs.aws.amazon.com/sns/latest/dg/UsingIAMwithSNS.html#keys) para acessar o [serviço de notificações da AWS](https://aws.amazon.com/pt/sns/).
Também **é necessário** ter configurado o [serviço de e-mail da AWS](https://aws.amazon.com/pt/ses) com um remetente válido.
Você também **deverá** ter em mãos os [dados de emissão de tokens associados ao seu pool de usuários no AWS Cognito](https://forums.aws.amazon.com/thread.jspa?threadID=254135).

Substituir no arquivo [appsettings.json](./Integracoes/Yagohf.PUC.Integracoes.Api/appsettings.json) as chaves seguintes:

- **Seção: "ConnectionStrings"**
  - DropshippingDB: substituir pela connection string do banco de dados da aplicação.
  - LogDB: substituir pela connection string do banco de dados da aplicação.

- **Seção: "ConfiguracoesApp"**
  - Sub-seção: "AWS"
    - Sub-seção: "SMS"
      - Usuario: Usuário do serviço de notificações da AWS (SNS).
      - Senha: Senha do usuário do serviço de notificações da AWS (SNS).
      - Region: Região a ser utilizada pelo serviço de notificações da AWS (SNS).
    - Sub-seção: "Email"
      - Servidor: Servidor configurado no serviço de e-mail da AWS (SES).
      - Porta: Porta configurada no servidor do serviço de e-mail da AWS (SES).
      - Usuario: Usuário autorizado a utilizar serviço de e-mail da AWS (SES).
      - Senha: Senha do usuário autorizado a utilizar serviço de e-mail da AWS  (SNS).
      - Remetente: Endereço de e-mail de origem utilizado para envio dos e-mails da aplicação (SNS).
      - NomeRemetente: Nome do remetente a ser exibido nos e-mails enviados pela aplicação (SNS).
    - Sub-seção: "Jwt"
      - Issuer: Endereço do issuer de tokens do pool do Cognito utilizado para autenticação.
      - Key: Chave da criptografia dos tokens do pool do Cognito.
      - Expo: Expoente utilizado na criptografia do pool do Cognito.
  
## [Lambda Function para consulta de disponibilidade de estoque](./Integracoes/Yagohf.PUC.Integracoes.ConsultarEstoque)
  
Função escrita no modelo serverless, utilizando os recursos da plataforma AWS Lambda. Para executá-la **é necessário** [criar uma função lambda na plataforma da AWS](https://aws.amazon.com/pt/lambda/) com esse código-fonte. A função deve aceitar as seguintes [variáveis de ambiente](https://docs.aws.amazon.com/lambda/latest/dg/env_variables.html):
- URL_BASE_API_AUTENTICACAO: [URL da API de autenticação da plataforma](./Autenticacao/Yagohf.PUC.Autenticacao.Web/Controllers/UsuariosController.cs).
- USUARIO_SERVICO: Usuário de serviço configurado para obtenção de token válido na API de autenticação.
- SENHA_SERVICO: Senha do usuário de serviço configurado para obtenção de token válido na API de autenticação.
- URL_BASE_API_ROTINAS: [URL da API para execução de rotinas automáticas](./Integracoes/Yagohf.PUC.Integracoes.Api/Controllers/RotinasController.cs).

### Atenção:
Para executar esses projetos, **é necessário** restaurar os pacotes utilizando o [Nuget](https://www.nuget.org/). Pode-se utilizar o [Visual Studio (versão 2017 ou superior)](https://visualstudio.microsoft.com/pt-br/vs/community/) ou o [Visual Studio Code](https://code.visualstudio.com/) e a [CLI do .NET Core](https://docs.microsoft.com/pt-br/dotnet/core/tools/?tabs=netcore2x) (utilizar o comando **dotnet restore** na raíz da aplicação).
