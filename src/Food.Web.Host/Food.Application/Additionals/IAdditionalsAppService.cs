using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Food.Additionals.Dto;

namespace Food.Additionals
{
    public interface IAdditionalsAppService : IAsyncCrudAppService<AdditionalsDto, int, PagedResultRequestDto, CreateAdditionalsDto, AdditionalsDto>
    {
    }
}
