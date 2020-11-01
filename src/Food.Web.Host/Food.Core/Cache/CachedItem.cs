using Abp.Domain.Entities;

namespace Food.Cache
{
    public class CachedItem : Entity<int>
    {
        public string Ip { get; set; }
        public string Payload { get; set; }
    }
}
