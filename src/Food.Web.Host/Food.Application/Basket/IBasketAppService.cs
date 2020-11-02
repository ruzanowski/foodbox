using System.Threading.Tasks;
using Food.Orders.Dto.Basket;

namespace Food.CacheItem
{
    public interface IBasketAppService
    {
        Task<BasketDto> GetAsync();
        Task<BasketDto> AppendAsync(CreateBasketDto basket);
    }
}
