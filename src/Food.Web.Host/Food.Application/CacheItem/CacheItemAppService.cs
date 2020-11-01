using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Food.Cache;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Food.CacheItem
{
    [AbpAllowAnonymous]
    public class CacheItemAppService : ApplicationService, ICacheItemAppService
    {
        private readonly IRepository<CachedItem> _repository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CacheItemAppService(IRepository<CachedItem> repository, IHttpContextAccessor httpContextAccessor)
        {
            _repository = repository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<string> GetAsync()
        {
            var ip = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();

             var cachedItem = await _repository.GetAll().FirstOrDefaultAsync(x => x.Ip.Equals(ip));

             return cachedItem?.Payload;
        }

        public async Task AppendAsync(string payload)
        {
            var ip = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            var cachedItem = await _repository.GetAll().AsNoTracking().FirstOrDefaultAsync(x => x.Ip.Equals(ip));

            await _repository.InsertOrUpdateAsync(new CachedItem
            {
                Id = cachedItem?.Id ?? 0,
                Ip = ip,
                Payload = payload
            });
            await CurrentUnitOfWork.SaveChangesAsync();
        }
    }
}
