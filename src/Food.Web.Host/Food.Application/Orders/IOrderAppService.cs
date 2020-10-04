using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Food.Orders.Dto.Order;

namespace Food.Orders
{
    public interface IOrderAppService : IAsyncCrudAppService<OrderDto, int, PagedResultRequestDto, CreateOrderDto, OrderDto>
    {
        Task AssignPayment(int orderId, int paymentId);
    }
}
