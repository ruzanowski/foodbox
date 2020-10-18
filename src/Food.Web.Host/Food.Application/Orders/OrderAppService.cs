using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Food.Authorization;
using Food.Ordering;
using Food.Ordering.Dictionaries;
using Food.Orders.Dto.Order;
using Microsoft.EntityFrameworkCore;

namespace Food.Orders
{
    [AbpAuthorize(PermissionNames.Pages_Orders)]
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

            await ValidateCreate(input);

            var order = ObjectMapper.Map<Order>(input);

            order = await PreInclude(order);

            var discount = GetDiscount(order.Basket);
            var deliveryFee = GetDeliveryFee();

            order.Set(discount?.Id, deliveryFee?.Id);

            order = await PostInclude(order);

            order.CalculateBasket(discount?.Id, deliveryFee?.Id);

            await Repository.InsertAsync(order);
            await CurrentUnitOfWork.SaveChangesAsync();

            return MapToEntityDto(order);
        }

        public override async Task<OrderDto> UpdateAsync(OrderDto input)
        {
            CheckUpdatePermission();

            var order = await Repository
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
                .FirstOrDefaultAsync(x => x.Id == input.Id);

            if (order == null)
            {
                throw new EntityNotFoundException(typeof(Order), input.Id);
            }

            MapToEntity(input, order);

            //null to avoid already tracked entity
            foreach (var orderBasketItem in order.Basket.Items)
            {
                orderBasketItem.Calories = null;
                orderBasketItem.Cutlery = null;
                orderBasketItem.Delivery = null;
                orderBasketItem.Discount = null;
            }

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
                    x => x.Payment)
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

        private async Task ValidateCreate(CreateOrderDto input)
        {
            foreach (var item in input.Basket.Items)
            {
                var product = await _productRepository
                    .GetAllIncluding(x => x.Tax)
                    .FirstOrDefaultAsync(x => x.Id == item.ProductId);

                if (product == null)
                {
                    throw new EntityNotFoundException(typeof(Ordering.Dictionaries.Tax), item.ProductId);
                }

                if (item.CutleryFeeId != null)
                {
                    var cutlery = await _additionalsRepository
                        .GetAllIncluding(x => x.Tax)
                        .Where(x => x.Type == AdditionalsType.Cutlery)
                        .FirstOrDefaultAsync(x => x.Id == item.CutleryFeeId);

                    if (cutlery == null)
                    {
                        throw new EntityNotFoundException(typeof(Ordering.Dictionaries.Additionals), item.CutleryFeeId);
                    }
                }

                if (item.CaloriesId != null)
                {
                    var cutlery = await _caloriesRepository
                        .FirstOrDefaultAsync(x => x.Id == item.CaloriesId);

                    if (cutlery == null)
                    {
                        throw new EntityNotFoundException(typeof(Ordering.Dictionaries.Additionals), item.CaloriesId);
                    }
                }
            }
        }

        private async Task<Order> PreInclude(Order order)
        {
            foreach (var item in order.Basket.Items)
            {
                var product = await _productRepository
                    .GetAllIncluding(x => x.Tax)
                    .FirstOrDefaultAsync(x => x.Id == item.ProductId);

                item.Product ??= product;

                if (item.CutleryFeeId != null)
                {
                    var cutlery = await _additionalsRepository
                        .GetAllIncluding(x => x.Tax)
                        .FirstOrDefaultAsync(x => x.Id == item.CutleryFeeId);

                    if (cutlery == null)
                    {
                        throw new EntityNotFoundException(typeof(Ordering.Dictionaries.Additionals), item.CutleryFeeId);
                    }

                    item.Cutlery ??= cutlery;
                }

                if (item.CaloriesId != null)
                {
                    var calories = await _caloriesRepository
                        .FirstOrDefaultAsync(x => x.Id == item.CaloriesId);

                    if (calories == null)
                    {
                        throw new EntityNotFoundException(typeof(Ordering.Dictionaries.Additionals), item.CaloriesId);
                    }

                    item.Calories ??= calories;
                }
            }

            return order;
        }

        private async Task<Order> PostInclude(Order order)
        {
            foreach (var item in order.Basket.Items)
            {
                if (item.DiscountId != null)
                {
                    var discount = await _discountRepository
                        .FirstOrDefaultAsync(x => x.Id == item.DiscountId);

                    if (discount == null)
                    {
                        throw new EntityNotFoundException(typeof(Ordering.Dictionaries.Discount), item.DiscountId);
                    }

                    item.Discount ??= discount;
                }

                if (item.DeliveryFeeId != null)
                {
                    var delivery = await _additionalsRepository
                        .GetAllIncluding(x=>x.Tax)
                        .FirstOrDefaultAsync(x => x.Id == item.DeliveryFeeId);

                    if (delivery == null)
                    {
                        throw new EntityNotFoundException(typeof(Ordering.Dictionaries.Discount), item.DeliveryFeeId);
                    }

                    item.Delivery ??= delivery;
                }
            }

            return order;
        }

        private Ordering.Dictionaries.Discount GetDiscount(Basket basket)
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

        private Ordering.Dictionaries.Additionals GetDeliveryFee()
        {
            return _additionalsRepository.GetAllIncluding().ToList().Last(x => x.Type == AdditionalsType.Delivery);
        }
    }
}
