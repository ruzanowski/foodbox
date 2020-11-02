using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Food.Authorization;
using Food.Ordering;
using Food.Orders.Dto.Order;
using Microsoft.EntityFrameworkCore;

namespace Food.Orders
{
    public class OrderAppService :
        AsyncCrudAppService<Order, OrderDto, int, PagedResultRequestDto, CreateOrderDto, OrderDto>, IOrderAppService
    {
        private readonly IRepository<Payment> _paymentRepository;
        private readonly IRepository<Ordering.Product> _productRepository;
        private readonly IRepository<Ordering.Dictionaries.Additionals> _additionalsRepository;
        private readonly IRepository<Ordering.Dictionaries.Calories> _caloriesRepository;
        private readonly IRepository<Ordering.Dictionaries.Discount> _discountRepository;

        public OrderAppService(IRepository<Order> repository,
            IRepository<Payment> paymentRepository,
            IRepository<Ordering.Product> productRepository,
            IRepository<Ordering.Dictionaries.Additionals> additionalsRepository,
            IRepository<Ordering.Dictionaries.Calories> caloriesRepository,
            IRepository<Ordering.Dictionaries.Discount> discountRepository) : base(repository)
        {
            _paymentRepository = paymentRepository;
            _productRepository = productRepository;
            _additionalsRepository = additionalsRepository;
            _caloriesRepository = caloriesRepository;
            _discountRepository = discountRepository;
        }

        public override async Task<OrderDto> CreateAsync(CreateOrderDto input)
        {
            CheckCreatePermission();

            var userId = AbpSession.GetUserId();

            var order = ObjectMapper.Map<Order>(input);

            await CalculateBasket(order.Basket);

            await Repository.InsertAsync(order);
            await CurrentUnitOfWork.SaveChangesAsync();

            return MapToEntityDto(order);
        }

        [AbpAuthorize(PermissionNames.Pages_Orders)]
        public override Task DeleteAsync(EntityDto<int> input)
        {
            return base.DeleteAsync(input);
        }

        [AbpAuthorize(PermissionNames.Pages_Orders)]
        public override Task<OrderDto> GetAsync(EntityDto<int> input)
        {
            return base.GetAsync(input);
        }

        [AbpAuthorize(PermissionNames.Pages_Orders)]
        public override Task<PagedResultDto<OrderDto>> GetAllAsync(PagedResultRequestDto input)
        {
            return base.GetAllAsync(input);
        }
        [AbpAuthorize(PermissionNames.Pages_Orders)]
        public override async Task<OrderDto> UpdateAsync(OrderDto input)
        {
            CheckUpdatePermission();

            var order = await GetEntityByIdAsync(input.Id);

            var userId = AbpSession.GetUserId();

            if (!userId.Equals(order.CreatorUserId) && !await IsGrantedAsync(PermissionNames.Pages_Orders))
            {
                throw new AbpAuthorizationException("Brak dostępu dla nie swoich zamówień.");
            }

            MapToEntity(input, order);

            await CalculateBasket(order.Basket);

            await Repository.UpdateAsync(order);
            await CurrentUnitOfWork.SaveChangesAsync();

            return await GetAsync(input);
        }

        protected override IQueryable<Order> CreateFilteredQuery(PagedResultRequestDto input)
        {
            return Repository
                .GetAllIncluding(
                    x => x.Form,
                    x => x.Payment,
                    x => x.Basket)
                .Include(x => x.Basket)
                    .ThenInclude(x => x.Items)
                        .ThenInclude(x => x.DeliveryTimes)
                .Include(x => x.Basket)
                    .ThenInclude(x => x.Items)
                        .ThenInclude(x => x.Product)
                            .ThenInclude(x => x.Tax)
                .Include(x => x.Basket)
                    .ThenInclude(x => x.Items)
                        .ThenInclude(x => x.Cutlery)
                            .ThenInclude(x=>x.Tax)
                .Include(x => x.Basket)
                    .ThenInclude(x => x.Items)
                        .ThenInclude(x => x.Delivery)
                            .ThenInclude(x=>x.Tax)
                .Include(x => x.Basket)
                    .ThenInclude(x => x.Items)
                        .ThenInclude(x => x.Discount)
                .Include(x => x.Basket)
                    .ThenInclude(x => x.Items)
                        .ThenInclude(x => x.Calories)
                .AsNoTracking();
        }
        protected override async Task<Order> GetEntityByIdAsync(int id)
        {
            var order = await Repository
                .GetAllIncluding(
                    x => x.Form,
                    x => x.Payment,
                    x=> x.Basket)
                .Include(x => x.Basket)
                    .ThenInclude(x => x.Items)
                        .ThenInclude(x => x.DeliveryTimes)
                .Include(x => x.Basket)
                    .ThenInclude(x => x.Items)
                        .ThenInclude(x => x.Product)
                            .ThenInclude(x => x.Tax)
                .Include(x => x.Basket)
                    .ThenInclude(x => x.Items)
                        .ThenInclude(x => x.Cutlery)
                            .ThenInclude(x=>x.Tax)
                .Include(x => x.Basket)
                    .ThenInclude(x => x.Items)
                        .ThenInclude(x => x.Delivery)
                            .ThenInclude(x=>x.Tax)
                .Include(x => x.Basket)
                    .ThenInclude(x => x.Items)
                        .ThenInclude(x => x.Discount)
                .Include(x => x.Basket)
                    .ThenInclude(x => x.Items)
                        .ThenInclude(x => x.Calories)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (order == null)
            {
                throw new EntityNotFoundException(typeof(Order), id);
            }

            return order;
        }
        [AbpAllowAnonymous]
        public async Task AssignPayment(int orderId, int paymentId)
        {
            var order = await Repository.GetAllIncluding(x => x.Payment)
                .FirstOrDefaultAsync(x => x.Id == orderId);

            if (order is null)
            {
                throw new EntityNotFoundException(typeof(Order), orderId);
            }
            var userId = AbpSession.GetUserId();

            if (!userId.Equals(order.CreatorUserId) && !await IsGrantedAsync(PermissionNames.Pages_Orders))
            {
                throw new AbpAuthorizationException("Brak dostępu dla nie swoich zamówień.");
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

        public async Task<Ordering.Basket> CalculateBasket(Ordering.Basket basket)
        {
            var discount = GetDiscount(basket);

            foreach (var item in basket.Items)
            {
                var product = await GetProduct(item);
                var cutlery = await GetCutlery(item);
                var delivery = await GetDelivery(item);
                var calories = await GetCalories(item);

                item.Update(product, calories, delivery, cutlery, discount);
            }

            return basket;
        }

        private Ordering.Dictionaries.Discount GetDiscount(Ordering.Basket basket)
        {
            var cumulativeDays = basket.Items.Sum(orderBasketItem => orderBasketItem.DeliveryTimes.Count());
            var discounts = _discountRepository
                .GetAllIncluding()
                .ToList();

            var discount = discounts
                .Where(x => x.MinimumDays < cumulativeDays)
                .OrderByDescending(x => x.MinimumDays)
                .FirstOrDefault();

            return discount;
        }

        private async Task<Ordering.Product> GetProduct(OrderBasketItem item) =>
            await _productRepository
                .GetAllIncluding(x => x.Tax)
                .FirstOrDefaultAsync(x => x.Id == item.ProductId);
        private async Task<Ordering.Dictionaries.Additionals> GetCutlery(OrderBasketItem item)
        {
            if (item.CutleryFeeId == null) return null;

            var cutlery = await _additionalsRepository
                .GetAllIncluding(x => x.Tax)
                .FirstOrDefaultAsync(x => x.Id == item.CutleryFeeId);

            if (cutlery == null)
            {
                throw new EntityNotFoundException(typeof(Ordering.Dictionaries.Additionals), item.CutleryFeeId);
            }

            return cutlery;
        }
        private async Task<Ordering.Dictionaries.Additionals> GetDelivery(OrderBasketItem item)
        {
            if (item.DeliveryFeeId == null) return null;

            var delivery = await _additionalsRepository
                .GetAllIncluding(x=>x.Tax)
                .FirstOrDefaultAsync(x => x.Id == item.DeliveryFeeId);

            if (delivery == null)
            {
                throw new EntityNotFoundException(typeof(Ordering.Dictionaries.Additionals), item.DeliveryFeeId);
            }

            return delivery;
        }
        private async Task<Ordering.Dictionaries.Calories> GetCalories(OrderBasketItem item)
        {
            if (item.CaloriesId == null) return null;

            var calories = await _caloriesRepository
                .FirstOrDefaultAsync(x => x.Id == item.CaloriesId);

            if (calories == null)
            {
                throw new EntityNotFoundException(typeof(Ordering.Dictionaries.Additionals), item.CaloriesId);
            }

            return calories;
        }
    }
}
