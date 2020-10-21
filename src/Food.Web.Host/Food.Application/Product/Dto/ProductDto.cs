using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Food.Tax.Dto;

namespace Food.Product.Dto
{
    [AutoMapFrom(typeof(Ordering.Product))]
    public class ProductDto : EntityDto<int>
    {
        [Required]

        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal PriceNet { get; set; }
        [Required]
        public decimal PriceGross { get; set; }
        [Required]
        public string ImagePath { get; set; }
        [Required]
        [Range(1,1000)]
        public int TaxId { get; set; }
        [Required]
        public TaxDto Tax { get; set; }
    }
}
