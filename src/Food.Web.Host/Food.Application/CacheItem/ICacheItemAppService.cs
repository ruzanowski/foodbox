using System.Threading.Tasks;

namespace Food.CacheItem
{
    public interface ICacheItemAppService
    {
        Task<string> GetAsync();
        Task AppendAsync(string payload);
    }
}
