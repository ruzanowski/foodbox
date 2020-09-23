using System.Threading.Tasks;

namespace Food.Core.Authentication.External
{
    public interface IExternalAuthProviderApi
    {
        ExternalLoginProviderInfo ProviderInfo { get; }

        Task<bool> IsValidUser(string userId, string accessCode);

        Task<ExternalAuthUserInfo> GetUserInfo(string userId, string accessCode);

        void Initialize(ExternalLoginProviderInfo providerInfo);
    }
}
