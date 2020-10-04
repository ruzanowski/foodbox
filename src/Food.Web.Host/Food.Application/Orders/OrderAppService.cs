using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore.Repositories;
using Abp.EntityFrameworkCore.Uow;
using Food.Authorization;
using Food.Ordering;
using Food.Orders.Dto.Order;
using Microsoft.EntityFrameworkCore;

namespace Food.Orders
{
    [AbpAuthorize(PermissionNames.Pages_Orders)]
    public class OrderAppService : AsyncCrudAppService<Order, OrderDto, int, PagedResultRequestDto, CreateOrderDto, OrderDto>, IOrderAppService
    {
        private readonly IRepository<Payment> _paymentRepository;

        public OrderAppService(IRepository<Order> repository,
            IRepository<Payment> paymentRepository) : base(repository)
        {
            _paymentRepository = paymentRepository;
        }

        protected override IQueryable<Order> CreateFilteredQuery(PagedResultRequestDto input)
        {
            return Repository.GetAllIncluding(
                    x => x.Form,
                    x => x.Payment,
                    x => x.Basket)
                .Include(x => x.Basket)
                    .ThenInclude(x => x.Items)
                        .ThenInclude(x => x.DeliveryTimes)
                .Include(x => x.Basket)
                    .ThenInclude(x => x.Items)
                        .ThenInclude(x => x.Product)
                .AsNoTracking();
        }

        public override async Task<OrderDto> UpdateAsync(OrderDto input)
        {
            CheckUpdatePermission();

            var order = await Repository
                .GetAllIncluding()
                .Include(x=>x.Form)
                // .Include(x=>x.Payment)
                // .Include(x=>x.Basket)
                //     .ThenInclude(x=>x.Items)
                //         .ThenInclude(x=>x.DeliveryTimes)
                .FirstOrDefaultAsync(x => x.Id == input.Id);

            if (order == null)
            {
                throw new EntityNotFoundException(typeof(Order), input.Id);
            }

            MapToEntity(input, order);

            await CurrentUnitOfWork.SaveChangesAsync();

            return await GetAsync(input);
        }

        protected override async Task<Order> GetEntityByIdAsync(int id)
        {
            var order = await Repository
                .GetAll()
                .Include(x=>x.Form)
                .Include(x=>x.Payment)
                .Include(x=>x.Basket)
                    .ThenInclude(x=>x.Items)
                        .ThenInclude(x=>x.DeliveryTimes)
                .Include(x => x.Basket)
                    .ThenInclude(x => x.Items)
                        .ThenInclude(x => x.Product)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (order == null)
            {
                throw new EntityNotFoundException(typeof(Order), id);
            }

            return order;
        }

        public async Task AssignPayment(int orderId, int paymentId)
        {
            var order = await Repository.GetAllIncluding(x => x.Payment)
                .FirstOrDefaultAsync(x => x.Id == orderId);

            if (order is null)
            {
                throw new EntityNotFoundException(typeof(Order), orderId);
            }

            var payment = await _paymentRepository
                .FirstOrDefaultAsync(x => x.Id == paymentId);

            if (payment is null)
            {
                throw new EntityNotFoundException(typeof(Payment), paymentId);
            }

            order.Payment = payment;

            await CurrentUnitOfWork.SaveChangesAsync();
        }
    }
}

