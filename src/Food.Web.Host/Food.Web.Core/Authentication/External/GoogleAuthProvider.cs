using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Auth;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;

namespace Food.Core.Authentication.External
{
    public class GoogleAuthProvider : ExternalAuthProviderApiBase
    {
        public const string Name = "Google";

        /// <summary>
        /// The flow is as follows
        /// 1) We have the access code. We send it off to get a TokenResponse, which contains access and id tokens.
        /// 2) we use the id token and send it for validation, which will also give us back the user details.
        /// (as long as we have the profile scope)
        /// </summary>
        /// <param name="accessCode"></param>
        /// <returns></returns>
        public override async Task<ExternalAuthUserInfo> GetUserInfo(string userId, string accessCode)
        {
            var flow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
            {
                ClientSecrets = new ClientSecrets
                {
                    ClientId = ProviderInfo.ClientId,
                    ClientSecret = ProviderInfo.ClientSecret
                },
                Scopes = new[] { "profile" }
            });


            TokenResponse credential = await flow.ExchangeCodeForTokenAsync(userId, accessCode, "postmessage", CancellationToken.None);
            var idtokenpayload = await GoogleJsonWebSignature.ValidateAsync(credential.IdToken);

            return new ExternalAuthUserInfo
            {
                EmailAddress = idtokenpayload.Email,
                Name = idtokenpayload.GivenName,
                Provider = ProviderInfo.Name,
                ProviderKey = ProviderInfo.ClientId,
                Surname = idtokenpayload.FamilyName
            };

        }
    }
}
