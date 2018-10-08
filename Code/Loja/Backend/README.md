# Loja (back-end)

Este projeto consiste em uma API escrita em .NET Core para servir como backend da loja. Antes de executá-la, você **deverá** ter em mãos os [dados de emissão de tokens associados ao seu pool de usuários no AWS Cognito](https://forums.aws.amazon.com/thread.jspa?threadID=254135).

Para executar esse projeto, é necessário restaurar os pacotes utilizando o [Nuget](https://www.nuget.org/). Pode-se utilizar o [Visual Studio (versão 2017 ou superior)](https://visualstudio.microsoft.com/pt-br/vs/community/) ou o [Visual Studio Code](https://code.visualstudio.com/) e a [CLI do .NET Core](https://docs.microsoft.com/pt-br/dotnet/core/tools/?tabs=netcore2x) (utilizar o comando **dotnet restore** na raíz da aplicação).

Substituir no arquivo [appsettings.json](./Backend/Yagohf.PUC.Api/appsettings.json) as chaves seguintes:

- **Seção: "ConnectionStrings"**
  - DropshippingDB: substituir pela connection string do banco de dados da aplicação.
  - LogDB: substituir pela connection string do banco de dados da aplicação.

- **Seção: "ConfiguracoesApp"**
  - Sub-seção: "ServidorArquivosEstaticos"
    - CaminhoImagensPropagandas: URL base do site estático onde estão as imagens de propagandas da aplicação.
    - CaminhoImagensPromocoes: URL base do site estático onde estão as imagens de promoções da aplicação.
    - CaminhoImagensProdutos: URL base do site estático onde estão as imagens de produtos da aplicação.
   - Sub-seção: "Jwt"
     - Issuer: Endereço do issuer de tokens do pool do Cognito utilizado para autenticação.
     - Key: Chave da criptografia dos tokens do pool do Cognito.
     - Expo: Expoente utilizado na criptografia do pool do Cognito.
