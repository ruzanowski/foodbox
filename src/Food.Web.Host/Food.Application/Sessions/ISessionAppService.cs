using System.Threading.Tasks;
using Abp.Application.Services;
using Food.Sessions.Dto;

namespace Food.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
