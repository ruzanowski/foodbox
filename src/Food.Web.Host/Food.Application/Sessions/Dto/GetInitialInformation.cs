using System.Collections.Generic;
using Food.Additionals.Dto;
using Food.Calories.Dto;
using Food.Discount.Dto;
using Food.Product.Dto;
using Food.Tax.Dto;

namespace Food.Sessions.Dto
{
    public class GetInitialInformation
    {
        public ApplicationInfoDto Application { get; set; }
        public UserLoginInfoDto User { get; set; }
        public TenantLoginInfoDto Tenant { get; set; }
        public IReadOnlyList<CaloriesDto> Calories { get; set; }
        public IReadOnlyList<ProductDto> Products { get; set; }
        public IReadOnlyList<DiscountDto> Discounts { get; set; }
        public IReadOnlyList<AdditionalsDto> Additionals { get; set; }
        public IReadOnlyList<TaxDto> Taxes { get; set; }
    }
}
