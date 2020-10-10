using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Food.Authorization;
using Food.Calories.Dto;

namespace Food.Calories
{
    public class CaloriesAppService :
        AsyncCrudAppService<Ordering.Dictionaries.Calories, CaloriesDto, int, PagedResultRequestDto, CreateCaloriesDto, CaloriesDto>, ICaloriesAppService
    {
        public CaloriesAppService(IRepository<Ordering.Dictionaries.Calories, int> repository) : base(repository)
        {
        }

        [AbpAuthorize(PermissionNames.Pages_Calories)]
        public override Task<CaloriesDto> CreateAsync(CreateCaloriesDto input)
        {
            return base.CreateAsync(input);
        }

        [AbpAuthorize(PermissionNames.Pages_Calories)]
        public override Task DeleteAsync(EntityDto<int> input)
        {
            return base.DeleteAsync(input);
        }

        [AbpAuthorize(PermissionNames.Pages_Calories)]
        public override Task<CaloriesDto> UpdateAsync(CaloriesDto input)
        {
            return base.UpdateAsync(input);
        }
    }
}
