# Autenticação

Este projeto consiste em uma API escrita em .NET Core para autenticação dos usuários de quaisquer perfis na plataforma. O recurso para autenticação utilizado foi o [AWS Cognito](https://aws.amazon.com/pt/cognito/).

Para executar esse projeto, é necessário restaurar os pacotes utilizando o [Nuget](https://www.nuget.org/). Pode-se utilizar o [Visual Studio (versão 2017 ou superior)](https://visualstudio.microsoft.com/pt-br/vs/community/) ou o [Visual Studio Code](https://code.visualstudio.com/) e a [CLI do .NET Core](https://docs.microsoft.com/pt-br/dotnet/core/tools/?tabs=netcore2x) (utilizar o comando **dotnet restore** na raíz da aplicação).

Antes de executar, **é necessário** [possuir um pool de usuários criado no AWS Cognito](https://docs.aws.amazon.com/cognito/latest/developerguide/tutorial-create-user-pool.html). Também **é necessário** [possuir uma aplicação cliente cadastrada para utilização do pool](https://docs.aws.amazon.com/cognito/latest/developerguide/user-pool-settings-client-apps.html).
Substituir no arquivo [appsettings.json](./Autenticacao/Yagohf.PUC.Autenticacao.Web/appsettings.json) as chaves seguintes:

- **Seção: "ConnectionStrings"**
  - LogDB: substituir pela connection string do banco de dados da aplicação.

- **Seção: "AWS"**
  - PoolID: substituir pelo ID do pool criado obtido no console do Cognito.
  - PoolRegion: região em que o pool foi criado.
  - ClientID: identificação da aplicação que foi criada para utilização do pool.
  - ClientSecret: senha associada a aplicação criada para utilização do pool.
