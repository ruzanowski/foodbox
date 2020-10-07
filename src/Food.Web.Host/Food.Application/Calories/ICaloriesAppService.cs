using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Food.Calories.Dto;

namespace Food.Calories
{
    public interface ICaloriesAppService : IAsyncCrudAppService<CaloriesDto, int, PagedResultRequestDto, CreateCaloriesDto, CaloriesDto>
    {
    }
}