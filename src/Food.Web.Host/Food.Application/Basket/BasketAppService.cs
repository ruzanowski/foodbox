using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Food.CacheItem;
using Food.Ordering;
using Food.Orders;
using Food.Orders.Dto.Basket;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Food.Basket
{
    [AbpAllowAnonymous]
    public class BasketAppService : ApplicationService, IBasketAppService
    {
        private readonly IRepository<Ordering.Basket> _repository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IOrderAppService _orderAppService;

        public BasketAppService(IRepository<Ordering.Basket> repository, IHttpContextAccessor httpContextAccessor, IOrderAppService orderAppService)
        {
            _repository = repository;
            _httpContextAccessor = httpContextAccessor;
            _orderAppService = orderAppService;
        }

        public async Task<BasketDto> GetAsync()
        {
            var ip = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            var basket = await _repository
                .GetAllIncluding()
                .Include(x=>x.Items)
                .ThenInclude(x=>x.DeliveryTimes)
                .FirstOrDefaultAsync(x => x.CreatorIp.Equals(ip));
            var basketDto = ObjectMapper.Map<BasketDto>(basket);

            return basketDto;
        }

        public async Task<BasketDto> AppendAsync(CreateBasketDto basket)
        {
            var ip = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            var sourceBasket = await _repository
                .GetAllIncluding()
                .Include(x=>x.Items)
                .ThenInclude(x=>x.DeliveryTimes)
                .FirstOrDefaultAsync(x => x.CreatorIp.Equals(ip)) ?? new Ordering.Basket();

            var calculatedBasket = await _orderAppService.CalculateBasket(new Ordering.Basket
                {
                    Id = sourceBasket?.Id ?? 0,
                    Items = ObjectMapper.Map<Ordering.Basket>(basket)?.Items ?? Enumerable.Empty<OrderBasketItem>(),
                    CreatorIp = ip
                });

            sourceBasket = ObjectMapper.Map<Ordering.Basket>(calculatedBasket);

            if (sourceBasket.Id < 0)
            {
                await _repository.InsertAsync(sourceBasket);
            }

            await CurrentUnitOfWork.SaveChangesAsync();

            return ObjectMapper.Map<BasketDto>(sourceBasket);
        }
    }
}
