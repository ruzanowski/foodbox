using System.Threading.Tasks;
using Abp.Application.Services;
using Food.Authorization.Accounts.Dto;

namespace Food.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
