using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Food.Payments.Dto;

namespace Food.Product
{
    public interface IProductAppService : IAsyncCrudAppService<PaymentDto, int, PagedResultRequestDto, CreatePaymentDto, PaymentDto>
    {
    }
}
