using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Food.Authorization;
using Food.Ordering;
using Food.Payments.Dto;

namespace Food.Payments
{

    public interface IPaymentAppService : IAsyncCrudAppService<PaymentDto, int, PagedResultRequestDto, CreatePaymentDto, PaymentDto>
    {
    }
    [AbpAuthorize(PermissionNames.Pages_Orders)]
    public class PaymentAppService : AsyncCrudAppService<Payment, PaymentDto, int, PagedResultRequestDto, CreatePaymentDto, PaymentDto>
    {
        public PaymentAppService(IRepository<Payment, int> repository) : base(repository)
        {
        }
    }
}
