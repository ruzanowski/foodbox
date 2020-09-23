using Xunit;

namespace Food.Tests
{
    public sealed class MultiTenantFactAttribute : FactAttribute
    {
        public MultiTenantFactAttribute()
        {
            Skip = "MultiTenancy is disabled.";
        }
    }
}
