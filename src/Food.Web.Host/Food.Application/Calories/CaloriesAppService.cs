using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Food.Authorization;
using Food.Calories.Dto;

namespace Food.Calories
{
    [AbpAuthorize(PermissionNames.Pages_Calories)]
    public class CaloriesAppService :
        AsyncCrudAppService<Ordering.Dictionaries.Calories, CaloriesDto, int, PagedResultRequestDto, CreateCaloriesDto, CaloriesDto>, ICaloriesAppService
    {
        public CaloriesAppService(IRepository<Ordering.Dictionaries.Calories, int> repository) : base(repository)
        {
        }
    }
}