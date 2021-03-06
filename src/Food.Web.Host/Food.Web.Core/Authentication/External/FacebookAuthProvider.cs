using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Food.Core.Authentication.External
{
    public class FacebookAuthProvider : ExternalAuthProviderApiBase
    {
        private static readonly HttpClient Client = new HttpClient();
        public const string Name = "Facebook";

        public override async Task<ExternalAuthUserInfo> GetUserInfo(string userId, string accessCode)
        {
            //gen app access token
            var appAccessTokenResponse = await Client.GetStringAsync("https://graph.facebook.com/oauth/access_token" +
                                                                     "?client_id=" + ProviderInfo.ClientId +
                                                                     "&client_secret=" + ProviderInfo.ClientSecret +
                                                                     "&grant_type=client_credentials");
            var appAccessToken = JsonConvert.DeserializeObject<FacebookAppAccessToken>(appAccessTokenResponse);
            //validate user access token
            var userAccessTokenValidationResponse = await Client.GetStringAsync(
                "https://graph.facebook.com/v3.2/debug_token" +
                "?input_token=" + accessCode +
                "&access_token=" + appAccessToken.AccessToken);
            var userAccessTokenValidation =
                JsonConvert.DeserializeObject<FacebookUserAccessTokenValidation>(userAccessTokenValidationResponse);
            if (!userAccessTokenValidation.Data.IsValid)
            {
                throw new ArgumentException("login_failure Invalid facebook token.");
            }

            //get userinfo
            var userInfoResponse = await Client.GetStringAsync(
                $"https://graph.facebook.com/v3.2/me?fields=id,email,first_name,last_name&access_token={accessCode}");
            var userInfo = JsonConvert.DeserializeObject<FacebookUserData>(userInfoResponse);

            return new ExternalAuthUserInfo
            {
                Name = userInfo.FirstName,
                EmailAddress = userInfo.Email,
                Surname = userInfo.LastName,
                Provider = Name,
                ProviderKey = userInfo.Id.ToString()
            };
        }
    }
}
