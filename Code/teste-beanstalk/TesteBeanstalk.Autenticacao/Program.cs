using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using Amazon.Extensions.CognitoAuthentication;
using System;

namespace TesteBeanstalk.Autenticacao
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Hello World!");
                Console.WriteLine(ObterToken());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                Exception inner = ex.InnerException;
                while (inner != null && !string.IsNullOrEmpty(inner.Message))
                {
                    Console.WriteLine(inner.Message);
                    inner = inner.InnerException;
                }
            }
            finally
            {
                Console.ReadKey();
            }
        }

        private static string ObterToken()
        {
            AmazonCognitoIdentityProviderClient provider = new AmazonCognitoIdentityProviderClient(
                new Amazon.Runtime.AnonymousAWSCredentials(),
                Amazon.RegionEndpoint.USEast1);
            CognitoUserPool userPool = new CognitoUserPool("us-east-1_9c3aVM5JC", "6r4qkkb1shsqjkpau1ni4lah0j", provider, "1bi9c0gijo1ommbarg4a3kjd3j8c6228f5tafcdabptirt7qqgq2");
            CognitoUser user = new CognitoUser("yagohf", "6r4qkkb1shsqjkpau1ni4lah0j", userPool, provider, "1bi9c0gijo1ommbarg4a3kjd3j8c6228f5tafcdabptirt7qqgq2");
            InitiateSrpAuthRequest authRequest = new InitiateSrpAuthRequest()
            {
                Password = "Y@gohf_3107"
            };
            AuthFlowResponse authResponse = user.StartWithSrpAuthAsync(authRequest).GetAwaiter().GetResult();
            if (authResponse.ChallengeName == ChallengeNameType.NEW_PASSWORD_REQUIRED)
            {
                Console.WriteLine("Enter your desired new password:");
                string newPassword = Console.ReadLine();
                authResponse = user.RespondToNewPasswordRequiredAsync(new
                RespondToNewPasswordRequiredRequest()
                {
                    SessionID = authResponse.SessionID,
                    NewPassword = newPassword
                }).GetAwaiter().GetResult();
            }

            string token = authResponse.AuthenticationResult.IdToken; //Token para validar no gateway.
            return token;
        }
    }
}
